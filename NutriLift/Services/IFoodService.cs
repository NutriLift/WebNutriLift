using NutriLift.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NutriLift.Services
{
    public interface IFoodService
    {
        List<FoodNameModel> GetAllFoods();
        Task UpdateFoodAsync(FoodNameModel foodModel);
        FoodNameModel GetFoodById(Guid id);
        bool FoodNameExists(Guid id);
        Task DeleteFoodAsync(Guid id);
        Task CreateFoodAsync(FoodNameModel foodModel);
    }
}
