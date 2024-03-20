using AppProduct.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProduct.Shared.Repos
{
    public class PriceFileRepository: EntityRepository
    {
        private string _fileName;
        public PriceFileRepository(string fileName) : base()
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
                    var price = entity as PriceRate;
                    if (price == null) continue;
                    writer.WriteLine($"{price.Id} ; {price.Name} ; {price.Data} ; {price.ProductId} ; {price.Value}") ;
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
            var prices = new List<EntityModel>();
            using (var reader = new StreamReader(_fileName))
            {
                string priceStr = null;
                while ((priceStr = reader.ReadLine()) != null)
                {
                    var attrs = priceStr.Split(';');
                    if (attrs.Length < 5) continue;

                    prices.Add(new PriceRate(attrs[0])
                    {
                        Name = attrs[1],
                        Data = attrs[2],
                        ProductId = attrs[3],
                        Value = attrs[4]
                    });
                }
                reader.Close();
            }
            return Entities = prices;
        }

        public override void Update(EntityModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
