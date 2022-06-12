namespace MyArchitect.RequestResponseModels.Product.GetAllProducts
{
    public class GetAllProductDto : BaseResponseDto
    {
        public int UnitInStock { get; set; }
        public string NAME { get; set; }
        public int CategoryId { get; set; }
    }
}
