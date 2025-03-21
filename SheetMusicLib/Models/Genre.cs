using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Models;

[Table("GENRES")]
[Index("SGenre", Name = "IX_sGenre", IsUnique = true)]
public partial class Genre
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("sGenre")]
    [StringLength(20)]
    public string SGenre { get; set; } = null!;

    [Column("sComment")]
    public string? SComment { get; set; }

    [InverseProperty("IGenreNavigation")]
    public virtual ICollection<BridgeArrGenre> BridgeArrGenres { get; set; } = new List<BridgeArrGenre>();
}
