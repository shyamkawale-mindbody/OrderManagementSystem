namespace OrderManagementSystem.Repository
{
    public class ProductRepository: IServiceRepository<Product, int>
    {
        IDataAccess<Product, int> productDataAccess;

        public ProductRepository(IDataAccess<Product, int> productDataAccess)
        {
            this.productDataAccess = productDataAccess;
        }

        ResponseStatus<Product> IServiceRepository<Product, int>.CreateRecord(Product entity)
        {
            ResponseStatus<Product> response = new ResponseStatus<Product>();
            try
            {
                response.Record = productDataAccess.Create(entity);
                response.Message = "Product created succesfully";
                response.StatusCode = 201;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Product> IServiceRepository<Product, int>.DeleteRecord(int id)
        {
            ResponseStatus<Product> response = new ResponseStatus<Product>();
            try
            {
                response.Record = productDataAccess.Delete(id);
                response.Message = $"Product with id: {id} deleted succesfully";
                response.StatusCode = 203;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Product> IServiceRepository<Product, int>.GetRecord(int id)
        {
            ResponseStatus<Product> response = new ResponseStatus<Product>();
            try
            {
                response.Record = productDataAccess.Get(id);
                response.Message = $"Product with id: {id} read succesfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Product> IServiceRepository<Product, int>.GetRecords()
        {
            ResponseStatus<Product> response = new ResponseStatus<Product>();
            try
            {
                response.Records = productDataAccess.Get();
                response.Message = $"All Products read succesfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Product> IServiceRepository<Product, int>.UpdateRecord(int id, Product entity)
        {
            ResponseStatus<Product> response = new ResponseStatus<Product>();
            try
            {
                response.Record = productDataAccess.Update(id, entity);
                response.Message = $"Product with id: {id} updated succesfully";
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
