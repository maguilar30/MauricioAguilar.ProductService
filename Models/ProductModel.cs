namespace MauricioAguilar.Product.Service.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Sku { get; set; } = string.Empty;

        public string? Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? Category { get; set; }

        public string? Brand { get; set; }

        public string? Barcode { get; set; }

        public string UnitOfMeasure { get; set; } = "Each";

        public decimal QuantityOnHand { get; set; }

        public decimal ReorderLevel { get; set; }

        public decimal? MaximumStock { get; set; }

        public decimal UnitCost { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal? Weight { get; set; }

        public string? Location { get; set; }

        public string? ImageUrl { get; set; }

        public bool IsActive { get; set; } = true;

        public Guid RowVersion { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }
    }
}
