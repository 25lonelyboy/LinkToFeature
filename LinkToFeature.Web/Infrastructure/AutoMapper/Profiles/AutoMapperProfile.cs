using AutoMapper;
using LinkToFeature.Core.Entity;
using LinkToFeature.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkToFeature.Web.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
        }
    }
}