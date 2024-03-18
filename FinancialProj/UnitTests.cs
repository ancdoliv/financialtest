using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace FinancialProj
{


    [TestClass]
    public class SqlServerInstrumentRepositoryTests
    {
        private const string TestConnectionString = "Data Source=127.0.0.1;Initial Catalog=financialDB;User ID=financialUser;Password=123456test;";

        [TestMethod]
        public void InsertFinancialInstrument_ShouldInsertInstrumentIntoDatabase()
        {           
            var repository = new SqlServerInstrumentRepository(TestConnectionString);
            
            repository.InsertFinancialInstrument(1000000, "Stock");            
            
            var insertedInstrument = GetLastInsertedInstrument();
            Assert.IsNotNull(insertedInstrument);
            Assert.AreEqual(1000000, insertedInstrument.MarketValue);
            Assert.AreEqual("Stock", insertedInstrument.Type);
        }

        [TestMethod]
        public void SelectFinancialInstruments_ShouldReturnListOfInstrumentsFromDatabase()
        {           
            var repository = new SqlServerInstrumentRepository(TestConnectionString);
            
            var instruments = repository.SelectFinancialInstruments();
            
            Assert.IsNotNull(instruments);
            Assert.AreEqual(4, instruments.Count); 
        }

        [TestMethod]
        public void DeleteFinancialInstrument_ShouldDeleteInstrumentFromDatabase()
        {         
            var repository = new SqlServerInstrumentRepository(TestConnectionString);
         
            repository.DeleteFinancialInstrument(1);
            
            var deletedInstrument = GetInstrumentById(1);
            Assert.IsNull(deletedInstrument);
        }

        [TestMethod]
        public void UpdateFinancialInstrument_ShouldUpdateInstrumentInDatabase()
        {            
            var repository = new SqlServerInstrumentRepository(TestConnectionString);
                     
            repository.UpdateFinancialInstrument(1, 2000000, "Bond");
                        
            var updatedInstrument = GetInstrumentById(1);
            Assert.IsNotNull(updatedInstrument);
            Assert.AreEqual(2000000, updatedInstrument.MarketValue);
            Assert.AreEqual("Bond", updatedInstrument.Type);
        }
                
        private FinancialInstrument GetLastInsertedInstrument()
        {
            using (var connection = new SqlConnection(TestConnectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT TOP 1 * FROM FinancialInstruments ORDER BY ID DESC", connection);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        double marketValue = Convert.ToDouble(reader["MarketValue"]);
                        string type = Convert.ToString(reader["Type"]);
                        return new FinancialInstrument(marketValue, type);
                    }
                }
            }
            return null;
        }

        private FinancialInstrument GetInstrumentById(int id)
        {
            using (var connection = new SqlConnection(TestConnectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM FinancialInstruments WHERE ID = @ID", connection);
                command.Parameters.AddWithValue("@ID", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        double marketValue = Convert.ToDouble(reader["MarketValue"]);
                        string type = Convert.ToString(reader["Type"]);
                        return new FinancialInstrument(marketValue, type);
                    }
                }
            }
            return null;
        }
    }

}
