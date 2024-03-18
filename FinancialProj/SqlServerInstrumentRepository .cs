using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialProj
{
    class SqlServerInstrumentRepository : IInstrumentRepository
    {
        private readonly string _connectionString;

        public SqlServerInstrumentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void InsertFinancialInstrument(double marketValue, string type)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO FinancialInstruments (MarketValue, Type) VALUES (@MarketValue, @Type)", connection);
                command.Parameters.AddWithValue("@MarketValue", marketValue);
                command.Parameters.AddWithValue("@Type", type);
                command.ExecuteNonQuery();
            }
        }

        public List<FinancialInstrument> SelectFinancialInstruments()
        {
            var instruments = new List<FinancialInstrument>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM FinancialInstruments", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        double marketValue = Convert.ToDouble(reader["MarketValue"]);
                        string type = Convert.ToString(reader["Type"]);
                        instruments.Add(new FinancialInstrument(marketValue, type));
                    }
                }
            }
            return instruments;
        }

        public void DeleteFinancialInstrument(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM FinancialInstruments WHERE ID = @ID", connection);
                command.Parameters.AddWithValue("@ID", id);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateFinancialInstrument(int id, double marketValue, string type)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("UPDATE FinancialInstruments SET MarketValue = @MarketValue, Type = @Type WHERE ID = @ID", connection);
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@MarketValue", marketValue);
                command.Parameters.AddWithValue("@Type", type);
                command.ExecuteNonQuery();
            }
        }

        public FinancialInstrument GetInstrumentById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
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
