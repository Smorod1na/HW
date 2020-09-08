﻿using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using GameStoreBLL.Services;
using GameStoreBLL.Services.Abstraction;
using GameStoreDAL.Repository.Abstraction;
using GameStoreDAL.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameStoreDAL;
using GameStoreClietUI;
using AutoMapper;
using GameStoreClietUI.Utils;

namespace GameStoreUI.Utils
{
    public static class AutofacConfiguration
    {
        public static void ConfigurateAutofac()
        {
            //1.Builder
            //2.Register all controllers in assembly
            //3.Register types 
            //4.Resolve build container
            //5.start this method

            //1)
            var builder = new ContainerBuilder();
            //2)
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //3)
            builder.RegisterType<AplicationContext>().As<DbContext>().SingleInstance();
            builder.RegisterGeneric(typeof(EFRepository<>)).As(typeof(IGenericRepository<>));
            builder.RegisterType<GameService>().As<IGameService>();
            builder.RegisterType<DeveloperService>().As<IDeveloperService>();


            builder.RegisterType<GenreService>().As<IGenreService>();

            //Registr mapper
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MapperConfig()));
            builder.RegisterInstance<IMapper>(mapperConfig.CreateMapper());

            //4)
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }
    }
}