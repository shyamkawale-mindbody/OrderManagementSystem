namespace OrderManagementSystem.Repository
{
    public class OrderRepository : IServiceRepository<Order, int>
    {
        IDataAccess<Order, int> orderDataAccess;

        public OrderRepository(IDataAccess<Order, int> orderDataAccess)
        {
            this.orderDataAccess = orderDataAccess;
        }

        ResponseStatus<Order> IServiceRepository<Order, int>.CreateRecord(Order entity)
        {
            ResponseStatus<Order> response = new ResponseStatus<Order>();
            try
            {
                response.Record = orderDataAccess.Create(entity);
                response.Message = "Order created succesfully";
                response.StatusCode = 201;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Order> IServiceRepository<Order, int>.DeleteRecord(int id)
        {
            ResponseStatus<Order> response = new ResponseStatus<Order>();
            try
            {
                response.Record = orderDataAccess.Delete(id);
                response.Message = $"Order with id: {id} deleted succesfully";
                response.StatusCode = 203;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Order> IServiceRepository<Order, int>.GetRecord(int id)
        {
            ResponseStatus<Order> response = new ResponseStatus<Order>();
            try
            {
                response.Record = orderDataAccess.Get(id);
                response.Message = $"Order with id: {id} read succesfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Order> IServiceRepository<Order, int>.GetRecords()
        {
            ResponseStatus<Order> response = new ResponseStatus<Order>();
            try
            {
                response.Records = orderDataAccess.Get();
                response.Message = $"All Orders read succesfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Order> IServiceRepository<Order, int>.UpdateRecord(int id, Order entity)
        {
            ResponseStatus<Order> response = new ResponseStatus<Order>();
            try
            {
                response.Record = orderDataAccess.Update(id, entity);
                response.Message = $"Order with id: {id} updated succesfully";
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
