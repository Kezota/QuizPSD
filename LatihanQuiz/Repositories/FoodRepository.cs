using LatihanQuiz.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace LatihanQuiz.Repositories
{
    public class FoodRepository
    {
        LatihanEntities3 db = new LatihanEntities3();

        public List<Food> GetFoods()
        {
            return db.Foods.ToList();
        }

        public Food GetFoodById(int id)
        {
            return db.Foods.FirstOrDefault(f => f.Id == id);
        }

        public void AddFood(Food food)
        {
            db.Foods.Add(food);
            db.SaveChanges();
        }

        public void UpdateFood(Food food)
        {
            //Food food = db.Foods.FirstOrDefault(f => f.Id == newFood.Id);

            //food.Name = newFood.Name;
            //food.Description = newFood.Description;
            //food.Price = newFood.Price;
            //food.FoodTypeID = newFood.FoodTypeID;

            //db.SaveChanges();

            db.Foods.AddOrUpdate(food);
        }

        public void DeleteFoodById(int id)
        {
            Food food = db.Foods.FirstOrDefault(f => f.Id == id);

            if (food == null) return;

            db.Foods.Remove(food);
            db.SaveChanges();
        }
    }
}