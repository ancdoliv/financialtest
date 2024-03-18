using FinancialProj;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Data Source=127.0.0.1;Initial Catalog=financialDB;User ID=financialUser;Password=123456test;";

        IInstrumentCategorizer categorizer = new BasicInstrumentCategorizer();
        IInstrumentRepository repository = new SqlServerInstrumentRepository(connectionString);

        //Data Input
        repository.InsertFinancialInstrument(800000, "Stock");
        repository.InsertFinancialInstrument(1500000, "Bond");
        repository.InsertFinancialInstrument(6000000, "Derivative");
        repository.InsertFinancialInstrument(300000, "Stock");

        List<FinancialInstrument> instruments = repository.SelectFinancialInstruments();

        List<InstrumentCategory> instrumentCategories = new List<InstrumentCategory>();
        foreach (var instrument in instruments)
        {
            InstrumentCategory category = categorizer.Categorize(instrument);
            instrumentCategories.Add(category);
        }

        //Data Output:
        Console.WriteLine("Instrument Categories:");
        foreach (var category in instrumentCategories)
        {
            Console.WriteLine(category);
        }
    }
}