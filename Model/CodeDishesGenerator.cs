using System;
using System.Collections.Generic;

namespace SimpleResturantSystem.Model
{
    public static class CodeDishesGenerator
    {
        public static IList<Dish> GetDishes()
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var dishes = new List<Dish>{
                new Dish("Macaroni",$"{basePath}\\Resource\\macaroni.jpg",5000),
                new Dish("Egg",$"{basePath}\\Resource\\egg.jpg",3000),
                new Dish("Rice",$"{basePath}\\Resource\\rice.jpg",7000),
                new Dish("Sandwich",$"{basePath}\\Resource\\sandwich.jpg",4000),
                new Dish("pizza",$"{basePath}\\Resource\\pizza.jpg",15000)
            };

            return dishes;
        }
    }
}
