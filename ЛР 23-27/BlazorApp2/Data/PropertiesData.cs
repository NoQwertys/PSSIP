using System.Data;
using Dapper;
using MySql.Data.MySqlClient;

namespace BlazorApp2.Data
{
    public class PropertiesData
    {
        readonly string ConnectionString = $"Server=localhost;User Id=dodnet; Password=DoDnetPass*6785%; Database=dodnet_mysql";
        public async Task<List<Property>> GetOrdersAsync()
        {
            Console.WriteLine("Получение таблицы");
            string Query = "SELECT * FROM properties;";
            using (IDbConnection Connection = new MySqlConnection(ConnectionString))
            {
                Connection.Open();
                List<Property> orders = Connection.Query<Property>(Query).ToList();
                Console.WriteLine("таблица получена");
                return orders;
            }
        }
        public async Task AddOrderAsync(Property Value)
        {
            string query = "INSERT INTO properties(ID, Address, Type, Area, Rooms, Floor, Price, Status) VALUES(@ID, @Address, @Type, @Area, @Rooms, @Floor, @Price, @Status)";
            using (IDbConnection Connection = new MySqlConnection(ConnectionString))
            {
                Connection.Open();
                await Connection.ExecuteAsync(query, Value);
            }
        }

        public async Task UpdateOrderAsync(Property Value)
        {
            string query = "UPDATE properties SET Address = @Address, Type = @Type, Area = @Area, Rooms = @Rooms, Floor = @Floor, Price = @Price, Status = @Status WHERE ID = @ID";
            using (IDbConnection Connection = new MySqlConnection(ConnectionString))
            {
                Connection.Open();
                await Connection.ExecuteAsync(query, Value);
            }
        }

        public async Task RemoveOrderAsync(int? Key)
        {
            string query = "DELETE FROM properties WHERE ID = @Название";
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
