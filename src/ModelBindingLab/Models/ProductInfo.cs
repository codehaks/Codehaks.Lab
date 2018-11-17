using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelBindingLab.Models
{
    [Bind("name,maker.name")]
    public class ProductInfo
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public Maker Maker { get; set; }
    }
}
