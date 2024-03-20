using AppProduct.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AppProduct.Shared.Repos
{
    public class ProductXmlRepository:EntityRepository
    {
        private string _fileName;
        /// <summary>
        /// Создать репозиторий
        /// </summary>
        /// <param name="fileName">Путь к файлу</param>
        public ProductXmlRepository(string fileName) : base()
        {
            _fileName = fileName;
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
            foreach (var e in Entities)
                if (e.Id == entity.Id) return;
            if (!(entity is ProductModel)) return;



            Entities.Add(entity);



            var products = new List<ProductDto>();
            foreach (var e in Entities)
                products.Add(new ProductDto(e as ProductModel));

            var xmlSerializer = new XmlSerializer(typeof(List<ProductDto>));
            using (var fs = new FileStream(_fileName, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, products);
                fs.Close();
            }
        }



        public override void Delete(EntityModel delete)
        {
            if (!(delete is ProductModel)) return;
            for (var i = 0; i < Entities.Count; i++)
            {
                if (Entities[i].Id == delete.Id)
                    Entities.RemoveAt(i);
            }

            var products = new List<ProductDto>();
            foreach (var e in Entities)
                products.Add(new ProductDto(e as ProductModel));

            var xmlSerializer = new XmlSerializer(typeof(List<ProductDto>));
            using (var fs = new FileStream(_fileName, FileMode.Create))
            {
                xmlSerializer.Serialize(fs, products);
                fs.Close();
            }

        }



        public override List<EntityModel> Read()
        {
            var products = new List<ProductDto>();
            var xmlSerializer = new XmlSerializer(typeof(List<ProductDto>));
            using (var fs = new FileStream(_fileName, FileMode.OpenOrCreate))
            {
                products = xmlSerializer.Deserialize(fs) as List<ProductDto> ?? new List<ProductDto>();
                fs.Close();
            };

            Entities.Clear();
            foreach (var c in products)
                Entities.Add(new ProductModel(c));
            return Entities;
        }



        public override void Update(EntityModel entity)
        {
            if (!(entity is ProductModel)) return;
            for (var i = 0; i < Entities.Count; i++)
            {
                if (Entities[i].Id == entity.Id)
                    Entities[i] = entity;
            }

            var products = new List<ProductDto>();
            foreach (var e in Entities)
                products.Add(new ProductDto(e as ProductModel));

            var xmlSerializer = new XmlSerializer(typeof(List<ProductDto>));
            using (var fs = new FileStream(_fileName, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, products);
                fs.Close();
            }

        }
    }
}
