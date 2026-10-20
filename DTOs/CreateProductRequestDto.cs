namespace MauricioAguilar.Product.Service.DTOs
{
    public class CreateProductRequestDto
    {
        public string Sku { get; set; } = string.Empty;

        public string? Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? Category { get; set; }

        public string? Brand { get; set; }

    }
}
