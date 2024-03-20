using System;
using System.Collections.Generic;
using System.IO;
using AppProduct.Shared;
using AppProduct.Models;

namespace AppProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            var clients = new List<ClientModel>()
            {
                new ClientModel(){Name = "суета", Age = 19 },
                new ClientModel(){Name = "Юля", Age = 20 },
                new ClientModel(){Name = "Дима" , Age = 22 },
                new ClientModel(){Name = "Лена", Age = 23  },
                new ClientModel(){Name = "Анфиса" , Age = 30},
                new ClientModel(){Name = "Рома" , Age = 46},
                new ClientModel(){Name = "Костя" , Age = 15},
                new ClientModel(){Name = "Ирина" , Age = 17},
                new ClientModel(){Name = "Альбина", Age = 32 },
                new ClientModel(){Name = "Даша", Age = 27 }
            };
            foreach (var i in clients) { SeedData.ClientsRepo.Create(i); }

            var products = new List<ProductModel>()
            {
            new ProductModel(){ Name = "Молоко"},
            new ProductModel(){ Name = "Сок"},
            new ProductModel(){ Name = "Чай"},
            new ProductModel(){ Name = "Сахар"},
            new ProductModel(){ Name = "Шоколад"},
            new ProductModel(){ Name = "Масло"},
            new ProductModel(){ Name = "Гречка"},
            new ProductModel(){ Name = "Рис"},
            new ProductModel(){ Name = "Хлеб"},
            new ProductModel(){ Name = "Огурцы"}
            };

            foreach (var i in products) { SeedData.ProductsRepo.Create(i); }

            var pricerates = new List<PriceRate>()
            {
                new PriceRate(){ ProductId = "e0632566-dbf3-4109-812e-9899bd862f44",Value = "75" },
                new PriceRate(){ ProductId = "c2314eaf-9455-49bb-b861-4d9bde615515",Value = "150" },
                new PriceRate(){ ProductId = "a422bebc-e8ff-49e2-ac23-d93ee0e0dec9",Value = "225" },
                new PriceRate(){ ProductId = "b2f9473a-58f7-4acd-985a-2e72997a8672",Value = "100" },
                new PriceRate(){ ProductId = "54fe0dc7-6677-4d8a-a378-85dfa1ff8fa1",Value = "72" },
                new PriceRate(){ ProductId = "3cc82e9b-72b0-4ce1-a91b-c1ef08d5eb83",Value = "55" },
                new PriceRate(){ ProductId = "a88ac42c-fa88-4958-a2fd-dd41430fbe8b",Value = "110" },
                new PriceRate(){ ProductId = "a4a643c9-8577-4680-ae79-935ba7d4e754",Value = "90" },
                new PriceRate(){ ProductId = "1e7f7ba8-0a85-44aa-989e-0b27e3f496b8",Value = "45" },
                new PriceRate(){ ProductId = "c3adcbee-156b-42bf-8eb6-3f8cea2b0fff",Value = "23" }
            };
            foreach (var i in pricerates) { SeedData.PriceRatesRepo.Create(i); }
        }
        
    }
}
