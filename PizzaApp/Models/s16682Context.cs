using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaApp.Models
{
    public partial class s16682Context : DbContext
    {
        public s16682Context()
        {
        }

        public s16682Context(DbContextOptions<s16682Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<AktualnaLokalizacja> AktualnaLokalizacja { get; set; }
        public virtual DbSet<Dostawca> Dostawca { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaSkladnik> PizzaSkladnik { get; set; }
        public virtual DbSet<Promocja> Promocja { get; set; }
        public virtual DbSet<Skladnik> Skladnik { get; set; }
        public virtual DbSet<Stan> Stan { get; set; }
        public virtual DbSet<Typ> Typ { get; set; }
        public virtual DbSet<Zamowienie> Zamowienie { get; set; }
        public virtual DbSet<ZamowieniePizza> ZamowieniePizza { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s16682;Integrated Security=True");
            }
        }

        internal object Entry(Pizza piz)
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin)
                    .HasName("Admin_pk");

                entity.Property(e => e.IdAdmin)
                    .HasColumnName("idAdmin")
                    .ValueGeneratedNever();

                entity.Property(e => e.AdresEmail)
                    .IsRequired()
                    .HasColumnName("adresEmail")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AktualnaLokalizacja>(entity =>
            {
                entity.HasKey(e => e.DostawcaIdDostawca)
                    .HasName("AktualnaLokalizacja_pk");

                entity.Property(e => e.DostawcaIdDostawca)
                    .HasColumnName("Dostawca_idDostawca")
                    .ValueGeneratedNever();

                entity.Property(e => e.CzasPobrania).HasColumnType("datetime");

                entity.HasOne(d => d.DostawcaIdDostawcaNavigation)
                    .WithOne(p => p.AktualnaLokalizacja)
                    .HasForeignKey<AktualnaLokalizacja>(d => d.DostawcaIdDostawca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("AktualnaLokalizacja_Dostawca");
            });

            modelBuilder.Entity<Dostawca>(entity =>
            {
                entity.HasKey(e => e.IdDostawca)
                    .HasName("Dostawca_pk");

                entity.Property(e => e.IdDostawca)
                    .HasColumnName("idDostawca")
                    .ValueGeneratedNever();

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.NumerTelefonu)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.IdPizza)
                    .HasName("Pizza_pk");

                entity.Property(e => e.IdPizza)
                    .HasColumnName("idPizza")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Zdjecie)
                    .HasColumnType("image");
            });

            modelBuilder.Entity<PizzaSkladnik>(entity =>
            {
                entity.HasKey(e => new { e.PizzaIdPizza, e.SkladnikIdSkladnik })
                    .HasName("Pizza_Skladnik_pk");

                entity.ToTable("Pizza_Skladnik");

                entity.Property(e => e.PizzaIdPizza).HasColumnName("Pizza_idPizza");

                entity.Property(e => e.SkladnikIdSkladnik).HasColumnName("Skladnik_idSkladnik");

                entity.HasOne(d => d.PizzaIdPizzaNavigation)
                    .WithMany(p => p.PizzaSkladnik)
                    .HasForeignKey(d => d.PizzaIdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Skladnik_Pizza");

                entity.HasOne(d => d.SkladnikIdSkladnikNavigation)
                    .WithMany(p => p.PizzaSkladnik)
                    .HasForeignKey(d => d.SkladnikIdSkladnik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Skladnik_Skladnik");
            });

            modelBuilder.Entity<Promocja>(entity =>
            {
                entity.HasKey(e => e.IdPromocja)
                    .HasName("Promocja_pk");

                entity.Property(e => e.IdPromocja)
                    .HasColumnName("idPromocja")
                    .ValueGeneratedNever();

                entity.Property(e => e.AktualnaDo).HasColumnType("datetime");

                entity.Property(e => e.AktualnaOd).HasColumnType("datetime");

                entity.Property(e => e.PizzaIdPizza).HasColumnName("Pizza_idPizza");

                entity.HasOne(d => d.PizzaIdPizzaNavigation)
                    .WithMany(p => p.Promocja)
                    .HasForeignKey(d => d.PizzaIdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Promocja_Pizza");
            });

            modelBuilder.Entity<Skladnik>(entity =>
            {
                entity.HasKey(e => e.IdSkladnik)
                    .HasName("Skladnik_pk");

                entity.Property(e => e.IdSkladnik)
                    .HasColumnName("idSkladnik")
                    .ValueGeneratedNever();

                entity.Property(e => e.TypIdTyp).HasColumnName("Typ_idTyp");

                entity.HasOne(d => d.TypIdTypNavigation)
                    .WithMany(p => p.Skladnik)
                    .HasForeignKey(d => d.TypIdTyp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Skladnik_Typ");
            });

            modelBuilder.Entity<Stan>(entity =>
            {
                entity.HasKey(e => e.IdStan)
                    .HasName("Stan_pk");

                entity.Property(e => e.IdStan)
                    .HasColumnName("idStan")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Typ>(entity =>
            {
                entity.HasKey(e => e.IdTyp)
                    .HasName("Typ_pk");

                entity.Property(e => e.IdTyp)
                    .HasColumnName("idTyp")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Zamowienie>(entity =>
            {
                entity.HasKey(e => e.NumerZamowienia)
                    .HasName("Zamowienie_pk");

                entity.Property(e => e.NumerZamowienia)
                    .HasColumnName("numerZamowienia")
                    .ValueGeneratedNever();

                entity.Property(e => e.DostawcaIdDostawca).HasColumnName("Dostawca_idDostawca");

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NrTelefonu)
                    .IsRequired()
                    .HasColumnName("nrTelefonu")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.StanIdStan).HasColumnName("Stan_idStan");

                entity.Property(e => e.SzacowanyCzasDostawy).HasColumnType("datetime");

                entity.Property(e => e.Ulica)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.DostawcaIdDostawcaNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.DostawcaIdDostawca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Dostawca");

                entity.HasOne(d => d.StanIdStanNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.StanIdStan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Stan");
            });

            modelBuilder.Entity<ZamowieniePizza>(entity =>
            {
                entity.HasKey(e => new { e.ZamowienieNumerZamowienia, e.PizzaIdPizza })
                    .HasName("Zamowienie_Pizza_pk");

                entity.ToTable("Zamowienie_Pizza");

                entity.Property(e => e.ZamowienieNumerZamowienia).HasColumnName("Zamowienie_numerZamowienia");

                entity.Property(e => e.PizzaIdPizza).HasColumnName("Pizza_idPizza");

                entity.HasOne(d => d.PizzaIdPizzaNavigation)
                    .WithMany(p => p.ZamowieniePizza)
                    .HasForeignKey(d => d.PizzaIdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Pizza_Pizza");

                entity.HasOne(d => d.ZamowienieNumerZamowieniaNavigation)
                    .WithMany(p => p.ZamowieniePizza)
                    .HasForeignKey(d => d.ZamowienieNumerZamowienia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Pizza_Zamowienie");
            });
        }
    }
}
