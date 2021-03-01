using System;
using System.Collections.Generic;
using System.Linq;

namespace BehaviorDrivenDevelopment.Service
{
    public interface IPricingService
    {
        decimal GetBasketTotalAmount(Basket basket);
    }
    
    public class PricingService : IPricingService
    {
        public decimal GetBasketTotalAmount(Basket basket)
        {
            if (!basket.Products.Any())
            {
                return 0;
            }

            var basketValue = basket.Products.Sum(x => x.Price);

            if (basket.User.IsLoggedIn)
            {
                return basketValue - (basketValue * 0.05m);
            }

            return basketValue;
        }
    }

    public class Basket
    {
        public User User { get; init; }
        public List<Product> Products { get; } = new();
    }

    public class Product
    {
        public string Name { get; init; }
        
        public decimal Price { get; init; }
    }

    public class User
    {
        public bool IsLoggedIn { get; set; }
    }
}