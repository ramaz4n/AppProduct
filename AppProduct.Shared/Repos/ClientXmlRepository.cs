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
    public class ClientXmlRepository:EntityRepository
    {
        private string _fileName;
        /// <summary>
        /// Создать репозиторий
        /// </summary>
        /// <param name="fileName">Путь к файлу</param>
        public ClientXmlRepository(string fileName) : base()
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

            //File.Exists()
        }
        public override void Create(EntityModel entity)
        {
            foreach (var e in Entities)
                if (e.Id == entity.Id) return;
            if (!(entity is ClientModel)) return;



            Entities.Add(entity);



            var clients = new List<ClientDto>();
            foreach (var e in Entities)
                clients.Add(new ClientDto(e as ClientModel));

            var xmlSerializer = new XmlSerializer(typeof(List<ClientDto>));
            using (var fs = new FileStream(_fileName, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, clients);
                fs.Close();
            }
        }



        public override void Delete(EntityModel delete)
        {
            if (!(delete is ClientModel)) return;
            for (var i = 0; i < Entities.Count; i++)
            {
                if (Entities[i].Id == delete.Id)
                    Entities.RemoveAt(i);
            }

            var clients = new List<ClientDto>();
            foreach (var e in Entities)
                clients.Add(new ClientDto(e as ClientModel));

            var xmlSerializer = new XmlSerializer(typeof(List<ClientDto>));
            using (var fs = new FileStream(_fileName, FileMode.Create))
            {
                xmlSerializer.Serialize(fs, clients);
                fs.Close();
            }

        }



        public override List<EntityModel> Read()
        {

            //var sr = new StreamReader(_fileName);
            //var str = sr.ReadToEnd();
            var clients = new List<ClientDto>();
            var xmlSerializer = new XmlSerializer(typeof(List<ClientDto>));
            using (var fs = new FileStream(_fileName, FileMode.OpenOrCreate))
            {
                clients = xmlSerializer.Deserialize(fs) as List<ClientDto> ?? new List<ClientDto>();
                fs.Close();
            };

            Entities.Clear();
            foreach (var c in clients)
                Entities.Add(new ClientModel(c));
            return Entities;
        }



        public override void Update(EntityModel entity)
        {
            if (!(entity is ClientModel)) return;
            for (var i = 0; i < Entities.Count; i++)
            {
                if (Entities[i].Id == entity.Id)
                    Entities[i] = entity;
            }

            var clients = new List<ClientDto>();
            foreach (var e in Entities)
                clients.Add(new ClientDto(e as ClientModel));

            var xmlSerializer = new XmlSerializer(typeof(List<ClientDto>));
            using (var fs = new FileStream(_fileName, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, clients);
                fs.Close();
            }

        }
    }
}
