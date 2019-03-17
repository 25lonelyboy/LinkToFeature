using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkToFeature.Core.Entity
{
    public class User : CustomEntity
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public bool? Sex { get; set; }
    }
}
