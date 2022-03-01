namespace PeerislandXmlParsor.Models
{
    public class EmployeeDesignationModel : IEmployeeDesignationModel
    {
        public string Designation { get; set; }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
