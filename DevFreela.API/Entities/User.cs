namespace DevFreela.API.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, DateTime birthDate)
            : base() // Chama o construtor da classe base BaseEntity
        {
            FullName = fullName; // Define o nome completo do usuário
            Email = email; // Define o e-mail do usuário
            BirthDate = birthDate; // Define a data de nascimento
            Active = true; // Inicializa como ativo por padrão

            Skills = []; // Inicializa a lista de habilidades como uma nova lista vazia
            OwnedProjects = []; // Inicializa a lista de projetos próprios como uma nova lista vazia
            FreelanceProjects = []; // Inicializa a lista de projetos freelance como uma nova lista vazia
            Comments = []; // Inicializa a lista de comentários como uma nova lista vazia
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool Active { get; private set; }

        public List< UserSkill> Skills { get; private set; }
        public List<Project> OwnedProjects { get; private set; }
        public List<Project> FreelanceProjects { get; private set; }
        public List<ProjectComment> Comments { get; private set; }

    }
}
