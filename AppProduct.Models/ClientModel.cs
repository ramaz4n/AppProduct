using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProduct.Models
{
    public class ClientModel : EntityModel
    {
        public string PassportData { get; set; }
        public ClientModel() : base() { }
        public ClientModel(string id) : base(id) { }
        public ClientModel(ClientDto cl) : base(cl)
        {
            PassportData = cl.PassportData;
            Age = cl.Age;
        }
        public int Age { get; set; }
    }
    public class ClientDto : EntityDto
    {
        public int Age { get; set; }
        public string PassportData { get; set; }

        public ClientDto(ClientModel c) : base(c)
        {
            PassportData = c.PassportData;
            Age = c.Age;
        }
        public ClientDto() : base()
        {
        }
    }
}
