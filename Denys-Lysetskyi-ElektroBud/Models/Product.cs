using System;
using System.Collections.Generic;
using System.Text;

namespace Denys_Lysetskyi_ElektroBud.Models
{
        public class Product
        {
            public int Id { get; set; }

            public string Name { get; set; } = "";

            public string Unit { get; set; } = "szt.";

            public decimal Quantity { get; set; }

            public decimal MinimumQuantity { get; set; }

            public decimal Price { get; set; }
        }
}
