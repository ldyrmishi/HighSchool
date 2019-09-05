using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HighSchoolApplication.Infrastructure.Models
{
    public partial class HighSchoolContext : DbContext
    {
        public HighSchoolContext()
        {
        }

        public HighSchoolContext(DbContextOptions<HighSchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Absents> Absents { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Diary> Diary { get; set; }
        public virtual DbSet<DocumentCategory> DocumentCategory { get; set; }
        public virtual DbSet<Documents> Documents { get; set; }
        public virtual DbSet<FinalExams> FinalExams { get; set; }
        public virtual DbSet<Finances> Finances { get; set; }
        public virtual DbSet<Lesson> Lesson { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<School> School { get; set; }
        public virtual DbSet<SubjectPoints> SubjectPoints { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersClass> UsersClass { get; set; }
        public virtual DbSet<UsersStatus> UsersStatus { get; set; }
        public virtual DbSet<UsersSubjectPoints> UsersSubjectPoints { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:highschool-db.database.windows.net,1433;Initial Catalog=HighSchool;Persist Security Info=False;User ID={sa_B};Password={ledio.123};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Absents>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("AbsentsID");

                entity.Property(e => e.AbsentDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.IsJustificated).HasColumnName("isJustificated");

                entity.Property(e => e.LessonId).HasColumnName("LessonID");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.Reason).HasMaxLength(1000);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.Absents)
                    .HasForeignKey(d => d.LessonId)
                    .HasConstraintName("FK__Absents__LessonI__6C190EBB");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Absents)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Absents__UserID__6B24EA82");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("AddressID");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.StreetAddress).HasMaxLength(50);

                entity.Property(e => e.ZipCode).HasMaxLength(50);
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ClassID");

                entity.Property(e => e.ClassNo)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK__Class__SchoolId__4222D4EF");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Class__UserId__787EE5A0");
            });

            modelBuilder.Entity<Diary>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("DiaryID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("datetime");

                entity.Property(e => e.DiaryDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Diary)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__Diary__SubjectID__5FB337D6");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Diary)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Diary__UserID__5EBF139D");
            });

            modelBuilder.Entity<DocumentCategory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("DocumentCategoryID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Documents>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("DocumentID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DocumentCategoryId).HasColumnName("DocumentCategoryID");

                entity.Property(e => e.DocumentDescription).HasMaxLength(255);

                entity.Property(e => e.DocumentUrl).HasMaxLength(255);

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.DocumentCategory)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.DocumentCategoryId)
                    .HasConstraintName("FK__Documents__Docum__7E37BEF6");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__Documents__Subje__5BE2A6F2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Documents__UserI__5AEE82B9");
            });

            modelBuilder.Entity<FinalExams>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("FinalExamID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.PointsDate).HasColumnType("datetime");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.FinalExams)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__FinalExam__Subje__03F0984C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FinalExams)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__FinalExam__UserI__04E4BC85");
            });

            modelBuilder.Entity<Finances>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("FinanceID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.Finances)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK__Finances__School__7B5B524B");
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("LessonID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.DiaryId).HasColumnName("DiaryID");

                entity.Property(e => e.EndDateTime).HasColumnType("datetime");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.StartDateTime).HasColumnType("datetime");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Lesson)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__Lesson__ClassID__628FA481");

                entity.HasOne(d => d.Diary)
                    .WithMany(p => p.Lesson)
                    .HasForeignKey(d => d.DiaryId)
                    .HasConstraintName("FK__Lesson__DiaryID__6383C8BA");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Lesson)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__Lesson__SubjectI__6477ECF3");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("RoleID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.RoleDescription).HasMaxLength(50);
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.City).HasMaxLength(200);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Logo).HasMaxLength(200);

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<SubjectPoints>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("SubjectPointsID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.MarkType).HasMaxLength(50);

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.PointsDate).HasColumnType("datetime");

                entity.Property(e => e.PointsReason).HasMaxLength(50);

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.SubjectPoints)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__SubjectPo__Subje__3A81B327");
            });

            modelBuilder.Entity<Subjects>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("SubjectID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.SubjectDescription).HasMaxLength(50);

                entity.Property(e => e.SubjectTitle).HasMaxLength(50);

                entity.Property(e => e.Term).HasMaxLength(50);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("UserID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.Birthdate).HasColumnType("datetime");

                entity.Property(e => e.ConfirmPassword).HasMaxLength(1);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Firstname).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.Lastname).HasMaxLength(50);

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(1000);

                entity.Property(e => e.NrAmze).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(1);

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK__Users__AddressID__4BAC3F29");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Users__RoleID__4AB81AF0");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK__Users__SchoolID__6D0D32F4");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK__Users__StatusId__01142BA1");
            });

            modelBuilder.Entity<UsersClass>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("StudentID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.UsersClass)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__UsersClas__Class__5812160E");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersClass)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UsersClas__UserI__571DF1D5");
            });

            modelBuilder.Entity<UsersStatus>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("UsersStatusID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<UsersSubjectPoints>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("UserSubjectPointsID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.SubjectPointsId).HasColumnName("SubjectPointsID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.SubjectPoints)
                    .WithMany(p => p.UsersSubjectPoints)
                    .HasForeignKey(d => d.SubjectPointsId)
                    .HasConstraintName("FK__UsersSubj__Subje__68487DD7");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersSubjectPoints)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UsersSubj__UserI__6754599E");
            });
        }
    }
}
