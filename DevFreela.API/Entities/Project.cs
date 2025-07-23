using DevFreela.API.Controllers;
using DevFreela.API.Enums;

namespace DevFreela.API.Entities
{
    public class Project : BaseEntity // Herança da classe BaseEntity
    {
        public Project(string title, string description, int idClient, int idFreelancer, decimal totalCost)
            : base() // Chama o construtor da classe base BaseEntity
        {
            Title = title;
            Description = description;
            IdClient = idClient;
            IdFreelancer = idFreelancer;
            TotalCost = totalCost;

            Status = ProjectStatusEnum.Created; // Inicializa o status do projeto como "Criado"
            Comments = []; // Inicializa a lista de comentários como uma nova lista vazia 
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public int IdClient { get; private set; }
        public User Client { get; private set; } // Propriedade de navegação para o cliente
        public int IdFreelancer { get; private set; }
        public User Freelancer { get; private set; } // Propriedade de navegação para o freelancer

        public decimal TotalCost { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? CompletedAt { get; private set; }
        public ProjectStatusEnum Status { get; private set; } // Status do projeto
        public List<ProjectComment> Comments { get; private set; }
        public void Cancel()
        {
            if (Status == ProjectStatusEnum.InProgress || Status == ProjectStatusEnum.Suspended)
            {
                Status = ProjectStatusEnum.Cancelled; // Altera o status do projeto para "Cancelado"
            }
        }

        public void Start()
        {
            if (Status == ProjectStatusEnum.Created)
            {
                Status = ProjectStatusEnum.InProgress; // Altera o status do projeto para "Em Andamento"
                StartedAt = DateTime.Now; // Define a data de início como a data atual
            }
        }

        public void Complete()
        {
            if (Status == ProjectStatusEnum.PaymentPending || Status == ProjectStatusEnum.InProgress)
            {
                Status = ProjectStatusEnum.Completed; // Altera o status do projeto para "Concluído"
                CompletedAt = DateTime.Now; // Define a data de conclusão como a data atual
            }
        }

        public void SetPaymentPending()
        {
            if (Status == ProjectStatusEnum.InProgress)
            {
                Status = ProjectStatusEnum.PaymentPending; // Altera o status do projeto para "Pagamento Pendente"
            }
        }

        public void Update(string title,string description, decimal totalCost)
        {
            Title = title; // Atualiza o título do projeto
            Description = description; // Atualiza a descrição do projeto
            TotalCost = totalCost; // Atualiza o custo total do projeto
        }

    }
}
