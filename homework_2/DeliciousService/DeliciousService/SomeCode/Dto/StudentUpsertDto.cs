using System.Text.Json.Serialization;

namespace DeliciousService.SomeCode.Dto
{
    /// <summary>
    /// Используем одну DTO для всех операций
    /// </summary>
    public record StudentUpsertDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    
}