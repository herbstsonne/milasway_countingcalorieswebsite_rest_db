using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using CountingCalories.Domain.ViewModels;
using Newtonsoft.Json;
using Ninject;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace CountingCalories.Domain.Services
{
    public class CountCalorieService
    {
        [Inject]
        public HttpClient _httpClient { get; set; }

        public CountCalorieService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<FoodPerDayView> GetFoodOfDay(DateTime date)
        {
            var datestring = date.ToString("dd.MM.yyyy");
            var data = await _httpClient.GetAsync($"api/countcalorie/{datestring}");
            return JsonConvert.DeserializeObject<FoodPerDayView>(await data.Content.ReadAsStringAsync());
        }

        public async Task AddFoodOfDay(FoodPerDayView foodPerDay, FoodEntryView foodEntryView)
        {
            var dataFood = JsonSerializer.Serialize(foodPerDay);
            var content = new StringContent(dataFood, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"api/countcalorie/{foodPerDay}", content);

            UpdateFoodOfDay(foodPerDay, foodEntryView);
        }

        public async Task UpdateFoodOfDay(FoodPerDayView foodPerDay, FoodEntryView foodEntryView)
        {
            var dataFoodEntry = JsonSerializer.Serialize(foodEntryView);
            var contentFoodEntry = new StringContent(dataFoodEntry, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("api/countcalorie", contentFoodEntry);
        }
    }
}
