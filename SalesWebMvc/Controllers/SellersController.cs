using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]//Indicando que a ação é de post e não de get
        [ValidateAntiForgeryToken]//anotação para não sofre ataque CSRF
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);//Inserindo o cadastro no Seller
            return RedirectToAction(nameof(Index));//redirecionando para o Index
        }
    }
}
