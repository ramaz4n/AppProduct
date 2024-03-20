using AppProduct.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProduct.Shared.Repos
{
    public class BasketFileRepository: EntityRepository
    {
        private string _fileName;
        public BasketFileRepository(string fileName) : base()
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
                    var basket = entity as BasketModel;
                    if (basket == null) continue;
                    writer.WriteLine($"{basket.Id} ; {basket.Name} ; {basket.ProductId} ; {basket.Count} ; {basket.ClientId}");
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
            var baskets = new List<EntityModel>();
            using (var reader = new StreamReader(_fileName))
            {
                string basketStr = null;
                while ((basketStr = reader.ReadLine()) != null)
                {
                    var attrs = basketStr.Split(';');
                    if (attrs.Length < 5) continue;

                    baskets.Add(new BasketModel(attrs[0])
                    {
                        Name = attrs[1],
                        ProductId = attrs[2],
                        Count = Convert.ToInt32(attrs[3]),
                        ClientId = attrs[4],
                    }); 
                }
                reader.Close();
            }
            return Entities = baskets;
        }

        public override void Update(EntityModel entity)
        {
            throw new NotImplementedException();
        }
    }
}

