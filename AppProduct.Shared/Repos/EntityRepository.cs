using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppProduct.Models;

namespace AppProduct.Shared.Repos
{
    public abstract class EntityRepository : IRepo
    {
        private List<EntityModel> _entities;
        public abstract void Create(EntityModel entity);
        public abstract void Delete(EntityModel delete);
        public abstract List<EntityModel> Read();

        public abstract void Update (EntityModel entity);

        protected List<EntityModel> Entities { get => _entities; set => _entities = value; }
        public EntityRepository()
        {
            _entities = new List<EntityModel>();
        }
    }

}
