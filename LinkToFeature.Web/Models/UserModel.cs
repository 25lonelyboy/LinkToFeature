using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LinkToFeature.Web.Models
{
    public class UserModel
    {
        [DisplayName("编号")]
        public int ID { get; set; }

        [DisplayName("姓名")]
        public string Name { get; set; }
    }
}