namespace ABM_Customer.Services
{
    public class CustomerData
    {
        public int id { get; set; }
        public string email { get; set; } = null!;
        public string first { get; set; } = null!;
        public string last { get; set; } = null!;
        public string company { get; set; } = null!;
        public string created_at { get; set; } = null!;
        public string country { get; set; } = null!;

    }
}
