using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CountingCalories.UI.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace CountingCalories.UI.Services
{
    public class CountCalorieService
    {
        [Inject]
        public HttpClient _httpClient { get; set; }

        public CountCalorieService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void AddFoodOfDay(FoodInDay food)
        {
            var data = JsonConvert.SerializeObject(food);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            _httpClient.PostAsync($"api/countcalorie/{food.Id}", content);
        }
        public async Task<FoodInDay> GetFoodOfDay(DateTime date)
        {
            var data = await _httpClient.GetAsync($"api/countcalorie");
            return JsonConvert.DeserializeObject<FoodInDay>(await data.Content.ReadAsStringAsync());
        }
    }
}
