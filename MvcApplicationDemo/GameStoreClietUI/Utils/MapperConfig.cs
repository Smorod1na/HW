using AutoMapper;
using GameStoreClietUI.Models;
using GameStoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameStoreClietUI.Utils
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            //Game => GameViewModel
            CreateMap<Game, GameCreateViewModel>().
                ForMember(x => x.Genre, y => y.MapFrom(z => z.Genre.Name)).
                ForMember(x => x.Developer, y => y.MapFrom(z => z.Developer.Name));
            //GameViewModel => Game
            CreateMap<GameCreateViewModel, Game>().
                ForMember(x => x.Genre, y => y.MapFrom(z => new Genre { Name = z.Genre })).
                                ForMember(x => x.Developer, y => y.MapFrom(z => new Developer { Name = z.Developer }));
            //
            CreateMap<Developer, DeveloperCreateViewModel>();
            //
            CreateMap<DeveloperCreateViewModel,Developer>();
        }
    }
}