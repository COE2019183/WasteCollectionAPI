using System.ComponentModel.DataAnnotations;

namespace WMS_API.Models.Domain
{
    public class WCollector
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public DateTime JoinedDate { get; set; }
    }
}
