using AppProduct.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProduct.Shared.Repos
{
    public class UserFileRepository: EntityRepository
    {
        private string _fileName;
        public UserFileRepository(string fileName) : base()
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
                    var user = entity as UserModel;
                    if (user == null) continue;
                    writer.WriteLine($"{user.Id} ; {user.Name}");
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
            var users = new List<EntityModel>();
            using (var reader = new StreamReader(_fileName))
            {
                string userStr = null;
                while ((userStr = reader.ReadLine()) != null)
                {
                    var attrs = userStr.Split(';');
                    if (attrs.Length < 2) continue;

                    users.Add(new UserModel(attrs[0])
                    {
                        Name = attrs[1]
                    });
                }
                reader.Close();
            }
            return Entities = users;
        }

        public override void Update(EntityModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
