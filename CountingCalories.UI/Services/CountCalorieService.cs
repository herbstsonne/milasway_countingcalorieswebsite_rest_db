using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CountingCalories.Shared.ViewModels;
using Newtonsoft.Json;
using Ninject;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace CountingCalories.UI.Services
{
    public class CountCalorieService
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        public CountCalorieService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<FoodPerDayView> GetFoodOfDay(DateTime date)
        {
            var datestring = date.ToString("dd.MM.yyyy");
            var data = await HttpClient.GetAsync($"api/countcalorie/{datestring}");
            return JsonConvert.DeserializeObject<FoodPerDayView>(await data.Content.ReadAsStringAsync());
        }

        public async Task<int> GetFoodEntryIdOfLastEntry()
        {
            var data = await HttpClient.GetAsync("api/countcalorie");
            return JsonConvert.DeserializeObject<int>(await data.Content.ReadAsStringAsync());
        }

        public async Task AddFoodOfDay(FoodPerDayView foodPerDay, FoodEntryView foodEntryView)
        {
            var dataFood = JsonSerializer.Serialize(foodPerDay);
            var content = new StringContent(dataFood, Encoding.UTF8, "application/json");
            await HttpClient.PostAsync($"api/countcalorie/{foodPerDay}", content);

            await UpdateFoodOfDay(foodPerDay, foodEntryView);
        }

        public async Task UpdateFoodOfDay(FoodPerDayView foodPerDay, FoodEntryView foodEntryView)
        {
            var dataFoodEntry = JsonSerializer.Serialize(foodEntryView);
            var contentFoodEntry = new StringContent(dataFoodEntry, Encoding.UTF8, "application/json");
            await HttpClient.PutAsync("api/countcalorie", contentFoodEntry);
        }

        public async Task DeleteFoodEntry(FoodEntryView foodEntry)
        {
            await HttpClient.DeleteAsync($"api/countcalorie/{foodEntry.EntryId}");
        }
    }
}
