using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Models;

[Table("PEOPLE")]
[Index("SName", Name = "IX_PEOPLE", IsUnique = true)]
public partial class Person
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("sFirstName")]
    [StringLength(50)]
    public string? SFirstName { get; set; }

    [Column("sLastName")]
    [StringLength(64)]
    public string SLastName { get; set; } = null!;

    [Column("iBirthYear")]
    public int? IBirthYear { get; set; }

    [Column("iDeathYear")]
    public int? IDeathYear { get; set; }

    [Column("sName")]
    [StringLength(115)]
    public string? SName { get; set; }

    [Column("sComment")]
    public string? SComment { get; set; }

    [InverseProperty("ICompArrNavigation")]
    public virtual ICollection<Arrangement> Arrangements { get; set; } = new List<Arrangement>();

    [InverseProperty("IOwnerNavigation")]
    public virtual ICollection<Collection> Collections { get; set; } = new List<Collection>();
}
