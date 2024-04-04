namespace NewLynn_GymDb.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string DateOfBirth{ get; set; }
        public string MembershipType { get; set; }
        public string JoinDate{ get; set;}
        public string PaymentInformation { get; set; }

        public ICollection<Transaction> Transactions{ get; set; }
      

        public Member(string paymentInformation)
        {
            PaymentInformation = paymentInformation;
        }
    }
}
