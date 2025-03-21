using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Models;

public partial class RamLibContext : DbContext
{
    public RamLibContext()
    {
    }

    public RamLibContext(DbContextOptions<RamLibContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Arrangement> Arrangements { get; set; }

    public virtual DbSet<BridgeArrForm> BridgeArrForms { get; set; }

    public virtual DbSet<BridgeArrGenre> BridgeArrGenres { get; set; }

    public virtual DbSet<BridgeArrStyle> BridgeArrStyles { get; set; }

    public virtual DbSet<BridgeCollItem> BridgeCollItems { get; set; }

    public virtual DbSet<ChangeLog> ChangeLogs { get; set; }

    public virtual DbSet<Collection> Collections { get; set; }

    public virtual DbSet<Containertype> Containertypes { get; set; }

    public virtual DbSet<Diagnostic> Diagnostics { get; set; }

    public virtual DbSet<Ensembletype> Ensembletypes { get; set; }

    public virtual DbSet<FileName> FileNames { get; set; }

    public virtual DbSet<FilePath> FilePaths { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Instrgroup> Instrgroups { get; set; }

    public virtual DbSet<Instrument> Instruments { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Mediatype> Mediatypes { get; set; }

    public virtual DbSet<Metadata> Metadata { get; set; }

    public virtual DbSet<Musicalform> Musicalforms { get; set; }

    public virtual DbSet<Part> Parts { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Physloc> Physlocs { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<Sh0Roomshall> Sh0Roomshalls { get; set; }

    public virtual DbSet<Sh1Cabsstack> Sh1Cabsstacks { get; set; }

    public virtual DbSet<Sh2Drawersshelf> Sh2Drawersshelves { get; set; }

    public virtual DbSet<Sh3Foldersbox> Sh3Foldersboxes { get; set; }

    public virtual DbSet<Skilllevel> Skilllevels { get; set; }

    public virtual DbSet<Style> Styles { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Work> Works { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=RamLib;Integrated Security=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Arrangement>(entity =>
        {
            entity.Property(e => e.BOriginal).HasComment("True - it is an original composition. False - it is an arrangement");
            entity.Property(e => e.IBasedOnArr).HasComment("Pointer to another record in the same table to indicate the original composition or arrangement on which this arrangement is based. If one exists bOriginal should be false.");
            entity.Property(e => e.ICompArr).HasComment("Pointer to row in table PEOPLE indicating composer or arranger. If here is no such person then point to an entry called 'unknown' or 'anonymous'.");
            entity.Property(e => e.IWork).HasComment("Pointer to row in table WORKS. This  underlying work must exist.");
            entity.Property(e => e.IYearCompleted).HasComment("Year when composition or arrangement was created/completed");
            entity.Property(e => e.IYearPublished).HasComment("Year of composition or arrangement publication");
            entity.Property(e => e.SSubtitle).HasComment("The subtitle of this arrangement. If bOriginal is true, this subtitle should be empty because the subtitle of the original work in table WORKS prevails.");
            entity.Property(e => e.STitle).HasComment("The title of this arrangement. If bOriginal is true, this title should be empty because the title of the original work in table WORKS prevails.");

            entity.HasOne(d => d.IBasedOnArrNavigation).WithMany(p => p.InverseIBasedOnArrNavigation).HasConstraintName("FK_ARRANGEMENTS_ARRANGEMENTS");

            entity.HasOne(d => d.ICompArrNavigation).WithMany(p => p.Arrangements)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ARRANGEMENTS_PEOPLE");

            entity.HasOne(d => d.IEnsembleTypeNavigation).WithMany(p => p.Arrangements).HasConstraintName("FK_ARRANGEMENTS_ENSEMBLETYPES");

            entity.HasOne(d => d.IWorkNavigation).WithMany(p => p.Arrangements)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ARRANGEMENTS_WORKS");
        });

        modelBuilder.Entity<BridgeArrForm>(entity =>
        {
            entity.HasOne(d => d.IArrangementNavigation).WithMany(p => p.BridgeArrForms)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BRIDGE_ARR_FORMS_ARRANGEMENTS");

            entity.HasOne(d => d.IMusicalFormNavigation).WithMany(p => p.BridgeArrForms)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BRIDGE_ARR_FORMS_MUSICALFORMS");
        });

        modelBuilder.Entity<BridgeArrGenre>(entity =>
        {
            entity.HasOne(d => d.IArrangementNavigation).WithMany(p => p.BridgeArrGenres)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BRIDGE_ARR_GENRES_ARRANGEMENTS");

            entity.HasOne(d => d.IGenreNavigation).WithMany(p => p.BridgeArrGenres)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BRIDGE_ARR_GENRES_GENRES");
        });

        modelBuilder.Entity<BridgeArrStyle>(entity =>
        {
            entity.HasOne(d => d.IArrangementNavigation).WithMany(p => p.BridgeArrStyles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BRIDGE_ARR_STYLES_ARRANGEMENTS");

            entity.HasOne(d => d.IStyleNavigation).WithMany(p => p.BridgeArrStyles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BRIDGE_ARR_STYLES_STYLES");
        });

        modelBuilder.Entity<BridgeCollItem>(entity =>
        {
            entity.HasOne(d => d.ICollectionNavigation).WithMany(p => p.BridgeCollItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BRIDGE_COLL_ITEMS_COLLECTIONS");

            entity.HasOne(d => d.IItemNavigation).WithMany(p => p.BridgeCollItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BRIDGE_COLL_ITEMS_ITEMS");
        });

        modelBuilder.Entity<ChangeLog>(entity =>
        {
            entity.Property(e => e.CActionType)
                .IsFixedLength()
                .HasComment("I = insert, U = update, D = delete");
            entity.Property(e => e.IRecord).HasComment("ID of affected record in table sTableName");
            entity.Property(e => e.SNewValue).HasComment("JSON serialization of new value of entire record");
            entity.Property(e => e.SOldValue).HasComment("JSON serialization of old value of entire record");

            entity.HasOne(d => d.UChangedByNavigation).WithMany(p => p.ChangeLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CHANGE_LOG_USERS");
        });

        modelBuilder.Entity<Collection>(entity =>
        {
            entity.HasOne(d => d.IOwnerNavigation).WithMany(p => p.Collections).HasConstraintName("FK_COLLECTIONS_PEOPLE");

            entity.HasOne(d => d.IPhysLocNavigation).WithMany(p => p.Collections).HasConstraintName("FK_COLLECTIONS_PHYSLOCS");
        });

        modelBuilder.Entity<Diagnostic>(entity =>
        {
            entity.Property(e => e.CSeverity)
                .HasDefaultValue("i")
                .IsFixedLength()
                .HasComment("f = fatal error (software collapse); s = severe or stop error (causes popup message to user); c = continuable error (may cause popup message); w = warning; i = info; d = debug");
        });

        modelBuilder.Entity<FileName>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FILE_NAM__3214EC27BD6E9272");
        });

        modelBuilder.Entity<FilePath>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FILE_PAT__3214EC27F84C9F99");
        });

        modelBuilder.Entity<Instrument>(entity =>
        {
            entity.Property(e => e.SAbbrev).HasDefaultValue("?");

            entity.HasOne(d => d.IInstrGroupNavigation).WithMany(p => p.Instruments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_INSTRUMENTS_INSTRGROUPS");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasOne(d => d.IArrangementNavigation).WithMany(p => p.Items)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ITEMS_ARRANGEMENTS");

            entity.HasOne(d => d.IPublisherNavigation).WithMany(p => p.Items).HasConstraintName("FK_ITEMS_PUBLISHERS");

            entity.HasOne(d => d.ISupplierNavigation).WithMany(p => p.Items).HasConstraintName("FK_ITEMS_SUPPLIERS");
        });

        modelBuilder.Entity<Mediatype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_MEDIA");
        });

        modelBuilder.Entity<Part>(entity =>
        {
            entity.Property(e => e.IInstrCopySeqNum).HasComment("Serial  number of identical copies (i.e., one specific instrument) intended for different members of the ensemble or orchestra");
            entity.Property(e => e.SPartSeqNum).HasComment("A sequence number for different parts of the same instrument if they are indeed distributed as different parts.");

            entity.HasOne(d => d.IInstrumentNavigation).WithMany(p => p.Parts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PARTS_INSTRUMENTS");

            entity.HasOne(d => d.IItemNavigation).WithMany(p => p.Parts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PARTS_ITEMS");

            entity.HasOne(d => d.ISkillLevelNavigation).WithMany(p => p.Parts).HasConstraintName("FK_PARTS_SKILLLEVELS");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.Property(e => e.SName).HasComputedColumnSql("(Trim(([sFirstName]+' ')+[sLastName]))", false);
        });

        modelBuilder.Entity<Physloc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_LOCATIONS");

            entity.HasIndex(e => e.SLocationName, "UQ_PHYSLOCS_sLocationName")
                .IsUnique()
                .HasFilter("([sLocationName] IS NOT NULL)");

            entity.Property(e => e.IMediumType).HasComment("Single character indicating the type of storage medium: 'P' - printed paper, 'F' - Computer file, 'O' - other");

            entity.HasOne(d => d.ICabStackNavigation).WithMany(p => p.Physlocs).HasConstraintName("FK_PHYSLOCS_SH1_CABSSTACKS");

            entity.HasOne(d => d.IDrawerShelfNavigation).WithMany(p => p.Physlocs).HasConstraintName("FK_PHYSLOCS_SH2_DRAWERSSHELVES");

            entity.HasOne(d => d.IFileNameNavigation).WithMany(p => p.Physlocs).HasConstraintName("FK__PHYSLOCS__iFileN__61F08603");

            entity.HasOne(d => d.IFolderOrBoxNavigation).WithMany(p => p.Physlocs).HasConstraintName("FK_PHYSLOCS_SH3_FOLDERSBOXES");

            entity.HasOne(d => d.IMediumTypeNavigation).WithMany(p => p.Physlocs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PHYSLOCS_MEDIATYPES");

            entity.HasOne(d => d.IPathNavigation).WithMany(p => p.Physlocs).HasConstraintName("FK__PHYSLOCS__iPath__60FC61CA");

            entity.HasOne(d => d.IRoomHallNavigation).WithMany(p => p.Physlocs).HasConstraintName("FK_PHYSLOCS_SH0_ROOMSHALLS");
        });

        modelBuilder.Entity<Sh0Roomshall>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ROOMSORHALLS");

            entity.HasOne(d => d.IContainerTypeNavigation).WithMany(p => p.Sh0Roomshalls)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SH0_ROOMSHALLS_CONTAINERTYPES");
        });

        modelBuilder.Entity<Sh1Cabsstack>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SH_CABSSTACKS");

            entity.HasOne(d => d.IContainerTypeNavigation).WithMany(p => p.Sh1Cabsstacks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SH1_CABSSTACKS_CONTAINERTYPES");

            entity.HasOne(d => d.IRoomHallNavigation).WithMany(p => p.Sh1Cabsstacks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SH1_CABSSTACKS_SH0_ROOMSHALLS");
        });

        modelBuilder.Entity<Sh2Drawersshelf>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SH2_DRAWERSSHELVES_1");

            entity.HasOne(d => d.ICabStackNavigation).WithMany(p => p.Sh2Drawersshelves).HasConstraintName("FK_SH2_DRAWERSSHELVES_SH1_CABSSTACKS");

            entity.HasOne(d => d.IContainerTypeNavigation).WithMany(p => p.Sh2Drawersshelves)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SH2_DRAWERSSHELVES_CONTAINERTYPES");
        });

        modelBuilder.Entity<Sh3Foldersbox>(entity =>
        {
            entity.HasOne(d => d.IContainerTypeNavigation).WithMany(p => p.Sh3Foldersboxes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SH3_FOLDERSBOXES_CONTAINERTYPES");

            entity.HasOne(d => d.IDrawerShelfNavigation).WithMany(p => p.Sh3Foldersboxes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SH3_FOLDERSBOXES_SH2_DRAWERSSHELVES");
        });

        modelBuilder.Entity<Skilllevel>(entity =>
        {
            entity.Property(e => e.ISkillLevel)
                .HasDefaultValue(5)
                .HasComment("Numerical skill level for the purpose of ordering the textual skill levels");
            entity.Property(e => e.SSkillLevel).HasComment("Textual description of skill level");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SOURCES");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__USERS__3214EC2762D9AD54");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.AccessFailedCount).HasDefaultValue(0);
            entity.Property(e => e.EmailConfirmed).HasDefaultValue(false);
            entity.Property(e => e.LockoutEnabled).HasDefaultValue(true);
            entity.Property(e => e.PhoneNumberConfirmed).HasDefaultValue(false);
            entity.Property(e => e.TwoFactorEnabled).HasDefaultValue(false);
        });

        modelBuilder.Entity<Work>(entity =>
        {
            entity.Property(e => e.SComposerInitials).HasComment("Can be null most of the time. Only needeed when there are duplicate titles and the record would not have a unique title. The combination of title and composer intials must be unique.");

            entity.HasOne(d => d.IBasedOnNavigation).WithMany(p => p.InverseIBasedOnNavigation).HasConstraintName("FK_WORKS_IBasedOn");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
