using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SimpleResturantSystem.Model
{
    public static class CodeDishesGenerator
    {
        private const string MenuUri = "\\Menu.json";
        public static IList<Dish> GetDishes()
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            try
            {
                var json = File.ReadAllText($"{basePath}\\{MenuUri}");
                var dishes = JsonSerializer.Deserialize<List<Dish>>(json);
                return dishes;
            }
            catch (Exception)
            {
                return null; 
            }
        }
    }
}
