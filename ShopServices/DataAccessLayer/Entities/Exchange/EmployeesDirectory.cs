#nullable disable

namespace DataAccessLayer.Entities.Exchange
{
    public partial class EmployeesDirectory
    {
        public string PersonnelNumber { get; set; }
        public string FullName { get; set; }
        public string Subdivision { get; set; }
        public string Position { get; set; }
        public bool WorksNow { get; set; }
        public byte[] Idrref { get; set; }
        public byte[] Version { get; set; }
        public string Inn { get; set; }
    }
}
