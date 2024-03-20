using AppProduct.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProduct.Shared.Repos
{
    public class ProductFileRepository : EntityRepository
    {
        private string _fileName;
        public ProductFileRepository(string fileName) : base()
        {
            _fileName = fileName;
            if (!File.Exists(_fileName))
            {
                using (var writer = new StreamWriter(_fileName))
                {
                    writer.WriteLine(" ");
                    writer.Close();
                }
            }
        }
        public override void Create(EntityModel entity)
        {
            for (var i = 0; i < Entities.Count; i++)
            {
                if (Entities[i].Id == entity.Id)
                    return;
            }
            Entities.Add(entity);
            WriteToFile();
        }



        private void WriteToFile()
        {
            using (var writer = new StreamWriter(_fileName))
            {
                foreach (var entity in Entities)
                {
                    var product = entity as ProductModel;
                    if (product == null) continue;
                    writer.WriteLine($"{product.Id} ; {product.Name}");
                }
                writer.Close();
            }
        }



        public override void Delete(EntityModel delete)
        {
            throw new NotImplementedException();
        }


        public override List<EntityModel> Read()
        {
            var products = new List<EntityModel>();
            using (var reader = new StreamReader(_fileName))
            {
                string productStr = null;
                while ((productStr = reader.ReadLine()) != null)
                {
                    var attrs = productStr.Split(';');
                    if (attrs.Length < 2) continue;

                    products.Add(new ProductModel(attrs[0])
                    {
                        Name = attrs[1]
                    });
                }
                reader.Close();
            }
            return Entities = products;
        }

        public override void Update(EntityModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
