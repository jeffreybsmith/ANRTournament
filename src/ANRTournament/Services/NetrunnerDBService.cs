using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using System.Collections;
using System.Net.Http;
using ANRTournament.Models;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace ANRTournament.Services
{
    public class NetrunnerDBService : ICardsService
    {
        public const string CacheKey = nameof(NetrunnerDBService);

        private readonly IMemoryCache _cache;

        public NetrunnerDBService(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
            _apiUrl = @"http://netrunnerdb.com/";
        }

        public string _apiUrl { get; private set; }

        public async Task<List<Card>> GetCardsAsync(bool disableCache)
        {
            
            if (disableCache)
            {
                return await GetCards();
            }

            var result = _cache.Get<List<Card>>(CacheKey);

            if (result == null)
            {
                result = await GetCards();

                _cache.Set(CacheKey, result, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1)
                });
            }

            return result;
        }

        private async Task<List<Card>> GetCards()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/2.0/public/cards");
                if (response.IsSuccessStatusCode)
                {

                    var result = new CardList();

                    var model = new List<Card>();
                    
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var dataset = JsonConvert.DeserializeObject<NetrunnerDBDataSet>(jsonString);
                    foreach (Card card in dataset.data)
                    {
                        card.Imagesrc = Regex.Replace(dataset.imageUrlTemplate.ToString(), @"\{code\}", card.Code);
                        model.Add(card);
                    }
                    return model;
                }
                else
                {
                    return new List<Card>();
                }
            }
        }
    }
}
