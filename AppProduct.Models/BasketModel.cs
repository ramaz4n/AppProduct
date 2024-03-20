using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppProduct.Models
{
    public class BasketModel : EntityModel
    {
        public string ProductId { get; set; }
        public int Count { get; set; }
        public string ClientId { get; set; }
        public BasketModel() : base() { }
        public BasketModel(string id) : base(id) { }
        public BasketModel(BasketDto bs) : base(bs)
        {
            ProductId = bs.ProductId;
            Count = bs.Count;
            ClientId = bs.ClientId;
        }
    }

    public class BasketDto : EntityDto
    {
        public string ProductId { get; set; }
        public int Count { get; set; }
        public string ClientId { get; set; }

        public BasketDto(BasketModel bs) : base(bs)
        {
           ProductId = bs.ProductId;
            Count = bs.Count;
            ClientId = bs.ClientId;
        }
        public BasketDto() : base()
        {
        }
    }
}
