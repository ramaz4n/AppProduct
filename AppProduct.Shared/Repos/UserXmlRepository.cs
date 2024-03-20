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
    public class UserXmlRepository:EntityRepository
    {
        private string _fileName;
        /// <summary>
        /// Создать репозиторий
        /// </summary>
        /// <param name="fileName">Путь к файлу</param>
        public UserXmlRepository(string fileName) : base()
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
            if (!(entity is UserModel)) return;



            Entities.Add(entity);



            var users = new List<UserDto>();
            foreach (var e in Entities)
                users.Add(new UserDto(e as UserModel));

            var xmlSerializer = new XmlSerializer(typeof(List<UserDto>));
            using (var fs = new FileStream(_fileName, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, users);
                fs.Close();
            }
        }



        public override void Delete(EntityModel delete)
        {
            if (!(delete is UserModel)) return;
            for (var i = 0; i < Entities.Count; i++)
            {
                if (Entities[i].Id == delete.Id)
                    Entities.RemoveAt(i);
            }

            var users = new List<UserDto>();
            foreach (var e in Entities)
                users.Add(new UserDto(e as UserModel));

            var xmlSerializer = new XmlSerializer(typeof(List<UserDto>));
            using (var fs = new FileStream(_fileName, FileMode.Create))
            {
                xmlSerializer.Serialize(fs, users);
                fs.Close();
            }

        }



        public override List<EntityModel> Read()
        {
            var users = new List<UserDto>();
            var xmlSerializer = new XmlSerializer(typeof(List<UserDto>));
            using (var fs = new FileStream(_fileName, FileMode.OpenOrCreate))
            {
                users = xmlSerializer.Deserialize(fs) as List<UserDto> ?? new List<UserDto>();
                fs.Close();
            };

            Entities.Clear();
            foreach (var u in users)
                Entities.Add(new UserModel(u));
            return Entities;
        }



        public override void Update(EntityModel entity)
        {
            if (!(entity is UserModel)) return;
            for (var i = 0; i < Entities.Count; i++)
            {
                if (Entities[i].Id == entity.Id)
                    Entities[i] = entity;
            }

            var users = new List<UserDto>();
            foreach (var e in Entities)
                users.Add(new UserDto(e as UserModel));

            var xmlSerializer = new XmlSerializer(typeof(List<UserDto>));
            using (var fs = new FileStream(_fileName, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, users);
                fs.Close();
            }

        }
    }
}
