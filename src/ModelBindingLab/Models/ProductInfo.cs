using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelBindingLab.Models
{
    public class ProductInfo
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public Maker Maker { get; set; }
    }
}
