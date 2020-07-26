using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CountingCalories.Domain.ViewModels;
using Newtonsoft.Json;
using Ninject;

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

        public async Task AddFoodOfDay(FoodPerDayView foodPerDay, List<FoodEntryView> foodEntries)
        {
            var dataFood = JsonConvert.SerializeObject(foodPerDay);
            var content = new StringContent(dataFood, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"api/countcalorie/{foodPerDay}", content);

            UpdateFoodOfDay(foodPerDay, foodEntries);
        }

        public async Task UpdateFoodOfDay(FoodPerDayView foodPerDay, List<FoodEntryView> foodEntries)
        {
            var allFoodEntriesPerDay = new Dictionary<FoodEntryView, string>();
            foreach (var entry in foodEntries)
            {
                allFoodEntriesPerDay.Add(entry, foodPerDay.Day);
            }

            var dataFoodEntry = JsonConvert.SerializeObject(allFoodEntriesPerDay);
            var contentFoodEntry = new StringContent(dataFoodEntry, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("api/countcalorie", contentFoodEntry);
        }
    }
}
