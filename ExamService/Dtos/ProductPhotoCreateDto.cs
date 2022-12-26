namespace ExamService.Models;

public class ProductPhotoCreateDto
{
    public int ProductPhotoId { get; set; }
    public string? ThumbNailPhoto { get; set; }
    public string? ThumbnailPhotoFileName { get; set; }
    public string? LargePhoto { get; set; }
    public string? LargePhotoFileName { get; set; }
    public DateTime ModifiedDate { get; set; }
}