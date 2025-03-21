using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Models;

[Table("MEDIATYPES")]
[Index("SMediumType", Name = "IX_sMediaTypes", IsUnique = true)]
public partial class Mediatype
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("sMediumType")]
    [StringLength(127)]
    public string SMediumType { get; set; } = null!;

    [Column("sComment")]
    public string? SComment { get; set; }

    [InverseProperty("IMediumTypeNavigation")]
    public virtual ICollection<Physloc> Physlocs { get; set; } = new List<Physloc>();
}
