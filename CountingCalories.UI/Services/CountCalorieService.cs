using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CountingCalories.Domain.Entities;
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
            var dataFood = JsonConvert.SerializeObject(food);
            var content = new StringContent(dataFood, Encoding.UTF8, "application/json");
            _httpClient.PostAsync($"api/countcalorie/{food.Id}", content);

            UpdateFoodOfDay(food, foodEntries);
        }

        public async Task<FoodPerDayEntity> GetFoodOfDay(DateTime date)
        {
            var datestring = date.ToString("dd.MM.yyyy");
            var data = await _httpClient.GetAsync($"api/countcalorie/{datestring}");
            return JsonConvert.DeserializeObject<FoodPerDayEntity>(await data.Content.ReadAsStringAsync());
        }

        public void UpdateFoodOfDay(FoodPerDayEntity food, List<FoodEntryEntity> foodEntries)
        {
            var dataFoodEntry = JsonConvert.SerializeObject(foodEntries);
            var contentFoodEntry = new StringContent(dataFoodEntry, Encoding.UTF8, "application/json");
            _httpClient.PutAsync($@"api/countcalorie/{food.Id}", contentFoodEntry);
        }
    }
}
