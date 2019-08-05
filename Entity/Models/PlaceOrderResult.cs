using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Models
{
    public class PlaceOrderResult
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public int? OrderId { get; set; }
    }
}
