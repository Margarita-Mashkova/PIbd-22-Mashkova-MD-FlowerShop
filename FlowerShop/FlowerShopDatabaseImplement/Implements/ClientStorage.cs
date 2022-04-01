using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShopConracts.StoragesContracts;
using FlowerShopConracts.ViewModels;
using FlowerShopConracts.BindingModels;
using FlowerShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace FlowerShopDatabaseImplement.Implements
{
    public class ClientStorage : IClientStorage 
    {
        //TODO: исправить
        public List<ClientViewModel> GetFullList()
        {
            using var context = new FlowerShopDatabase();
            return context.Clients
                .Select(CreateModel)
                .ToList();
        }
        public List<ClientViewModel> GetFilteredList(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new FlowerShopDatabase();
            return context.Clients
            .Include(rec => rec.Orders) ///////////
            .Where(rec => rec.Email == model.Email)
            .Select(CreateModel)
            .ToList();
        }
        public ClientViewModel GetElement(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new FlowerShopDatabase();
            var client = context.Clients
            .Include(rec => rec.Orders) //////////
            .FirstOrDefault(rec => rec.Email == model.Email || rec.Id == model.Id); //////////
            return client != null ? CreateModel(client) : null;
        }
        public void Insert(ClientBindingModel model)
        {
            using var context = new FlowerShopDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                context.Clients.Add(CreateModel(model, new Client()));
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Update(ClientBindingModel model)
        {
            using var context = new FlowerShopDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Delete(ClientBindingModel model)
        {
            using var context = new FlowerShopDatabase();
            Client element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Clients.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Client CreateModel(ClientBindingModel model, Client client)
        {
            client.ClientFIO = model.ClientFIO;
            client.Email = model.Email;
            client.Password = model.Password;
            return client;
        }
        private static ClientViewModel CreateModel(Client client)
        {
            return new ClientViewModel
            {
                Id = client.Id,
                ClientFIO = client.ClientFIO,
                Email = client.Email,
                Password = client.Password
            };
        }
    }
}
