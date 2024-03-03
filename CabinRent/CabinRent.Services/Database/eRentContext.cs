using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CabinRent.Services.Database
{
    public partial class eRentContext : DbContext
    {
        public eRentContext()
        {
        }

        public eRentContext(DbContextOptions<eRentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DetaljiRezervacije> DetaljiRezervacijes { get; set; } = null!;
        public virtual DbSet<Drzava> Drzavas { get; set; } = null!;
        public virtual DbSet<Grad> Grads { get; set; } = null!;
        public virtual DbSet<Klijent> Klijents { get; set; } = null!;
        public virtual DbSet<Korisnik> Korisniks { get; set; } = null!;
        public virtual DbSet<KorisnikUloge> KorisnikUloges { get; set; } = null!;
        public virtual DbSet<Objekat> Objekats { get; set; } = null!;
        public virtual DbSet<Ocjena> Ocjenas { get; set; } = null!;
        public virtual DbSet<Rezervacija> Rezervacijas { get; set; } = null!;
        public virtual DbSet<TipObjektaSllike> TipObjektaSllikes { get; set; } = null!;
        public virtual DbSet<TipObjektum> TipObjekta { get; set; } = null!;
        public virtual DbSet<Uloga> Ulogas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=eRent; user=admin; Password=admin123!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetaljiRezervacije>(entity =>
            {
                entity.ToTable("DetaljiRezervacije");

                entity.Property(e => e.DetaljiRezervacijeId).HasColumnName("DetaljiRezervacijeID");

                entity.Property(e => e.RezervacijaId).HasColumnName("RezervacijaID");

                entity.Property(e => e.TipSobe)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Rezervacija)
                    .WithMany(p => p.DetaljiRezervacijes)
                    .HasForeignKey(d => d.RezervacijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rezervacija");
            });

            modelBuilder.Entity<Drzava>(entity =>
            {
                entity.ToTable("Drzava");

                entity.Property(e => e.DrzavaId).HasColumnName("DrzavaID");

                entity.Property(e => e.Naziv).HasMaxLength(60);
            });

            modelBuilder.Entity<Grad>(entity =>
            {
                entity.ToTable("Grad");

                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.DrzavaId).HasColumnName("DrzavaID");

                entity.Property(e => e.Naziv).HasMaxLength(50);

                entity.Property(e => e.PostBroj).HasMaxLength(10);

                entity.HasOne(d => d.Drzava)
                    .WithMany(p => p.Grads)
                    .HasForeignKey(d => d.DrzavaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_grad_drzava");
            });

            modelBuilder.Entity<Klijent>(entity =>
            {
                entity.ToTable("Klijent");

                entity.Property(e => e.KlijentId).HasColumnName("KlijentID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.Ime).HasMaxLength(30);

                entity.Property(e => e.KorisnickoIme).HasMaxLength(40);

                entity.Property(e => e.Prezime).HasMaxLength(40);

                entity.Property(e => e.Telefon).HasMaxLength(60);

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Klijents)
                    .HasForeignKey(d => d.GradId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_klijent_grad");
            });

            modelBuilder.Entity<Korisnik>(entity =>
            {
                entity.ToTable("Korisnik");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Ime).HasMaxLength(30);

                entity.Property(e => e.KorisnickoIme).HasMaxLength(50);

                entity.Property(e => e.Prezime).HasMaxLength(40);

                entity.Property(e => e.Telefon).HasMaxLength(30);
            });

            modelBuilder.Entity<KorisnikUloge>(entity =>
            {
                entity.ToTable("KorisnikUloge");

                entity.Property(e => e.KorisnikUlogeId).HasColumnName("KorisnikUlogeID");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.UlogaId).HasColumnName("UlogaID");

                entity.HasOne(d => d.Korisnik)
                   .WithMany(p => p.KorisnikUloges)
                   .HasForeignKey(d => d.KorisnikId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("fk_korisnik");

                entity.HasOne(d => d.Uloga)
                    .WithMany(p => p.KorisnikUloges)
                    .HasForeignKey(d => d.UlogaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_uloga");
            });

            modelBuilder.Entity<Objekat>(entity =>
            {
                entity.ToTable("Objekat");

                entity.Property(e => e.ObjekatId).HasColumnName("ObjekatID");

                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.Naziv).HasMaxLength(50);

                entity.Property(e => e.Opis).HasMaxLength(50);

                entity.Property(e => e.Povrsina).HasMaxLength(50);

                entity.Property(e => e.TipObjektaId).HasColumnName("TipObjektaID");

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Objekats)
                    .HasForeignKey(d => d.GradId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_grad");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Objekats)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_korisnik_objekat");

                entity.HasOne(d => d.TipObjekta)
                    .WithMany(p => p.Objekats)
                    .HasForeignKey(d => d.TipObjektaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tip");
            });

            modelBuilder.Entity<Ocjena>(entity =>
            {
                entity.ToTable("Ocjena");

                entity.Property(e => e.OcjenaId).HasColumnName("OcjenaID");

                entity.Property(e => e.KlijentId).HasColumnName("KlijentID");

                entity.Property(e => e.Komentar).HasMaxLength(100);

                entity.Property(e => e.ObjekatId).HasColumnName("ObjekatID");

                entity.Property(e => e.Ocjena1).HasColumnName("Ocjena");

                entity.HasOne(d => d.Klijent)
                    .WithMany(p => p.Ocjenas)
                    .HasForeignKey(d => d.KlijentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_klijent");

                entity.HasOne(d => d.Objekat)
                    .WithMany(p => p.Ocjenas)
                    .HasForeignKey(d => d.ObjekatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_objekat");
            });

            modelBuilder.Entity<Rezervacija>(entity =>
            {
                entity.ToTable("Rezervacija");

                entity.Property(e => e.RezervacijaId).HasColumnName("RezervacijaID");

                entity.Property(e => e.DatumOdjave).HasColumnType("date");

                entity.Property(e => e.DatumPrijave).HasColumnType("date");

                entity.Property(e => e.KlijentId).HasColumnName("KlijentID");

                entity.Property(e => e.ObjekatId).HasColumnName("ObjekatID");

                entity.HasOne(d => d.Klijent)
                    .WithMany(p => p.Rezervacijas)
                    .HasForeignKey(d => d.KlijentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rezervacija_klijent");

                entity.HasOne(d => d.Objekat)
                    .WithMany(p => p.Rezervacijas)
                    .HasForeignKey(d => d.ObjekatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rezervacija_objekat");
            });

            modelBuilder.Entity<TipObjektaSllike>(entity =>
            {
                entity.HasKey(e => e.TipObjektaSlikeId)
                    .HasName("PK__TipObjek__56FB740D7B5FF1C8");

                entity.ToTable("TipObjektaSllike");

                entity.Property(e => e.TipObjektaSlikeId).HasColumnName("TipObjektaSlikeID");

                entity.Property(e => e.ObjekatId).HasColumnName("ObjekatID");

                entity.HasOne(d => d.Objekat)
                    .WithMany(p => p.TipObjektaSllikes)
                    .HasForeignKey(d => d.ObjekatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tipobjekta");
            });

            modelBuilder.Entity<TipObjektum>(entity =>
            {
                entity.HasKey(e => e.TipObjektaId)
                    .HasName("PK__TipObjek__B4E393146D8F29A4");

                entity.Property(e => e.TipObjektaId).HasColumnName("TipObjektaID");

                entity.Property(e => e.Tip).HasMaxLength(50);
            });

            modelBuilder.Entity<Uloga>(entity =>
            {
                entity.ToTable("Uloga");

                entity.Property(e => e.UlogaId).HasColumnName("UlogaID");

                entity.Property(e => e.Naziv).HasMaxLength(20);

                entity.Property(e => e.OpisUloge).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
