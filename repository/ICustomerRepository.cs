using study_project.model;

namespace study_project.repository
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> getCustomer();
        Customer getCustomerById(int customerId);
        void InsertCustomer(Customer customer);
        void DeleteCustomer(int customerId);
        void UpdateCustomer(Customer customer);
        void Save();
    }
}
