namespace ABM_Customer.Business.DTO
{
    public class CustomerDTO
    {
        public int id { get; set; }
        public string email { get; set; } = null!;
        public string first { get; set; } = null!;
        public string last { get; set; } = null!;
        public string company { get; set; } = null!;
        public DateTime created { get; set; }
        public string country { get; set; } = null!;
    }
}
