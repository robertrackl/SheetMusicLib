using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Models;

[Table("ITEMS")]
[Index("SCallNumber", Name = "IX_sCallNumber", IsUnique = true)]
public partial class Item
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("iArrangement")]
    public int IArrangement { get; set; }

    [Column("sCallNumber")]
    [StringLength(127)]
    public string SCallNumber { get; set; } = null!;

    [Column("iPublisher")]
    public int? IPublisher { get; set; }

    [Column("sEdition")]
    [StringLength(128)]
    public string? SEdition { get; set; }

    [Column("DPubl")]
    public DateOnly? Dpubl { get; set; }

    [Column("iSupplier")]
    public int? ISupplier { get; set; }

    [Column("sComment")]
    public string? SComment { get; set; }

    [InverseProperty("IItemNavigation")]
    public virtual ICollection<BridgeCollItem> BridgeCollItems { get; set; } = new List<BridgeCollItem>();

    [ForeignKey("IArrangement")]
    [InverseProperty("Items")]
    public virtual Arrangement IArrangementNavigation { get; set; } = null!;

    [ForeignKey("IPublisher")]
    [InverseProperty("Items")]
    public virtual Publisher? IPublisherNavigation { get; set; }

    [ForeignKey("ISupplier")]
    [InverseProperty("Items")]
    public virtual Supplier? ISupplierNavigation { get; set; }

    [InverseProperty("IItemNavigation")]
    public virtual ICollection<Part> Parts { get; set; } = new List<Part>();
}
