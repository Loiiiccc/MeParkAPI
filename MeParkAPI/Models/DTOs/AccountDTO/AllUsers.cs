namespace MeParkAPI.Models.DTOs.AccountDTO
{
    public class AllUsers
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public IList<Vehicle> Vehicles { get; set; }
    }
}
