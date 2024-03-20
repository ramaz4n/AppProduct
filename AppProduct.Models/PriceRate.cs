using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProduct.Models
{
    public class PriceRate:EntityModel
    {
        public string Value { get;  set; }
        public string Data { get; set; }
        public string ProductId { get; set; }
        public PriceRate() : base() { }
        public PriceRate(string id) : base(id) { }

        public PriceRate(PriceDto p) : base(p)
        {
           ProductId = p.ProductId;
            Data = p.Data;
            Value = p.Value;
        }
    }
    public class PriceDto : EntityDto
    {
        public string Value { get; set; }
        public string Data { get; set; }
        public string ProductId { get; set; }

        public PriceDto(PriceRate p) : base(p)
        {
           Value = p.Value;
            Data = p.Data;
            ProductId = p.ProductId;
        }
        public PriceDto() : base()
        {
        }
    }
}
