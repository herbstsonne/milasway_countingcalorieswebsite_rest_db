using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CountingCalories.UI.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CountingCalories.UI.Services
{
    public class FoodService
    {
        private List<Food> allFood;

        [Inject]
        public HttpClient _HttpClient { get; set; }

        public FoodService(HttpClient httpClient)
        {
            _HttpClient = httpClient;
        }

        public void SaveFood(Food food)
        {
            var json = JsonConvert.SerializeObject(food);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            _HttpClient.PostAsync("/api/food", data);
        }

        public async Task<List<Food>> GetAllFood()
        {
            var response = await _HttpClient.GetAsync("/api/food");
            var content = await response.Content.ReadAsStringAsync();
            allFood = JsonConvert.DeserializeObject<List<Food>>(content);
            return allFood;
        }

        public async Task Delete(Food food)
        {
            var response = await _HttpClient.DeleteAsync($"api/food/{food.Id}");
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"{food.Name} could not be deleted!");
        }

        public void Update(List<Food> allFood)
        {
            var json = JsonConvert.SerializeObject(allFood);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            _HttpClient.PutAsync("api/food", data);
        }
    }
}
