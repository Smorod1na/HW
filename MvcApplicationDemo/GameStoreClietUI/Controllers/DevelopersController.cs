using AutoMapper;
using GameStoreBLL.Services.Abstraction;
using GameStoreClietUI.Models;
using GameStoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameStoreClietUI.Controllers
{
    public class DevelopersController : Controller
    {
        private readonly IDeveloperService developerService;

        private readonly IMapper mapper;
        public DevelopersController(IMapper _mapper,IDeveloperService _developerService)
        {
            developerService = _developerService;
            mapper = _mapper;
        }
        // GET: Developers
        public ActionResult Index()
        {
            var developers = developerService.GetDevelopers().ToList();
            //var developersMap = mapper.Map<IEnumerable<DeveloperCreateViewModel>>(developers);
            var developersMap = new List<DeveloperCreateViewModel>();

            foreach (var item in developers)
            {
                developersMap.Add(new DeveloperCreateViewModel
                {
                    Name = item.Name,
                    Id=item.Id
                });
            }
            return View(developersMap);
        }
        [HttpGet ]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(DeveloperCreateViewModel developer)
        {
            if (ModelState.IsValid)
            {
                var dev = new Developer
                {
                    Name=developer.Name
                    
                };
                developerService.AddDeveloper(dev);
                //var games = gameService.GetAllGames();
                return RedirectToAction("Index");
            }
            return Create();
        }
        [HttpPost]
        public ActionResult Delete(string name,int id)
        {
            developerService.DeleteDevelopers(name, id);
            return RedirectToAction("Index");
        }
    }
}