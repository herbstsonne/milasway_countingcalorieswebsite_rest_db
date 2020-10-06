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
    public class FoodPerDayService
    {
        public Guid InstanceId { get; } = Guid.NewGuid();

        [Inject]
        public HttpClient HttpClient { get; set; }

        public FoodPerDayService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<FoodPerDayView> GetFoodPerDay(DateTime date)
        {
            var datestring = date.ToString("dd.MM.yyyy");
            var data = await HttpClient.GetAsync($"api/countcalorie/{datestring}");
            return JsonConvert.DeserializeObject<FoodPerDayView>(await data.Content.ReadAsStringAsync());
        }

        public async Task AddFoodPerDay(FoodPerDayView foodPerDay, FoodEntryView foodEntryView)
        {
            var dataFood = JsonSerializer.Serialize(foodPerDay);
            var content = new StringContent(dataFood, Encoding.UTF8, "application/json");
            await HttpClient.PostAsync($"api/countcalorie/{foodPerDay}", content);

            await UpdateFoodPerDay(foodPerDay);
        }

        public async Task UpdateFoodPerDay(FoodPerDayView foodPerDay)
        {
            var dataFoodEntry = JsonSerializer.Serialize(foodPerDay);
            var contentFoodEntry = new StringContent(dataFoodEntry, Encoding.UTF8, "application/json");
            await HttpClient.PutAsync("api/countcalorie", contentFoodEntry);
        }
    }
}
