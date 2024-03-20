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
    public class PriceXmlRepository:EntityRepository
    {
        private string _fileName;
        /// <summary>
        /// Создать репозиторий
        /// </summary>
        /// <param name="fileName">Путь к файлу</param>
        public PriceXmlRepository(string fileName) : base()
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
            if (!(entity is PriceRate)) return;



            Entities.Add(entity);



            var prices = new List<PriceDto>();
            foreach (var e in Entities)
                prices.Add(new PriceDto (e as PriceRate));

            var xmlSerializer = new XmlSerializer(typeof(List<PriceDto>));
            using (var fs = new FileStream(_fileName, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, prices);
                fs.Close();
            }
        }



        public override void Delete(EntityModel delete)
        {
            if (!(delete is PriceRate)) return;
            for (var i = 0; i < Entities.Count; i++)
            {
                if (Entities[i].Id == delete.Id)
                    Entities.RemoveAt(i);
            }

            var prices = new List<PriceDto>();
            foreach (var e in Entities)
                prices.Add(new PriceDto(e as PriceRate));

            var xmlSerializer = new XmlSerializer(typeof(List<PriceDto>));
            using (var fs = new FileStream(_fileName, FileMode.Create))
            {
                xmlSerializer.Serialize(fs, prices);
                fs.Close();
            }

        }



        public override List<EntityModel> Read()
        {
            var prices = new List<PriceDto>();
            var xmlSerializer = new XmlSerializer(typeof(List<PriceDto>));
            using (var fs = new FileStream(_fileName, FileMode.OpenOrCreate))
            {
                prices = xmlSerializer.Deserialize(fs) as List<PriceDto> ?? new List<PriceDto>();
                fs.Close();
            };

            Entities.Clear();
            foreach (var p in prices)
                Entities.Add(new PriceRate(p));
            return Entities;
        }



        public override void Update(EntityModel entity)
        {
            if (!(entity is PriceRate)) return;
            for (var i = 0; i < Entities.Count; i++)
            {
                if (Entities[i].Id == entity.Id)
                    Entities[i] = entity;
            }

            var prices = new List<PriceDto>();
            foreach (var e in Entities)
                prices.Add(new PriceDto(e as PriceRate));

            var xmlSerializer = new XmlSerializer(typeof(List<PriceDto>));
            using (var fs = new FileStream(_fileName, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, prices);
                fs.Close();
            }

        }
    }
}

