namespace TestWebAPI.Models.Output.Customer
{
    public class CustomerOutput
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public CustomerOutput(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
