namespace HotelBooker.Application.Hotels.Dtos;
public class HotelPreviewDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string AddressLine1 { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }

    public decimal LowestPrice { get; set; }

    /// <summary>
    /// We could keep this as a hardcoded URL of a placeholder image
    /// </summary>
    public string Thumbnail { get; set; }
}
