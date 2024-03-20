using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppProduct.Models;
using AppProduct.Shared.Repos;

namespace AppProduct.Shared
{
    public class SeedData
    {
        private static IRepo _productsRepo;
        public static IRepo ProductsRepo
        {
            get
            {
                if (_productsRepo != null) return _productsRepo;
                _productsRepo = new ProductXmlRepository("Products.txt");
                return _productsRepo;
            }
        }

        private static ProductModel[] _products;
        public static ProductModel[] Products
        {
            get
            {
                if (_products != null) return _products;
                _products[0] = new ProductModel()
                {
                    Name = "Молоко",
                };
                _products[1] = new ProductModel()
                {
                    Name = "Сок",
                };
                _products[2] = new ProductModel()
                {
                    Name = "Чай",
                };
                _products[3] = new ProductModel()
                {
                    Name = "Яблоки",
                };
                _products[4] = new ProductModel()
                {
                    Name = "Персики",
                };
                _products[5] = new ProductModel()
                {
                    Name = "Черешня",
                };
                _products[6] = new ProductModel()
                {
                    Name = "Шоколад",
                };
                _products[7] = new ProductModel()
                {
                    Name = "Конфеты",
                };
                _products[8] = new ProductModel()
                {
                    Name = "Колбаса",
                };
                _products[9] = new ProductModel()
                {
                    Name = "Сосиски",
                };
                return _products;
            }
        }


        private static IRepo _clientsRepo;
        public static IRepo ClientsRepo
        {
            get 
            { 
               if(_clientsRepo!=null) return _clientsRepo;
               _clientsRepo = new ClientXmlRepository("Clients.txt");
                return _clientsRepo;
            }
        }
        private static ClientModel[] _clients;

        public static ClientModel[] Clients
        {
            // ( паттерн синглтон)

            get
            {
                if (_clients != null) return _clients;

                _clients[0] = new ClientModel()
                {
                    Name = "Катя",
                    PassportData = "123 456 выдан УФМС по г.Казани"
                };

                _clients[1] = new ClientModel()
                {
                    Name = "Юля",
                    PassportData = "123 456 выдан УФМС по г.Казани"
                };

                _clients[2] = new ClientModel()
                {
                    Name = "Саша",
                    PassportData = "123 456 выдан УФМС по г.Казани"
                };

                _clients[3] = new ClientModel()
                {
                    Name = "Игорь",
                    PassportData = "123 456 выдан УФМС по г.Казани"
                };

                _clients[5] = new ClientModel()
                {
                    Name = "Олег",
                    PassportData = "123 456 выдан УФМС по г.Казани"
                };
                return _clients;
            }
        }

        private static IRepo _usersRepo;
        public static IRepo UsersRepo
        {
            get
            {
                if (_usersRepo != null) return _usersRepo;
                _usersRepo = new UserXmlRepository("Users.txt");
                return _usersRepo;
            }
        }

        private static UserModel[] _users;
        public static UserModel[] Users
        {
            get
            {
                if (_users != null) return _users;
                
                _users[0] = new UserModel()
                {
                    Name = "Гордеева Екатерина Игоревна"
                };
                _users[1] = new UserModel()
                {
                    Name = "Хамидуллина Юлия Рафаэлевна"
                };
                _users[2] = new UserModel()
                {
                    Name = "Эмзанова Анфиса Владимировна"
                };
                return _users;
            }
        }

        private static IRepo _priceratesRepo;
        public static IRepo PriceRatesRepo
        {
            get
            {
                if (_priceratesRepo != null) return _priceratesRepo;
                _priceratesRepo = new PriceXmlRepository("PriceRates.txt");
                return _priceratesRepo;
            }
        }

