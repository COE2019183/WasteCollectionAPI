using System.ComponentModel.DataAnnotations;

namespace WMS_API.Models.DTO.BinDTO
{
    public class UpdateBinDTO
    {
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longtitude { get; set; }
        [Required]
        public string AreaCode { get; set; }
        [Required]
        public string BinSize { get; set; }
        [Required]
        public int Capacity_In_KG { get; set; }
    }
}
