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
    public class BasketXmlRepository:EntityRepository
    {
        private string _fileName;
        /// <summary>
        /// Создать репозиторий
        /// </summary>
        /// <param name="fileName">Путь к файлу</param>
        public BasketXmlRepository(string fileName) : base()
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
            if (!(entity is BasketModel)) return;



            Entities.Add(entity);



            var baskets = new List<BasketDto>();
            foreach (var e in Entities)
                baskets.Add(new BasketDto(e as BasketModel));

            var xmlSerializer = new XmlSerializer(typeof(List<BasketDto>));
            using (var fs = new FileStream(_fileName, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, baskets);
                fs.Close();
            }
        }



        public override void Delete(EntityModel delete)
        {
            if (!(delete is BasketModel)) return;
            for (var i = 0; i < Entities.Count; i++)
            {
                if (Entities[i].Id == delete.Id)
                    Entities.RemoveAt(i);
            }

            var baskets = new List<BasketDto>();
            foreach (var e in Entities)
                baskets.Add(new BasketDto(e as BasketModel));

            var xmlSerializer = new XmlSerializer(typeof(List<BasketDto>));
            using (var fs = new FileStream(_fileName, FileMode.Create))
            {
                xmlSerializer.Serialize(fs, baskets);
                fs.Close();
            }

        }



        public override List<EntityModel> Read()
        {
            var baskets = new List<BasketDto>();
            var xmlSerializer = new XmlSerializer(typeof(List<BasketDto>));
            using (var fs = new FileStream(_fileName, FileMode.OpenOrCreate))
            {
                baskets = xmlSerializer.Deserialize(fs) as List<BasketDto> ?? new List<BasketDto>();
                fs.Close();
            };

            Entities.Clear();
            foreach (var b in baskets)
                Entities.Add(new BasketModel(b));
            return Entities;
        }



        public override void Update(EntityModel entity)
        {
            if (!(entity is BasketModel)) return;
            for (var i = 0; i < Entities.Count; i++)
            {
                if (Entities[i].Id == entity.Id)
                    Entities[i] = entity;
            }

            var baskets = new List<BasketDto>();
            foreach (var e in Entities)
                baskets.Add(new BasketDto(e as BasketModel));

            var xmlSerializer = new XmlSerializer(typeof(List<BasketDto>));
            using (var fs = new FileStream(_fileName, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, baskets);
                fs.Close();
            }

        }
    }
}

