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
    public class GenresController : Controller
    {
        private readonly IGenreService genreService;

        private readonly IMapper mapper;
        public GenresController(IMapper _mapper, IGenreService _developerService)
        {
            genreService = _developerService;
            mapper = _mapper;
        }

        public ActionResult Index()
        {
            var developers = genreService.GetGenres().ToList();
            var developersMap = new List<GenreCreateViewModel>();

            foreach (var item in developers)
            {
                developersMap.Add(new GenreCreateViewModel
                {
                    Name = item.Name,
                    Id = item.Id
                });
            }
            return View(developersMap);
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(GenreCreateViewModel developer)
        {
            if (ModelState.IsValid)
            {
                var dev = new Genre
                {
                    Name = developer.Name

                };
                genreService.AddGenre(dev);
                //var games = gameService.GetAllGames();
                return RedirectToAction("Index");
            }
            return Create();
        }
        [HttpPost]
        public ActionResult Delete(string name, int id)
        {
            genreService.DeleteGenre(name, id);
            return RedirectToAction("Index");
        }
    }
}