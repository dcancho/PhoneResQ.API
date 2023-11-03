namespace PhoneResQ.API.Support.Resources
{
    public class CustomerResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class SaveCustomerResource
    {
        public string Name { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}
