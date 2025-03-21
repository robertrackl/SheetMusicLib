using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Models;

[Table("SUPPLIERS")]
[Index("SSupplier", Name = "IX_sSupplier", IsUnique = true)]
public partial class Supplier
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("sSupplier")]
    [StringLength(50)]
    public string SSupplier { get; set; } = null!;

    [Column("sComment")]
    public string? SComment { get; set; }

    [InverseProperty("ISupplierNavigation")]
    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
