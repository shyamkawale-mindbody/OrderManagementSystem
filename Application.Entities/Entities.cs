using Application.Entities.Base;

namespace Application.Entities
{
    public class Customer : Entity
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int MobileNo { get; set; }
        public string Address { get; set; }
    }
    public class Product : Entity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public decimal UnitPrice { get; set; }
    }
    public class Order : Entity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsOrderApproved { get; set; }
        public bool IsOrderDispatched { get; set; }
    }

}