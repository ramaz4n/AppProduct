using AppProduct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProduct.Shared.Repos
{
    public interface IRepo
    {
        void Create(EntityModel entity);
        List<EntityModel> Read();
        void Update(EntityModel entity);
        void Delete(EntityModel entity);
    }
}
