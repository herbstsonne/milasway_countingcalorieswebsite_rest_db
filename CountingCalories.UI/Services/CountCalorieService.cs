using System;
using System.Collections.Generic;
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

        public void AddFoodOfDay(FoodPerDayEntity food, List<FoodEntryEntity> foodEntries)
        {
            var dataFoodEntry = JsonConvert.SerializeObject(foodEntries);
            var contentFoodEntry = new StringContent(dataFoodEntry, Encoding.UTF8, "application/json");
            _httpClient.PostAsync($"api/countcalorie", contentFoodEntry);

            var dataFood = JsonConvert.SerializeObject(food);
            var content = new StringContent(dataFood, Encoding.UTF8, "application/json");
            _httpClient.PostAsync($"api/countcalorie/{food.Id}", content);
        }
        public async Task<FoodPerDayEntity> GetFoodOfDay(DateTime date)
        {
            var datestring = date.ToString("dd.MM.yyyy");
            var data = await _httpClient.GetAsync($"api/countcalorie/{datestring}");
            return JsonConvert.DeserializeObject<FoodPerDayEntity>(await data.Content.ReadAsStringAsync());
        }
    }
}
