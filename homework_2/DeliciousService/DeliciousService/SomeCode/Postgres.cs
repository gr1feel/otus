using System;
using System.Threading.Tasks;
using Npgsql;

namespace DeliciousService.SomeCode
{
    public class Postgres
    {
        public static string ConnectionString = Environment.GetEnvironmentVariable("DATABASE_URI");

        private const string CreateTableSql = @"
                    create table students
                    (
                        id serial
                    constraint students_pk
                    primary key,
                        first_name varchar(250),
                    last_name varchar(250),
                    age int
                    );
                    insert into students (first_name, last_name, age) values ('Михаил', 'Сидоров', 28);
                    insert into students (first_name, last_name, age) values ('Семен', 'Смирнов', 35);
                    insert into students (first_name, last_name, age) values ('Руслан', 'Попов', 35);
                    ";
        
        private static async Task<bool> IsTableExists(string tableName)
        {
            try
            {
                await using NpgsqlConnection connect = new NpgsqlConnection(ConnectionString);
                await using NpgsqlCommand cmd = new NpgsqlCommand($"SELECT * FROM information_schema.tables WHERE table_name = '{tableName}'", connect);
                await connect.OpenAsync();
                await using var reader = await cmd.ExecuteReaderAsync();

                return reader.HasRows;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static async Task Migrate()
        {
            if (await IsTableExists("students"))
                return;

            try
            {
                await using NpgsqlConnection connect = new NpgsqlConnection(ConnectionString);
                await connect.OpenAsync();

                await using NpgsqlCommand cmd = new NpgsqlCommand(CreateTableSql, connect);
                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }
    }
}