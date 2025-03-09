using LatihanQuiz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LatihanQuiz.Factories
{
    public class FoodFactory
    {
        public Food CreateNewFood(string name, string description, int price, int foodTypeId)
        {
            Food food = new Food();
            food.Name = name;
            food.Description = description;
            food.Price = price;
            food.FoodTypeID = foodTypeId;

            return food;
        }
    }
}