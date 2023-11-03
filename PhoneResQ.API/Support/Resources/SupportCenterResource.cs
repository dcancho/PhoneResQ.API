namespace PhoneResQ.API.Support.Resources
{
    public class SupportCenterResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RUC { get; set; }
        public string Address { get; set; }
    }

    public class SaveSupportCenterResource
    {
        public string Name { get; set; }
        public string RUC { get; set; }
        public string Address { get; set; }
    }
}
