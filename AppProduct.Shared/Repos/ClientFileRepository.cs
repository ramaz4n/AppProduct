using AppProduct.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProduct.Shared.Repos
{
    public class ClientFileRepository : EntityRepository
    {
        private string _fileName;
        public ClientFileRepository(string fileName) : base()
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
                    var client = entity as ClientModel;
                    if (client == null) continue;
                    writer.WriteLine($"{client.Id} ; {client.Name} ; {client.PassportData};{client.Age}") ;
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
            var clients = new List<EntityModel>();
            using (var reader = new StreamReader(_fileName))
            {
                string clientStr = null;
                while ((clientStr = reader.ReadLine()) != null)
                {
                    var attrs = clientStr.Split(';');
                    if (attrs.Length < 4) continue;

                    clients.Add(new ClientModel(attrs[0])
                    {
                        Name = attrs[1],
                        PassportData = attrs[2],
                        Age = Convert.ToInt32(attrs[3])
                    }) ;
                }
                reader.Close();
            }
            return Entities = clients;
        }

        public override void Update(EntityModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
