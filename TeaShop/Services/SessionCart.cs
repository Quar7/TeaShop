using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaShop.Data.Entities;
using TeaShop.Data.Repositories;
using TeaShop.Helpers.Extensions;

namespace TeaShop.Services
{
    public class SessionCart : CartRepository
    {
        [JsonIgnore]
        public ISession Session { get; set; }

        public static CartRepository GetSessionCart(IServiceProvider services)
        {
            var session = services.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;
            var sessionCart = session.GetObjectFromJson<SessionCart>("Cart") ?? new SessionCart();
            sessionCart.Session = session;
            return sessionCart;
        }


        public override void AddCartLine(Tea tea, int quantity)
        {
            base.AddCartLine(tea, quantity);
            Session.SetObjectAsJson("Cart", this);
        }

        public override void DecreaseCartLineQuantity(Tea tea)
        {
            base.DecreaseCartLineQuantity(tea);
            Session.SetObjectAsJson("Cart", this);
        }

        public override void RemoveCartLine(Tea tea)
        {
            base.RemoveCartLine(tea);
            Session.SetObjectAsJson("Cart", this);
        }

        public override void ClearCart()
        {
            base.ClearCart();
            Session.Remove("Cart");
        }
    }
}
