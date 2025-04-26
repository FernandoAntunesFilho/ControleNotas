using ControleNotas.src.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleNotas.src.context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Nota> Notas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Aluno>()
                .HasIndex(a => a.Matricula)
                .IsUnique();

            modelBuilder.Entity<Professor>()
                .HasOne(p => p.Disciplina)
                .WithMany(d => d.Professores)
                .HasForeignKey(p => p.DisciplinaId)
                .OnDelete(DeleteBehavior.Restrict);
        
            modelBuilder.Entity<Nota>()
                .HasOne(n => n.Aluno)
                .WithMany(a => a.Notas)
                .HasForeignKey(n => n.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Nota>()
                .HasOne(n => n.Disciplina)
                .WithMany(d => d.Notas)
                .HasForeignKey(n => n.DisciplinaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}