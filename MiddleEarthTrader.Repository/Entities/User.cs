using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleEarthTrader.Repository.Entities
{
    public class User : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [ForeignKey(nameof(Nation))]
        public Guid NationId { get; set; }
        public Nation Nation { get; set; }

        public decimal Gold { get; set; } = 1000;

        public UserRole Role { get; set; } = UserRole.Player;

        // Navigation Properties
        public ICollection<Inventory> Inventories { get; set; }
        public ICollection<Trade> Trades { get; set; }
    }

    public enum UserRole
    {
        Player,
        Merchant,
        Admin
    }
}

