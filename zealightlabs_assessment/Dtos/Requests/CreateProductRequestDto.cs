namespace zealightlabs_assessment.Dtos.Requests
{
    public class CreateProductRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }


}
