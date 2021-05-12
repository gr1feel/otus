using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using DeliciousService.SomeCode;
using DeliciousService.SomeCode.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace DeliciousService.Controllers
{
    [ApiController]
    [Route("db")]
    public class DatabaseController : ControllerBase
    {
        private readonly ILogger<DatabaseController> _logger;

        public DatabaseController(ILogger<DatabaseController> logger)
        {
            _logger = logger;
        }
        //
        // private const string ConnectionString =
        //     "User Id=myuser;Password=passwd;Host=192.168.64.151;Database=delicious;Integrated Security = False;Port=5432;";

        [HttpGet]
        [Route("students")]
        public async Task<List<StudentDto>> Get()
        {
            var connectionString = Environment.GetEnvironmentVariable("DATABASE_URI");

            await using NpgsqlConnection connect = new NpgsqlConnection(connectionString);
            await using NpgsqlCommand cmd = new NpgsqlCommand("select * from students order by id", connect);
            await connect.OpenAsync();
            await using var reader = await cmd.ExecuteReaderAsync();

            List<StudentDto> students = new List<StudentDto>();

            while (await reader.ReadAsync())
            {
                var student = new StudentDto()
                {
                    Id = (int) reader["id"],
                    FirstName = (string) reader["first_name"],
                    LastName = (string) reader["last_name"],
                    Age = (int) reader["age"]
                };

                students.Add(student);
            }

            return students;
        }
    }
}