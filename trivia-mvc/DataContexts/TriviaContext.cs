using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using trivia_mvc.Models;

#nullable disable

namespace trivia_mvc.DataContexts
{
    public partial class TriviaContext : DbContext
    {
        public TriviaContext(DbContextOptions<TriviaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Trivia> Trivias { get; set; }
        public virtual DbSet<TriviasQuestionsReceived> TriviasQuestionsReceiveds { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "English_United States.1252");

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.HasKey(e => new { e.IdQuestion, e.IdAnswer })
                    .HasName("answers_pkey");

                entity.ToTable("answers");

                entity.Property(e => e.IdQuestion)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_question");

                entity.Property(e => e.IdAnswer)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_answer");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.IsCorrect).HasColumnName("is_correct");

                entity.HasOne(d => d.IdQuestionNavigation)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.IdQuestion)
                    .HasConstraintName("answers_id_question_fkey");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("categories_pkey");

                entity.ToTable("categories");

                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .HasColumnName("name")
                    .HasComment(" ");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.IdQuestion)
                    .HasName("questions_pkey");

                entity.ToTable("questions");

                entity.Property(e => e.IdQuestion).HasColumnName("id_question");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("category");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.Category)
                    .HasConstraintName("questions_category_fkey");
            });

            modelBuilder.Entity<Trivia>(entity =>
            {
                entity.HasKey(e => e.IdTrivia)
                    .HasName("trivias2_pkey");

                entity.ToTable("trivias");

                entity.Property(e => e.IdTrivia)
                    .HasColumnName("id_trivia")
                    .HasDefaultValueSql("nextval('trivias2_id_trivia_seq'::regclass)");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("category");

                entity.Property(e => e.DateMade).HasColumnName("date_made");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Trivia)
                    .HasForeignKey(d => d.Category)
                    .HasConstraintName("trivias_category_fkey");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Trivia)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("trivias2_id_user_fkey");
            });

            modelBuilder.Entity<TriviasQuestionsReceived>(entity =>
            {
                entity.HasKey(e => new { e.IdTrivia, e.IdQuestion })
                    .HasName("trivias_questions_received_pkey");

                entity.ToTable("trivias_questions_received");

                entity.Property(e => e.IdTrivia).HasColumnName("id_trivia");

                entity.Property(e => e.IdQuestion).HasColumnName("id_question");

                entity.HasOne(d => d.IdQuestionNavigation)
                    .WithMany(p => p.TriviasQuestionsReceiveds)
                    .HasForeignKey(d => d.IdQuestion)
                    .HasConstraintName("trivias_questions_received_id_question_fkey");

                entity.HasOne(d => d.IdTriviaNavigation)
                    .WithMany(p => p.TriviasQuestionsReceiveds)
                    .HasForeignKey(d => d.IdTrivia)
                    .HasConstraintName("trivias_questions_received_id_trivia_fkey");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("users_pkey");

                entity.ToTable("users");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.DateBirth)
                    .HasColumnType("date")
                    .HasColumnName("date_birth");

                entity.Property(e => e.DateIn).HasColumnName("date_in");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
