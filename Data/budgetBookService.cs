namespace BlazorBudgetApp.Data
{
    public class budgetBookService
    {
        private static List<Entry> mockDb = new List<Entry>()
        {
            new Entry(){Description="Howgarts Legacy",Amount=3499m}
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
    }
}
