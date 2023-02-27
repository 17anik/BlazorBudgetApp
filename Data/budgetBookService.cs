using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlazorBudgetApp.Data
{
    public class budgetBookService
    {
        private static List<Entry> mockDb = new List<Entry>()
        {
            new Entry(){Id=1,Description="Howgarts Legacy",Amount=3499m}
        };

        public async Task<bool> AddEntry(Entry newEntry)
        {
            mockDb.Add(newEntry);
            return true;
        }

        public async Task<List<Entry>> GetAllEntries()
        {
            return mockDb;
        }

        public async Task<Entry> GetEntryById(int Id) 
        {
            return mockDb.FirstOrDefault(e => e.Id == Id);
        }

        public async Task<bool> EditEntry(int Id, string? desc, decimal amt)
        {
            if (mockDb.First(e => e.Id ==Id) == null)
            {
                return false;
            }

            mockDb.FirstOrDefault(e => e.Id == Id).Description = desc;
            mockDb.FirstOrDefault(e => e.Id == Id).Amount = amt;

            return true;
        }

        public async Task<bool> DeleteEntry(int Id)
        {
            Entry entry = mockDb.FirstOrDefault(e => e.Id == Id);
            mockDb.Remove(entry);
            return true;
        }

        public async Task<decimal> GetTotal()
        {
            //decimal total = 0;
            //foreach (var entry in mockDb)
            //{
            //    total += entry.Amount;
            //}
            //return total;

            decimal total = 0;
            total = mockDb.Sum(e => e.Amount);
            return total;
        }
    }
}
