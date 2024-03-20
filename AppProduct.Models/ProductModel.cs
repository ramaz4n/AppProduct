using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProduct.Models
{
    public class ProductModel:EntityModel
    {
        public ProductModel() : base() { }
        public ProductModel(string id) : base(id) { }
        public void Print()
        {
            Console.WriteLine(Name + " " + Id);
        }
        public ProductModel(ProductDto p) : base(p)
        {
        }
    }
    public class ProductDto : EntityDto
    {
        public ProductDto(ProductModel c) : base(c)
        {
        }
        public ProductDto() : base()
        {
        }
    }
}