        private static PriceRate[] _pricerates;
        public static PriceRate[] PriceRates
        {
            get
            {
                if (_pricerates != null) return _pricerates;

                _pricerates[0] = new PriceRate()
                {
                    Value = "100 руб",
                    Data = "22 сентября",
                    ProductId = SeedData.Products[0].Id
                   
                };
                _pricerates[1] = new PriceRate()
                {
                    Value = "101 руб",
                    Data = "21 сентября",
                    ProductId = SeedData.Products[1].Id
                };
                _pricerates[2] = new PriceRate()
                {
                    Value = "102 руб",
                    Data = "20 сентября",
                    ProductId = SeedData.Products[2].Id
                };
                _pricerates[3] = new PriceRate()
                {
                    Value = "103 руб",
                    Data = "23 сентября",
                    ProductId = SeedData.Products[3].Id
                };
                _pricerates[4] = new PriceRate()
                {
                    Value = "104 руб",
                    Data = "25 сентября",
                    ProductId = SeedData.Products[4].Id
                };
                _pricerates[5] = new PriceRate()
                {
                    Value = "105 руб",
                    Data = "26 сентября",
                    ProductId = SeedData.Products[5].Id
                };
                _pricerates[6] = new PriceRate()
                {
                    Value = "106 руб",
                    Data = "27 сентября",
                    ProductId = SeedData.Products[6].Id
                };
                _pricerates[7] = new PriceRate()
                {
                    Value = "107 руб",
                    Data = "28 сентября",
                    ProductId = SeedData.Products[7].Id
                };
                _pricerates[8] = new PriceRate()
                {
                    Value = "108 руб",
                    Data = "29 сентября",
                    ProductId = SeedData.Products[8].Id
                };
                _pricerates[9] = new PriceRate()
                {
                    Value = "109 руб",
                    Data = "30 сентября",
                    ProductId = SeedData.Products[9].Id
                };
                return _pricerates;
            }
        }

        private static IRepo _basketsRepo;
        public static IRepo BasketsRepo
        {
            get
            {
                if (_basketsRepo != null) return _basketsRepo;
                _basketsRepo = new BasketXmlRepository("Baskets.txt");
                return _basketsRepo;
            }
        }

        private static BasketModel[] _baskets;
        public static BasketModel[] Baskets
        {
            get
            {
                if (_baskets != null) return _baskets;
                _baskets[0] = new BasketModel()
                {
                    ProductId = SeedData.Products[0].Id,
                    ClientId = SeedData.Clients[0].Id,
                    Count = 5
                };
                _baskets[1] = new BasketModel()
                {
                    ProductId = SeedData.Products[0].Id,
                    ClientId = SeedData.Clients[2].Id,
                    Count = 1
                };
                _baskets[2] = new BasketModel()
                {
                    ProductId = SeedData.Products[1].Id,
                    ClientId = SeedData.Clients[1].Id,
                    Count = 3
                };
                _baskets[3] = new BasketModel()
                {
                    ProductId = SeedData.Products[2].Id,
                    ClientId = SeedData.Clients[2].Id,
                    Count = 7
                };
                _baskets[4] = new BasketModel()
                {
                    ProductId = SeedData.Products[2].Id,
                    ClientId = SeedData.Clients[3].Id,
                    Count = 1
                };
                _baskets[5] = new BasketModel()
                {
                    ProductId = SeedData.Products[3].Id,
                    ClientId = SeedData.Clients[0].Id,
                    Count = 8
                };
                _baskets[6] = new BasketModel()
                {
                    ProductId = SeedData.Products[4].Id,
                    ClientId = SeedData.Clients[3].Id,
                    Count = 6
                };
                _baskets[7] = new BasketModel()
                {
                    ProductId = SeedData.Products[5].Id,
                    ClientId = SeedData.Clients[4].Id,
                    Count = 5
                };
                _baskets[8] = new BasketModel()
                {
                    ProductId = SeedData.Products[6].Id,
                    ClientId = SeedData.Clients[5].Id,
                    Count =2
                };
                _baskets[9] = new BasketModel()
                {
                    ProductId = SeedData.Products[7].Id,
                    ClientId = SeedData.Clients[2].Id,
                    Count = 2
                };
                _baskets[10] = new BasketModel()
                {
                    ProductId = SeedData.Products[8].Id,
                    ClientId = SeedData.Clients[5].Id,
                    Count = 4
                };
                _baskets[11] = new BasketModel()
                {
                    ProductId = SeedData.Products[9].Id,
                    ClientId = SeedData.Clients[0].Id,
                    Count = 1
                };
                _baskets[12] = new BasketModel()
                {
                    ProductId = SeedData.Products[10].Id,
                    ClientId = SeedData.Clients[1].Id,
                    Count = 3
                };
                _baskets[13] = new BasketModel()
                {
                    ProductId = SeedData.Products[0].Id,
                    ClientId = SeedData.Clients[2].Id,
                    Count = 8
                };
                _baskets[14] = new BasketModel()
                {
                    ProductId = SeedData.Products[0].Id,
                    ClientId = SeedData.Clients[3].Id,
                    Count = 1
                };
                _baskets[15] = new BasketModel()
                {
                    ProductId = SeedData.Products[1].Id,
                    ClientId = SeedData.Clients[4].Id,
                    Count = 5
                };
                _baskets[16] = new BasketModel()
                {
                    ProductId = SeedData.Products[2].Id,
                    ClientId = SeedData.Clients[5].Id,
                    Count = 7
                };
                return _baskets;

            }
        }
    }
}

