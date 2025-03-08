using System.Data;
using Dapper;
using MySql.Data.MySqlClient;

namespace BlazorApp2.Data
{
    public class ContractsData
    {
        readonly string ConnectionString = $"Server=localhost;User Id=dodnet; Password=DoDnetPass*6785%; Database=dodnet_mysql";
        public async Task<List<Contract>> GetOrdersAsync()
        {
            Console.WriteLine("Получение таблицы");
            string Query = "SELECT * FROM contracts;";
            using (IDbConnection Connection = new MySqlConnection(ConnectionString))
            {
                Connection.Open();
                List<Contract> orders = Connection.Query<Contract>(Query).ToList();
                Console.WriteLine("таблица получена");
                return orders;
            }
        }
        public async Task AddOrderAsync(Contract Value)
        {
            string query = "INSERT INTO contracts(ID, ClientEmail, PropertyID, ContractDate) VALUES(@ID, @ClientEmail, @PropertyID, @ContractDate)";
            using (IDbConnection Connection = new MySqlConnection(ConnectionString))
            {
                Connection.Open();
                await Connection.ExecuteAsync(query, Value);
            }
        }

        public async Task UpdateOrderAsync(Contract Value)
        {
            string query = "UPDATE contracts SET ClientEmail = @ClientEmail, PropertyID = @PropertyID, ContractDate=@ContractDate WHERE ID = @ID";
            using (IDbConnection Connection = new MySqlConnection(ConnectionString))
            {
                Connection.Open();
                await Connection.ExecuteAsync(query, Value);
            }
        }

        public async Task RemoveOrderAsync(int? Key)
        {
            string query = "DELETE FROM contracts WHERE ID = @Название";
            using (IDbConnection Connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    await Connection.ExecuteAsync(query, new { Название = Key });
                    Console.WriteLine($"Удаление "); // Для диагностики
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ОШИБКА УДАЛЕНИЯ: {ex.Message}");
                    throw;
                }
            }
        }
    }
}
