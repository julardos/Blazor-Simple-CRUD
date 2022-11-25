using System;
using TrustBoxes.Models;

namespace TrustBoxes.Data
{
    public class MasterService
    {
        custConnectoins custConnections = new custConnectoins();
        storedConnections storedConnections = new storedConnections();
        itemsConnections itemsConnections = new itemsConnections();
        public async Task<Customer[]> GetCustDetails(string CustName, String Email)
        {
            Customer[] custsObjs;
            custsObjs = custConnections.GetCustDetails(CustName, Email).Result.ToArray();
            return custsObjs;
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            Customer new_customer = new Customer();
            new_customer = custConnections.CreateCustomer(customer).Result;
            return new_customer;
        }

        public async Task<Customer> FindCustomer(int id)
        {
            Customer customer = new Customer();
            customer = custConnections.FindCustomer(id).Result;
            return customer;
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            return await custConnections.DeleteCustomer(id);
        }

        public async Task<Stored[]> GetStoreds()
        {
            Stored[] storeds;
            storeds = storedConnections.GetStoredDetails().Result.ToArray();
            return storeds;
        }

        public async Task<Stored> CreateStored(Stored stored)
        {
            Stored new_stored = new Stored();
            new_stored = storedConnections.CreateStored(stored).Result;
            return new_stored;
        }

        public async Task<Items[]> GetItems()
        {
            Items[] items;
            items = itemsConnections.GetItemsDetails().Result.ToArray();
            return items;
        }
    }
}

