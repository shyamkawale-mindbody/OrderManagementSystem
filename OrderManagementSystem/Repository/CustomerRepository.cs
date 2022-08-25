using Application.Entities;

namespace OrderManagementSystem.Repository
{
    public class CustomerRepository : IServiceRepository<Customer, int>
    {
        IDataAccess<Customer, int> customerDataAccess;

        public CustomerRepository(IDataAccess<Customer, int> customerDataAccess)
        {
            this.customerDataAccess = customerDataAccess;
        }

        ResponseStatus<Customer> IServiceRepository<Customer, int>.CreateRecord(Customer entity)
        {
            ResponseStatus<Customer> response = new ResponseStatus<Customer>();
            try
            {
                response.Record = customerDataAccess.Create(entity);
                response.Message = "Customer created succesfully";
                response.StatusCode = 201;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Customer> IServiceRepository<Customer, int>.DeleteRecord(int id)
        {
            ResponseStatus<Customer> response = new ResponseStatus<Customer>();
            try
            {
                response.Record = customerDataAccess.Delete(id);
                response.Message = $"Customer with id: {id} deleted succesfully";
                response.StatusCode = 203;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Customer> IServiceRepository<Customer, int>.GetRecord(int id)
        {
            ResponseStatus<Customer> response = new ResponseStatus<Customer>();
            try
            {
                response.Record = customerDataAccess.Get(id);
                response.Message = $"Customer with id: {id} read succesfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Customer> IServiceRepository<Customer, int>.GetRecords()
        {
            ResponseStatus<Customer> response = new ResponseStatus<Customer>();
            try
            {
                response.Records = customerDataAccess.Get();
                response.Message = $"All Customers read succesfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Customer> IServiceRepository<Customer, int>.UpdateRecord(int id, Customer entity)
        {
            ResponseStatus<Customer> response = new ResponseStatus<Customer>();
            try
            {
                response.Record = customerDataAccess.Update(id, entity);
                response.Message = $"Customer with id: {id} updated succesfully";
                response.StatusCode = 204;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
    }
}
