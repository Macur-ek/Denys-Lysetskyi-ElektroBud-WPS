using System;
using System.Collections.Generic;
using System.Text;

namespace Denys_Lysetskyi_ElektroBud.Models
{
    public class StockOperation
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; } = "";

        public string OperationType { get; set; } = "";

        public decimal Quantity { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public string Comment { get; set; } = "";
    }
}
