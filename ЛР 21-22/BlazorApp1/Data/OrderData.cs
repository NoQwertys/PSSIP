using System.Data;
using Dapper;
using MySql.Data.MySqlClient;



namespace Grid_Dapper.Data
{
    public class OrderData
    {
        readonly string ConnectionString = $"Server=127.0.0.1;Port=3306;database=mydb;user id=root;password=MySQLPass6685%";
        public async Task<List<Order>> GetOrdersAsync()
        {
            Console.WriteLine("Получение таблицы");
            string Query = "SELECT * FROM Поставщик;";
            using (IDbConnection Connection = new MySqlConnection(ConnectionString))
            {
                Connection.Open();
                List<Order> orders = Connection.Query<Order>(Query).ToList();
                Console.WriteLine("таблица получена");
                return orders;
            }
        }
        public async Task AddOrderAsync(Order Value)
        {
            string query = "INSERT INTO Поставщик(Название, Телефон, Почта, Адрес) VALUES(@Название, @Телефон, @Почта, @Адрес)";
            using (IDbConnection Connection = new MySqlConnection(ConnectionString))
            {
                Connection.Open();
                await Connection.ExecuteAsync(query, Value);
            }
        }

        public async Task UpdateOrderAsync(Order Value)
        {
            string query = "UPDATE Поставщик SET Телефон = @Телефон, Почта = @Почта, Адрес=@Адрес WHERE Название = @Название";
            using (IDbConnection Connection = new MySqlConnection(ConnectionString))
            {
                Connection.Open();
                await Connection.ExecuteAsync(query, Value);
            }
        }

        public async Task RemoveOrderAsync(string? Key)
        {
            string query = "DELETE FROM Поставщик WHERE Название = @Название";
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
    public class Order
    {
        public string? Название { get; set; }
        public string? Телефон { get; set; }
        public string? Почта { get; set; }
        public string? Адрес { get; set; }
    }
}