using Microsoft.AspNetCore.DataProtection.KeyManagement;
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

        public async Task<bool> DeleteEntry(int Id)
        {
            Entry entry = mockDb[Id];
            mockDb.Remove(entry);
            return true;
        }

        public async Task<decimal> GetTotal()
        {
            decimal total = 0;
            foreach (var entry in mockDb)
            {
                total += entry.Amount;
            }
            return total;
        }
    }
}
