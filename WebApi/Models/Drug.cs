using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Drug
    {
        public string Code { get; set; }

        public string Label { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}

