using Microsoft.EntityFrameworkCore;
using study_project.db;
using study_project.model;

namespace study_project.repository.impl
{
    public class CustomerRepository : ICustomerRepository, IDisposable
    {
        private DatabaseContext context;

        public CustomerRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public void DeleteCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Customer> getCustomer()
        {
            return context.customer.ToList();
        }

        public Customer getCustomerById(int customerId)
        {
            throw new NotImplementedException();
        }

        public void InsertCustomer(Customer customer)
        {
            context.customer.Add(customer);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            context.Entry(customer).State = EntityState.Modified;
        }
    }
}
