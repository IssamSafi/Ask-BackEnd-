using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FinalProject.core.Data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aboutusf> Aboutusfs { get; set; }

        public virtual DbSet<Asking> Askings { get; set; }
        public virtual DbSet<Categoryf> Categoryfs { get; set; }
        public virtual DbSet<CommonQuestion> CommonQuestions { get; set; }
        public virtual DbSet<Contactusf> Contactusfs { get; set; }
        public virtual DbSet<Homef> Homefs { get; set; }
        public virtual DbSet<Loginf> Loginfs { get; set; }
        public virtual DbSet<Rolef> Rolefs { get; set; }
        public virtual DbSet<Testimonialf> Testimonialves { get; set; }
        public virtual DbSet<Userf> Userves { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("USER ID=TAH14_USER49;PASSWORD=Test321;DATA SOURCE=94.56.229.181:3488/traindb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TAH14_USER49")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");


            modelBuilder.Entity<Aboutusf>(entity =>
            {
                entity.ToTable("ABOUTUSF");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Description_)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION_");

                entity.Property(e => e.Image)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE");
            });


            modelBuilder.Entity<Asking>(entity =>
            {
                entity.ToTable("ASKING");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Askingdate)
                    .HasColumnType("DATE")
                    .HasColumnName("ASKINGDATE");

                entity.Property(e => e.Itsapprove)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ITSAPPROVE");

                entity.Property(e => e.Messege)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MESSEGE");

                entity.Property(e => e.User_Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Askings)
                    .HasForeignKey(d => d.User_Id)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ASKINGFK");
            });

            modelBuilder.Entity<Categoryf>(entity =>
            {
                entity.ToTable("CATEGORYF");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Category_Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORY_NAME");

                entity.Property(e => e.Image_Path)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH");
            });

            modelBuilder.Entity<CommonQuestion>(entity =>
            {
                entity.ToTable("COMMON_QUESTION");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Question)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("QUESTION");
            });


            modelBuilder.Entity<Contactusf>(entity =>
            {
                entity.ToTable("CONTACTUSF");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Messege)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("MESSEGE");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<Homef>(entity =>
            {
                entity.HasKey(e => e.Home_Id)
                    .HasName("SYS_C00297880");

                entity.ToTable("HOMEF");

                entity.Property(e => e.Home_Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("HOME_ID");

                entity.Property(e => e.Description_)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION_");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.Welcome_Iamge)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("WELCOME_IAMGE");
            });

            modelBuilder.Entity<Loginf>(entity =>
            {
                entity.ToTable("LOGINF");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Role_Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.User_Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.Property(e => e.User_Name)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Loginfs)
                    .HasForeignKey(d => d.Role_Id)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ROLEEFK");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Loginfs)
                    .HasForeignKey(d => d.User_Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("USERRFK");
            });

            modelBuilder.Entity<Rolef>(entity =>
            {
                entity.ToTable("ROLEF");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Role_Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_NAME");
            });

            modelBuilder.Entity<Testimonialf>(entity =>
            {
                entity.ToTable("TESTIMONIALF");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Itsapprove)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ITSAPPROVE")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.Messege)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("MESSEGE");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.User_Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Testimonialves)
                    .HasForeignKey(d => d.User_Id)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("TESTIM");
            });

            modelBuilder.Entity<Userf>(entity =>
            {
                entity.ToTable("USERF");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FNAME");

                entity.Property(e => e.Image_Path)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH");

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LNAME");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");
            });


            modelBuilder.HasSequence("NEWVALUE").IncrementsBy(2);

            modelBuilder.HasSequence("NEWWVALUE").IncrementsBy(3);

            modelBuilder.HasSequence("REVSEQ").IncrementsBy(-1);

            modelBuilder.HasSequence("UAE_SEQUENCE").IncrementsBy(10);

            modelBuilder.HasSequence("X").IncrementsBy(2);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
