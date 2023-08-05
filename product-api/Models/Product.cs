namespace product_api.Models
{
    public class Product
    {
        public Guid ProductId { get; } =Guid.NewGuid();
        public string Name { get; init; } = null!;
        public string Description { get; init; } = null!;
        public double Price { get; init; }


    }
}
