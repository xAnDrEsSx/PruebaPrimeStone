namespace Test.Domain.Administration.ApplicationModel
{
    public class AddressResponseAM
    {
        public int Id { get; set; }
        public string NameAddress { get; set; }
        public string Alias { get; set; }
        public bool Active { get; set; }
    }

    public class AddressAM
    {
        public int Id { get; set; } = 0;
        public string NameAddress { get; set; }
        public string Alias { get; set; }
        public bool Active { get; set; } = true;
        public int IdStudent { get; set; }
    }

}
