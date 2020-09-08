using AutoMapper;
using GameStoreBLL.Filters;
using GameStoreBLL.Services;
using GameStoreBLL.Services.Abstraction;
using GameStoreClietUI.Helper;
using GameStoreClietUI.Models;
using GameStoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameStoreUI.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGameService gameService;
        private readonly IDeveloperService devService;
        private readonly IGenreService genreService;
        private readonly IMapper mapper;
        public GamesController(IGameService service, IMapper _mapper,IDeveloperService _devService,IGenreService _genreService)
        {
            gameService = service;
            mapper = _mapper;
            devService = _devService;
            genreService = _genreService;
        }
        // GET: Games
        public ActionResult Index(string type,string name)
        {
            SetFilters();
            List<Game> games = null;
            if (type != null & name != null)
            {
                AddFilter(type,name);
               games= gameService.FilterGames(Session["GameFilters"] as List<GamesFilter>).ToList();
                
            }
            else games = gameService.GetAllGames().ToList();


            //var gamesViewModel = mapper.Map<IEnumerable<GameCreateViewModel>>(games);


            var gamesViewModel = new List<GameCreateViewModel>();
            foreach (var item in games)
            {
                if (item.Image.Contains("https"))
                {

                
                gamesViewModel.Add(new GameCreateViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Price=item.Price,
                    Image =item.Image,
                    Developer = item.Developer.Name,
                    Genre = item.Genre.Name,
                    Year = item.Year
                }
              );
                }
                else
                {

                    gamesViewModel.Add(new GameCreateViewModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        Price = item.Price,
                        Image = Config.Domain + "Images/Games/" + item.Image,
                        Developer = item.Developer.Name,
                        Genre = item.Genre.Name,
                        Year = item.Year
                    });
                }
                
            }

            return View(gamesViewModel);
        }
        public ActionResult Start()
        {
             var games = gameService.GetAllGames().ToList();


            var gamesViewModel = mapper.Map<IEnumerable<GameCreateViewModel>>(games);

            return View(gamesViewModel);
        }
        [HttpGet]
        public ActionResult Filter(string type, string name)
        {
            List<Game> games = null;
            if (type != null & name != null)
            {
                AddFilter(type, name);
                games = gameService.FilterGames(Session["GameFilters"] as List<GamesFilter>).ToList();
            }
            else games = gameService.GetAllGames().ToList();


            var gamesViewModel = mapper.Map<IEnumerable<GameCreateViewModel>>(games);

            return PartialView("Partial/GamesPartial",gamesViewModel);
        }
        [HttpGet]
        public ActionResult Search(string search)
        {
            var games = gameService.GetAllGames().Where(x => x.Name.Contains(search) || x.Developer.Name.Contains(search));
            var gamesViewModel = mapper.Map<IEnumerable<GameCreateViewModel>>(games);


            if (gamesViewModel.Count()>0)
            {
                return RedirectToAction("Index", gamesViewModel);
            }

            return HttpNotFound();
        }
        private void AddFilter(string type,string name)
        {
            
            if(Session["GameFilters"]==null)
            {
                Session["GameFilters"] = new List<GamesFilter>();
            }
            var filters = Session["GameFilters"] as List<GamesFilter>;
            var IsExsists = filters.FirstOrDefault(x => x.Name == name && x.Type == type);
            if (IsExsists != null)
            {
                filters.Remove(IsExsists);
                Session["GameFilters"] = filters;
                return;
            }
            
            var filter = new GamesFilter
            {
                Name = name,
                Type = type
            };
            if (type == "Developer")
            {
                filter.Predicat = (x => x.Developer.Name == name);
                    }
            else if(type=="Genre")
            {
                filter.Predicat = (x => x.Genre.Name == name);
            }
            filters.Add(filter);
            Session["GameFilters"] = filters;
            //(Session["GameFilters"] as List<GamesFilter>).Add(filter);
        }

        private void SetFilters()
        {
            ViewBag.Developers = gameService.GetAllDevelopers();
            ViewBag.Genres = gameService.GetAllGenres();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
           var gameImagetoDel= gameService.GetGame(id);
            if (!gameImagetoDel.Image.Contains("https"))
                System.IO.File.Delete(Server.MapPath(Config.GameImagePath) + "\\" + gameImagetoDel.Image);
            gameService.Delete(id);
            
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Developers = gameService.GetAllDevelopers();
            ViewBag.Genres = gameService.GetAllGenres();
            gameService.GetAllGames();

            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

            var game = gameService.GetGame(id);
            if (!game.Image.Contains("https"))
                System.IO.File.Delete(Server.MapPath(Config.GameImagePath) + "\\" + game.Image);
            SetFilters();

            return View(mapper.Map<GameCreateViewModel>(game));
        }
        [HttpPost]
        public ActionResult Edit(GameCreateViewModel model, HttpPostedFileBase imageFile)
        {
            SetFilters();
            if (ModelState.IsValid)
            {

                string fileName = Guid.NewGuid().ToString() + ".jpg";

                string fullPathImage = Server.MapPath(Config.GameImagePath) + "\\" + fileName;
                using (Bitmap bmp = new Bitmap(imageFile.InputStream))
                {
                    var readyImage = ImageWorker.CreateImage(bmp, 450, 450);
                    if (readyImage != null)
                    {
                        readyImage.Save(fullPathImage, ImageFormat.Jpeg);
                        var game = mapper.Map<Game>(model);
                        game.Image = fileName;

                        //game.Developer = devService.GetDevelopers().First(x => x.Name == model.Developer);
                        //game.Genre = genreService.GetGenres().First(x => x.Name == model.Genre);

                        game.DeveloperId = devService.GetDevelopers().First(x => x.Name == model.Developer).Id;
                        game.GenreId = genreService.GetGenres().First(x => x.Name == model.Genre).Id;

                        gameService.Update(game);

                    }
                }
           
                return RedirectToAction("Index");

            }
            return Edit(model.Id);
        }
        [HttpPost]
        public ActionResult Create(GameCreateViewModel model, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                string fileName = Guid.NewGuid().ToString() + ".jpg";

                string fullPathImage = Server.MapPath(Config.GameImagePath) + "\\" + fileName;
                using (Bitmap bmp = new Bitmap(imageFile.InputStream))
                {
                    var readyImage =ImageWorker.CreateImage(bmp, 450, 450);
                    if (readyImage != null)
                    {
                        readyImage.Save(fullPathImage, ImageFormat.Jpeg);
                        var game = mapper.Map<Game>(model);
                        game.Image = fileName;
                        gameService.AddGame(game);
                    }
                }
            
            return RedirectToAction("Index");
            }
            return Create();
        }
    }
}