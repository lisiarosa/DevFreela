using DevFreela.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.API.Persistence
{
    public class DevFreelaDbContext : DbContext
    {
        public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options)
            : base(options)
        {
            
        }
        //configuração padrão do banco, onde eu faço o construtor acima "vazio" e declaro as tabelas abaixo
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<ProjectComment> ProjectComments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Skill>(e =>
                {
                    e.HasKey(s => s.Id); // Define a chave primária da tabela Skill
                });

            builder
                .Entity<UserSkill>(e =>
                {
                    e.HasKey(us => us.Id); // Define a chave primária da tabela UserSkill
                    e.HasOne(u => u.Skill)
                        .WithMany(u => u.UserSkills) // Configura o relacionamento entre UserSkill e Skill, onde uma Skill pode ter várias UserSkills
                        .HasForeignKey( s => s.IdSkill) // Define a chave estrangeira na tabela UserSkill
                        .OnDelete(DeleteBehavior.Restrict); // Configura o relacionamento entre UserSkill e Skill, impedindo a exclusão em cascata
                });

            builder
                .Entity<ProjectComment>(e =>
                {
                    e.HasKey(p => p.Id); // Define a chave primária da tabela ProjectComment

                    e.HasOne(p => p.Project) // Configura o relacionamento entre ProjectComment e Project, onde um Project pode ter vários comentários
                        .WithMany(p => p.Comments) // Define o relacionamento inverso, onde um Project pode ter vários comentários
                        .HasForeignKey(p => p.IdProject)// Define a chave estrangeira na tabela ProjectComment
                        .OnDelete(DeleteBehavior.Restrict); // Impede a exclusão em cascata, ou seja, se um projeto for excluído, os comentários não serão excluídos automaticamente
                });

            builder
                .Entity<User>(e =>
                {
                    e.HasKey(u => u.Id);

                    e.HasMany(u => u.Skills)
                        .WithOne(us => us.User) // Configura o relacionamento entre User e UserSkill, onde um User pode ter várias UserSkills
                        .HasForeignKey(us => us.IdUser) // Define a chave estrangeira na tabela UserSkill
                        .OnDelete(DeleteBehavior.Restrict); // Impede a exclusão em cascata, ou seja, se um usuário for excluído, as UserSkills não serão excluídas automaticamente
                });

            builder
                .Entity<Project>(e =>
                {
                    e.HasKey(p => p.Id);

                    e.HasOne(p => p.Freelancer) 
                        .WithMany(f => f.FreelanceProjects)
                        .HasForeignKey(p => p.IdFreelancer) // Define a chave estrangeira na tabela Project
                        .OnDelete(DeleteBehavior.Restrict);

                    e.HasOne(p => p.Client)
                        .WithMany(c => c.OwnedProjects) // Configura o relacionamento entre Project e User, onde um User pode ter vários projetos próprios
                        .HasForeignKey(p => p.IdClient) // Define a chave estrangeira na tabela Project
                        .OnDelete(DeleteBehavior.Restrict);
                });

            base.OnModelCreating(builder);
        }
    }
}
