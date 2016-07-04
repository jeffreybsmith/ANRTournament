using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using System.Collections;
using System.Net.Http;
using ANRTournament.Models;
using System.Net.Http.Headers;
using Newtonsoft.Json;

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

        public async Task<CardList> GetCardsAsync(bool disableCache)
        {
            
            if (disableCache)
            {
                return await GetCards();
            }

            var result = _cache.Get<CardList>(CacheKey);

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

        private async Task<CardList> GetCards()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/cards");
                if (response.IsSuccessStatusCode)
                {

                    var result = new CardList();

                    var model = new List<Card>();
                    
                    var jsonString = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<List<Card>>(jsonString);
                    CardList cards = new CardList();
                    cards.Cards = model;
                    //cards.Add(JsonConvert.DeserializeObject<Card>(results));
                    //result.Cards = await response.Content.Read.Select(item => new Show
                    return cards;
                }
                else
                {
                    return new CardList();
                }
            }
        }
    }
}
