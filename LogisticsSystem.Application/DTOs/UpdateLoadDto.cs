using System.ComponentModel.DataAnnotations;

namespace LogisticsSystem.Application.DTOs
{
    public class UpdateLoadDto
    {
        [Required(ErrorMessage = "Yük adı zorunludur.")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Yük adı 3-255 karakter olmalıdır.")]
        public string LoadName { get; set; } = null!;

        [Required(ErrorMessage = "Yük türü zorunludur.")]
        [Range(1, int.MaxValue, ErrorMessage = "Geçerli bir yük türü seçiniz.")]
        public int LoadTypeId { get; set; }

        [StringLength(500, ErrorMessage = "Açıklama maksimum 500 karakter olabilir.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Ağırlık zorunludur.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Ağırlık 0'dan büyük olmalıdır.")]
        public decimal Weight { get; set; }

        [Required(ErrorMessage = "Miktar zorunludur.")]
        [Range(1, int.MaxValue, ErrorMessage = "Miktar 1 veya daha fazla olmalıdır.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Kaynak depo zorunludur.")]
        [Range(1, int.MaxValue, ErrorMessage = "Geçerli bir kaynak depo seçiniz.")]
        public int SourceWarehouseId { get; set; }

        [Required(ErrorMessage = "Hedef depo zorunludur.")]
        [Range(1, int.MaxValue, ErrorMessage = "Geçerli bir hedef depo seçiniz.")]
        public int TargetWarehouseId { get; set; }

        [Required(ErrorMessage = "Müşteri zorunludur.")]
        [Range(1, int.MaxValue, ErrorMessage = "Geçerli bir müşteri seçiniz.")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Oluşturma tarihi zorunludur.")]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "Durum zorunludur.")]
        [StringLength(100, ErrorMessage = "Durum maksimum 100 karakter olabilir.")]
        public string Status { get; set; } = null!;

        [Required(ErrorMessage = "Yönetici ID zorunludur.")]
        [Range(1, int.MaxValue, ErrorMessage = "Geçerli bir yönetici seçiniz.")]
        public int CreatedByAdminId { get; set; }
    }
}