using MyArchitect.Domain.Abstraction;

namespace MyArchitect.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            Category = new Category();
        }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int UnitInStock { get; set; }
        public Category Category { get; set; }
    }
}
