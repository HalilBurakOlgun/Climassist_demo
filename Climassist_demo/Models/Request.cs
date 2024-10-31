namespace Climassist_demo.Models
{
    public class Request
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string CompanyType { get; set; }
        public string Phone { get; set; }
        public string RequestType { get; set; }
        public string SparePart { get; set; }
        public string RecoveryTime { get; set; }
        public string UnitType { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Status { get; set; } = "pending";
    }
}
