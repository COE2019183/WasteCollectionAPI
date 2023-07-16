using System.ComponentModel.DataAnnotations;

namespace WMS_API.Models.Domain
{
    public class Bin
    {
        public Guid Id { get; set; }
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

        //Navigation
        public BinStatus binStatus { get; set; }

    }
}
