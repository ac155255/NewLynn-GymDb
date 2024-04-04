namespace NewLynn_GymDb.Models
{
    public class Attendence
    {
        public int AttendenceID { get; set; }
        public int MemberID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime AttendenceDate { get; set; }
        public string Status { get; set; }

        public ICollection<Member> Members { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
