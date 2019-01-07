using BookApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Services
{
    public class GiftApiProxy
    {
        private const string baseUrl = "http://localhost:63219";

        public async Task<IEnumerable<GiftItem>> GetAllGiftItems()
        {
            var url = $"{baseUrl}/api/giftitems";
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(url);
            var giftitems = JsonConvert.DeserializeObject<List<GiftItem>>(json);

            return giftitems;
        }

        public async Task<IEnumerable<GiftItem>> GetBoyGifts()
        {
            var url = $"{baseUrl}/api/giftitems/giftsForBoys";
            var httpClient = new HttpClient();

            string json = await httpClient.GetStringAsync(url);
            var giftitems = JsonConvert.DeserializeObject<List<GiftItem>>(json);

            return giftitems;
        }

        public async Task<IEnumerable<GiftItem>> GetGirlGifts()
        {
            var url = $"{baseUrl}/api/giftitems/giftsForGirls";
            var httpClient = new HttpClient();

            string json = await httpClient.GetStringAsync(url);
            var giftitems = JsonConvert.DeserializeObject<List<GiftItem>>(json);

            return giftitems;
        }

        public async Task<IEnumerable<GiftItem>> GetGiftsByNumber(int id)
        {
            var url = $"{baseUrl}/api/giftitems/giftsByNumber";
            var httpClient = new HttpClient();

            string json = await httpClient.GetStringAsync(url);
            var giftitems = JsonConvert.DeserializeObject<List<GiftItem>>(json);

            return giftitems;
        }

        internal async Task<bool> CreateGiftItem(GiftItem giftItem)
        {
            var url = $"{baseUrl}/api/giftitems/addGift";
            var httpClient = new HttpClient();

            string json = JsonConvert.SerializeObject(giftItem);

            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, stringContent);
            return response.IsSuccessStatusCode;
        }
    }
}
