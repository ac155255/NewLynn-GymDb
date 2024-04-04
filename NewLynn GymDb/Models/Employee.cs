namespace NewLynn_GymDb.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public DateTime HireDate { get; set; }
        public string? Address { get; set; }
        public string Position { get; set; }
        public string Email{ get; set; }
        public string PhoneNumber { get; set; }
        public string Salary { get; set; }

        
    }

    
}
