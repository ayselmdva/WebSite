using AutoMapper;
using FinalWebsite.Business.Services.Abstract;
using FinalWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Repositories.Abstract;

namespace FinalWebsite.Business.Services.Concrete
{
    public class ShoppingMenecer : IShoppingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShoppingMenecer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int DecrementCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count -= count;
            return shoppingCart.Count;
        }

        public int IncrementCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count += count;
            return shoppingCart.Count;
        }
    }
}
