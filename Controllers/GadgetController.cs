using Microsoft.AspNetCore.Mvc;
using GadgetInventory.Models;
using System.Collections.Generic;

namespace GadgetInventory.Controllers
{
    public class GadgetController : Controller
    {
        private static List<Gadget> _gadgets = new List<Gadget>
        {
            new Gadget { Id = 1, Brand = "Apple", Model = "iPhone 15", Price = 799.00m },
            new Gadget { Id = 2, Brand = "Samsung", Model = "Galaxy S24", Price = 849.00m },
        };

        public IActionResult Index()
        {
            return View(_gadgets);
        }

        // GET: /Gadget/Create (Displays the blank form)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Gadget/Create (Processes the form submission)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Gadget newGadget)
        {
            if (!ModelState.IsValid)
            {
                return View(newGadget); // Return form with validation errors
            }

            newGadget.Id = _gadgets.Count + 1;
            _gadgets.Add(newGadget);

            return RedirectToAction("Index");
        }

    }
}