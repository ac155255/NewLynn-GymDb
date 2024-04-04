namespace NewLynn_GymDb.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int MemberID { get; set; }
        public int EmployeeID { get; set; }
        public string Amount{ get; set; }
        public string PaymentMethod { get; set; }
        public DateTime TransactionDate { get; set; }

        public ICollection<Member> Members { get; set; }
        public ICollection<Employee> Employees { get; set; }

    }
}
