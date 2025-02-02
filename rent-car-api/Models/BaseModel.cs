using System;
using System.ComponentModel.DataAnnotations;

namespace rent_car_api.Models
{
    public class BaseModel
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? CreatedBy { get; set; } = string.Empty;
        public DateTime? ModifiedAt { get; set; } = DateTime.UtcNow;
        public string? ModifiedBy { get; set; } = string.Empty;
    }
}

