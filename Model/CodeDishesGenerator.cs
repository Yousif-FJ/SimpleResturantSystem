using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SimpleResturantSystem.Model
{
    public static class CodeDishesGenerator 
    {
        public static IList<Dish> GetDishes()
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var dishes = new List<Dish>{
                new Dish("Macaroni",$"{basePath}\\Resource\\49524.jpg",4000),
                new Dish("Macaroni",$"{basePath}\\Resource\\49524.jpg",4000),
                new Dish("Macaroni",$"{basePath}\\Resource\\49524.jpg",4000)
            };

            return dishes;
        }
    }
}
