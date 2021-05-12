using System;
using System.Threading.Tasks;
using DeliciousService.SomeCode.Dto;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace DeliciousService.SomeCode
{
    public class StudentsStorage
    {
        public static async Task<int> Create(StudentUpsertDto student)
        {
            await using NpgsqlConnection connect = new NpgsqlConnection(Postgres.ConnectionString);
            string sql = "insert into students (first_name, last_name, age) values (@firstName, @lastName, @age) RETURNING id";

            await using NpgsqlCommand cmd = new NpgsqlCommand(sql, connect);
            cmd.Parameters.AddWithValue("firstName", student.FirstName);
            cmd.Parameters.AddWithValue("lastName", student.LastName);
            cmd.Parameters.AddWithValue("age", student.Age);

            await connect.OpenAsync();
            return (int) await cmd.ExecuteScalarAsync();
        }

        public static async Task<int> Update(int studentId, StudentUpsertDto student)
        {
            var sql = "update students set first_name=@firstName, last_name=@lastName, age=@age where id=@id";

            await using NpgsqlConnection connect = new NpgsqlConnection(Postgres.ConnectionString);
            await using NpgsqlCommand cmd = new NpgsqlCommand(sql, connect);

            cmd.Parameters.AddWithValue("id", studentId);
            cmd.Parameters.AddWithValue("firstName", student.FirstName);
            cmd.Parameters.AddWithValue("lastName", student.LastName);
            cmd.Parameters.AddWithValue("age", student.Age);

            await connect.OpenAsync();
            await cmd.ExecuteNonQueryAsync();

            return studentId;
        }

        public static async Task Delete(int studentId)
        {
            await using NpgsqlConnection connect = new NpgsqlConnection(Postgres.ConnectionString);
            string sql = "delete from students where id=@id";

            await using NpgsqlCommand cmd = new NpgsqlCommand(sql, connect);
            cmd.Parameters.AddWithValue("id", studentId);

            await connect.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }

        public static async Task<StudentDto> Get(int studentId)
        {
            await using NpgsqlConnection connect = new NpgsqlConnection(Postgres.ConnectionString);
            string sql = "select * from students where id=@id";

            await using NpgsqlCommand cmd = new NpgsqlCommand(sql, connect);
            cmd.Parameters.AddWithValue("id", studentId);

            await connect.OpenAsync();

            await using NpgsqlDataReader reader = cmd.ExecuteReader();

            if (!await reader.ReadAsync())
                return null;

            return new StudentDto()
            {
                Id = (int) reader["id"],
                FirstName = (string) reader["first_name"],
                LastName = (string) reader["last_name"],
                Age = (int) reader["age"],
            };
        }
    }
}