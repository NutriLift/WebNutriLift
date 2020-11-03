using NutriLift.Data;
using NutriLift.Entities;
using NutriLift.Helpers;
using NutriLift.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NutriLift.Services
{
    //CRUD operation using data context/EntityFramework Core
    public class FoodService : AutoMapperBase,IFoodService
    {
        private readonly IRepository<FoodName> repository;

        public FoodService(IRepository<FoodName> repository)
        {
            this.repository = repository;
        }

        public async Task CreateFoodAsync(FoodNameModel foodModel)
        {
            // Convert FoodName model to FoodName Entity and add to DB
            var foodEntity = mapper.Map<FoodNameModel, FoodName>(foodModel);
            await repository.CreateAsync(foodEntity);
        }

        public async Task DeleteFoodAsync(Guid id)
        {
            await repository.DeleteAsync(id);   
        }

        public bool FoodNameExists(Guid id)
        {
            if (repository.GetById(id) != null)
                return true;
            return false;
        }

        public List<FoodNameModel> GetAllFoods()
        {
            var foodEntity = repository.GetAll();
            var foodModel = mapper.Map<List<FoodName>, List<FoodNameModel>>(foodEntity);
            return foodModel;
        }

        public FoodNameModel GetFoodById(Guid id)
        {
            var foodEntity = repository.GetById(id);
            var foodModel = mapper.Map<FoodName, FoodNameModel>(foodEntity);
            return foodModel;
        }

        public async Task UpdateFoodAsync(FoodNameModel foodModel)
        {
            //Convert FoodNameModel to FoodName entity
            var foodEntity = mapper.Map<FoodNameModel, FoodName>(foodModel);
            await repository.UpdateAsync(foodEntity);
        }
    }
}
