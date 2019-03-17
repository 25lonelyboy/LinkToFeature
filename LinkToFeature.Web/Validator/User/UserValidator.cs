using FluentValidation;
using LinkToFeature.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkToFeature.Web.Validator
{
    public class UserValidator: AbstractValidator<UserModel>
    {
        public UserValidator()
        {
            RuleFor(user => user.Name).NotNull().MinimumLength(5);
        }
    }
}