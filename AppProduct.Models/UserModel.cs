using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProduct.Models
{
    public class UserModel:EntityModel
    {
        public UserModel() : base() { }
        public UserModel(string id) : base(id) { }
        public UserModel(UserDto u) : base(u)
        {
        }

    }
    public class UserDto : EntityDto
    {
        public string PassportData { get; set; }

        public UserDto(UserModel u) : base(u)
        {
        }
        public UserDto() : base()
        {
        }
    }
}
