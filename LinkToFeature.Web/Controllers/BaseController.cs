using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace LinkToFeature.Web.Controllers
{
    public class BaseController : Controller
    {
        [Dependency]
        public IMapper Mapper { get; set; }

        [Dependency]
        public MapperConfiguration MapperConfig { get; set; }
    }
}