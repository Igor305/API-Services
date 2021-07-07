#nullable disable

namespace DataAccessLayer.Entities.Exchange
{
    public partial class PrivateEntrepreneur
    {
        public byte[] Idrref { get; set; }
        public byte[] Version { get; set; }
        public string Code1C { get; set; }
        public string Name { get; set; }
        public string TaxationScheme { get; set; }
        public string CodeEgrpou { get; set; }
        public string FullName { get; set; }
        public string HeadCounterparty { get; set; }
    }
}
