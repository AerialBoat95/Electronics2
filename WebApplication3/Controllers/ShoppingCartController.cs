﻿using Microsoft.AspNetCore.Mvc;
using ElectronicsStore.Models;
using ElectronicsStore.Repository;

namespace ElectronicsStore.Controllers
{

    public class ShoppingCartController : Controller
    {
        private IProductRepository<Product> productrepository;
        private ShoppingCartRepository shoppingcartrepository;


        public ShoppingCartController(IProductRepository<Product> productrepo, ShoppingCartRepository shoppingcartrepo)
        {
            productrepository = productrepo;
            shoppingcartrepository = shoppingcartrepo;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new ShoppingCartIndexViewModel
            {
                ShoppingCart = shoppingcartrepository.GetShoppingCart(),
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToCart(int productid, string returnUrl)
        {
            Product product = productrepository.GetById(productid);
            shoppingcartrepository.AddItem(product, 1);

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int cartlineid, string returnUrl)
        {
            shoppingcartrepository.RemoveItem(cartlineid);

            return RedirectToAction("Index", new { returnUrl });
        }
    }
}