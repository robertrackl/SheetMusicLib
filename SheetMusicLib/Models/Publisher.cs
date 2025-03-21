using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Models;

[Table("PUBLISHERS")]
[Index("SPublisher", Name = "IX_sPublisher", IsUnique = true)]
public partial class Publisher
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("sPublisher")]
    [StringLength(128)]
    public string SPublisher { get; set; } = null!;

    [Column("sComment")]
    public string? SComment { get; set; }

    [InverseProperty("IPublisherNavigation")]
    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
