namespace ABM_Customer.Business.Requests
{
    public class NewConsumer
    {
        public string email { get; set; } = null!;
        public string first { get; set; } = null!;
        public string last { get; set; } = null!;
        public string company { get; set; } = null!;
        public string country { get; set; } = null!;
    }
}
