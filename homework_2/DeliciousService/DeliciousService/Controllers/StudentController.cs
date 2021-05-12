using System.Net;
using System.Threading.Tasks;
using DeliciousService.SomeCode;
using DeliciousService.SomeCode.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DeliciousService.Controllers
{
    [ApiController]
    [Route("student")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("{studentId}")]
        public Task<StudentDto> Get(int studentId)
        {
            return StudentsStorage.Get(studentId);
        }

        [HttpPut]
        [Route("{studentId}")]
        public Task<int> Put(int studentId, [FromBody] StudentUpsertDto student)
        {
            return StudentsStorage.Update(studentId, student);
        }

        [HttpPost]
        public Task<int> Post([FromBody] StudentUpsertDto student)
        {
            return StudentsStorage.Create(student);
        }

        [HttpDelete]
        [Route("{studentId}")]
        public async Task<string> Delete(int studentId)
        {
            await StudentsStorage.Delete(studentId);
            return "OK";
        }
    }
}