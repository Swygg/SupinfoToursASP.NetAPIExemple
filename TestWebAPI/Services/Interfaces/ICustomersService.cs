using TestWebAPI.Models.DTO;
using TestWebAPI.Models.Inputs.Customer;

namespace TestWebAPI.Services.Interfaces
{
    public interface ICustomersService
    {
        public void Initiate();

        public void Add(CustomerCreateInput input);

        public void Update(CustomerUpdateInput input);

        public void Delete(int id);

        public Customer ReadOne(int id);

        public List<Customer> ReadAll();
    }
}
