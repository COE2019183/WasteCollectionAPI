using System.ComponentModel.DataAnnotations;

namespace WMS_API.Models.Domain
{
    public class BinStatus
    {
        public Guid Id { get; set; }
        public string WasteStatus { get; set; }
    }
}
