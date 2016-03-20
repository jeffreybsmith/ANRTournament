using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using System.Collections;
using System.Net.Http;
using System.Net.Http.Headers;
using ANRTournament.Models;
using Newtonsoft.Json;


namespace ANRTournament.Services
{
    public class NetrunnerDBService : ICardsService
    {
        public const string CacheKey = nameof(NetrunnerDBService);

        private readonly IMemoryCache _cache;

        public NetrunnerDBService()
        {
            _apiUrl = @"http://netrunnerdb.com/";
        }

        public string _apiUrl { get; private set; }

        public async Task<IList> GetCardsAsync(bool disableCache)
        {
            
            if (disableCache)
            {
                return await GetCards();
            }

            var result = _cache.Get<IList>(CacheKey);

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

        private async Task<IList> GetCards()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/cards");
                //if (response.IsSuccessStatusCode)
                //{
                    List<Card> cards = new List<Card>();
                    var results = await response.Content.ReadAsStringAsync();
                    cards.Add(JsonConvert.DeserializeObject<Card>(results));

                    return cards;
                //}
            }
        }
    }
}
