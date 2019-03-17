using LinkToFeature.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using LinkToFeature.Web.Models;
using AutoMapper;
using LinkToFeature.Core.Entity;
using LinkToFeature.Web.Validator;

namespace LinkToFeature.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: User
        public ActionResult Index()
        {
            var users = userService.GetUsers();
            //使用依赖注入的方式
            //单个实例的时候
            //var result = mapper.Map<User, UserModel>(users);
            //集合的时候
            var result = users.AsQueryable().ProjectTo<UserModel>(MapperConfig);

            //使用静态方法的方式
            //使用依赖注入的方式
            //单个实例的时候
            //var result = mapper.Map<User, UserModel>(users);
            //集合的时候
            //var result = users.AsQueryable().ProjectTo<UserModel>(Mapper.Configuration);

            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserModel user)
        {
            if (ModelState.IsValid)
            {

            }
            return View(user);
        }
    }
}