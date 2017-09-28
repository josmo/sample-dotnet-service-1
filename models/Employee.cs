
using System.ComponentModel.DataAnnotations;

namespace NancyService.models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public int Age { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
    }
}