using System.ComponentModel.DataAnnotations;

namespace PLAService.Entities
{
    public class Person
    {
        [Key]
        public int Id { get; set; } 
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public required string City { get; set; }
        public required string Country { get; set; }
        public required string Eircode { get; set; }
        public required string PhoneNumber { get; set; }
        public required string EmailID { get; set; }
    }
}
