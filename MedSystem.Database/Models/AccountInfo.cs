using System;
using System.ComponentModel.DataAnnotations;

namespace MedSystem.Database.Models
{
    public class AccountInfo
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        public byte[] Password { get; set; }
        [Required]
        [MaxLength(32)]
        public byte[] Salt { get; set; }
        public DateTime ExpirationDate { get; set; }

        [Required]
        public int UzivatelId { get; set; }
        public virtual Uzivatel Uzivatel { get; set; }
    }
}
