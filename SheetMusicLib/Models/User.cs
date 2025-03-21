using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Models;

[Table("USERS")]
[Index("NormalizedEmail", Name = "UQ__USERS__368B291AAD050DE5", IsUnique = true)]
[Index("NormalizedUserName", Name = "UQ__USERS__54E8BE2280DF9A7D", IsUnique = true)]
[Index("Email", Name = "UQ__USERS__A9D105348D2B157E", IsUnique = true)]
[Index("UserName", Name = "UQ__USERS__C9F28456DCA9AB24", IsUnique = true)]
public partial class User
{
    [Key]
    [Column("ID")]
    public Guid Id { get; set; }

    [StringLength(100)]
    public string UserName { get; set; } = null!;

    [StringLength(100)]
    public string NormalizedUserName { get; set; } = null!;

    [StringLength(255)]
    public string Email { get; set; } = null!;

    [StringLength(255)]
    public string NormalizedEmail { get; set; } = null!;

    public bool? EmailConfirmed { get; set; }

    [StringLength(255)]
    public string PasswordHash { get; set; } = null!;

    [StringLength(255)]
    public string? SecurityStamp { get; set; }

    [StringLength(255)]
    public string? ConcurrencyStamp { get; set; }

    [StringLength(50)]
    public string? PhoneNumber { get; set; }

    public bool? PhoneNumberConfirmed { get; set; }

    public bool? TwoFactorEnabled { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LockoutEnd { get; set; }

    public bool? LockoutEnabled { get; set; }

    public int? AccessFailedCount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastLogin { get; set; }

    [InverseProperty("UChangedByNavigation")]
    public virtual ICollection<ChangeLog> ChangeLogs { get; set; } = new List<ChangeLog>();
}
