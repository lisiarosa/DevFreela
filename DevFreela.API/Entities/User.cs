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
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool Active { get; private set; }

    }
}
