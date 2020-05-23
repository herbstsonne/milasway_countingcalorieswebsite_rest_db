using System;
using System.Collections.Generic;

namespace CountingCalories.Models
{
    public class Person
    {
        public Person()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }
        public List<FoodInDay> MyWholeNutrition { get; set; }
    }
}