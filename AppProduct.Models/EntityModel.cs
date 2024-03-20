using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProduct.Models
{
    public abstract class EntityModel
    {
        public string Name { get; set; }
        public string Id { private set; get; }
        public EntityModel()
        {
            Id = Guid.NewGuid().ToString();
        }
        public EntityModel(string id)
        {
            Id = id ?? Guid.NewGuid().ToString("N");
        }
        public EntityModel(EntityDto edto)
        {
            Id = edto.Id;
            Name = edto.Name;
        }
    }
        public class EntityDto
        {
            public string Name { get; set; }
            public string Id { set; get; }

            public EntityDto(EntityModel e)
            {
                Name = e.Name;
                Id = e.Id;
            }
            public EntityDto()
            { 
            }
        }
    }

