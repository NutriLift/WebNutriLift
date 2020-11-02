using Microsoft.EntityFrameworkCore;
using NutriLift.Data;
using NutriLift.Entities;
using NutriLift.Helpers;
using NutriLift.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutriLift.Services
{
    //CRUD operation using data context/EntityFramework Core
    public class FoodService : AutoMapperBase,IFoodService
    {
        private readonly NutriLiftContext context;

        public FoodService(NutriLiftContext context)
        {
            this.context = context;
        }

        public async Task CreateFoodAsync(FoodNameModel foodModel)
        {
            // Convert FoodName model to FoodName Entity and add to DB
            var foodEntity = mapper.Map<FoodNameModel, FoodName>(foodModel);
            context.FoodName.Add(foodEntity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteFoodAsync(Guid id)
        {
            // Fetch the record by ID
            var foodEntity = await context.FoodName.FirstOrDefaultAsync(m => m.FN_PK == id);
            //If record exists, remove it from the FoodName entity
            if (foodEntity != null)
            {
                context.FoodName.Remove(foodEntity);
                await context.SaveChangesAsync();
            }
        }

        public bool FoodNameExists(Guid id)
        {
            if (context.FoodName.FirstOrDefault(m => m.FN_PK == id) != null)
                return true;
            return false;
        }

        public async Task<List<FoodNameModel>> GetAllFoodsAsync()
        { 
            var foodEntity = await context.FoodName.ToListAsync();
            var foodModel = mapper.Map<List<FoodName>, List<FoodNameModel>>(foodEntity);
            return foodModel;
        }

        public async Task<FoodNameModel> GetFoodByIdAsync(Guid id)
        {
            var foodEntity = await context.FoodName.FirstOrDefaultAsync(m => m.FN_PK == id);
            var foodModel = mapper.Map<FoodName, FoodNameModel>(foodEntity);
            return foodModel;
        }

        public async Task UpdateFoodAsync(FoodNameModel foodModel)
        {
            //Convert FoodNameModel to FoodName entity
            var foodEntity = mapper.Map<FoodNameModel, FoodName>(foodModel);
            //Update state to modified so that the record is marked as dirty and save changes
            context.Attach(foodEntity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
