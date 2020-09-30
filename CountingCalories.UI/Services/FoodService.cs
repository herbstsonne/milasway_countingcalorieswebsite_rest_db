using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CountingCalories.Shared.ViewModels;
using Newtonsoft.Json;
using Ninject;

namespace CountingCalories.UI.Services
{
    public class FoodService
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        public FoodService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public void SaveFood(FoodView food)
        {
            try
            {
                var json = JsonConvert.SerializeObject(food);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient.PostAsync("/api/food", data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task<List<FoodView>> GetAllFood()
        {
            try
            {
                var response = await HttpClient.GetAsync("api/food");
                var content = await response.Content.ReadAsStringAsync();
                var allFood = JsonConvert.DeserializeObject<List<FoodView>>(content);
                return allFood;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public async Task Delete(FoodView food)
        {
            try
            {
                var response = await HttpClient.DeleteAsync($"api/food/{food.FoodId}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Update(List<FoodView> allFood)
        {
            try
            {
                var json = JsonConvert.SerializeObject(allFood);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient.PutAsync("api/food", data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
