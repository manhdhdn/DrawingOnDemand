using System.ComponentModel.DataAnnotations;

namespace DrawingOnDemandAPI.GHN.Models
{
    public class GHNRequest
    {
        [Key]
        public string Endpoint { get; set; } = null!;
        public string? PostJsonString { get; set; }
    }
}
