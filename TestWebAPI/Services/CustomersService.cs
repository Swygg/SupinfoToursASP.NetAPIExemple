using AutoMapper;
using Microsoft.Extensions.Options;
using TestWebAPI.DAL;
using TestWebAPI.Models.DTO;
using TestWebAPI.Models.Inputs.Customer;
using TestWebAPI.Services.Interfaces;

namespace TestWebAPI.Services
{
    public class CustomersService : ICustomersService
    {
        protected DbFactoryContext _db;

        private readonly IMapper _mapper;
        private readonly ILogger<DbFactoryContext> _logger;

        public CustomersService(ILogger<DbFactoryContext> logger, DbFactoryContext db, IMapper mapper)
        {
            _logger = logger;
            _db = db;
            _mapper = mapper;
        }

        ~CustomersService()
        {
            _db.Dispose();
        }

        public void Initiate()
        {
            /*
            this.Add(new Customer() { FirstName = "Vincent", LastName = "Altur" });
            this.Add(new Customer("Edith", "Marlou"));
            this.Add(new Customer("Julie", "Slash"));
            this.Add(new Customer("Josh", "Rand"));
            */
        }

        public void Add(CustomerCreateInput input)
        {
            var item = _mapper.Map<Customer>(input);
            //var item = new Customer() { FirstName = "Raoul", LastName = "Ortega" };
            _db.Customers.Add(item);
            _db.SaveChanges();
        }

        public void Update(CustomerUpdateInput input)
        {
            var item = _mapper.Map<Customer>(input);
            _db.Customers.Update(item);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = ReadOne(id);
            if (item == null)
                return;
            _db.Customers.Remove(item);
            _db.SaveChanges();
        }

        public Customer ReadOne(int id)
        {
            return _db.Customers.FirstOrDefault(x => x.Id == id);
        }

        public List<Customer> ReadAll()
        {
            _logger.LogError("Error");
            _logger.LogCritical("Critical");
            _logger.LogWarning("Warning");
            _logger.LogTrace("Trace");
            _logger.LogDebug("Debug");
            _logger.LogInformation("Information");
            return _db.Customers.ToList();
        }
    }
}