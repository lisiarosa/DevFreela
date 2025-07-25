namespace DevFreela.API.Entities
{
    public class ProjectComment: BaseEntity
    {
        public ProjectComment(string content, int idProject,int idUser)
        {
            Content = content; // Define o conteúdo do comentário
            IdProject = idProject; // Define o ID do projeto ao qual o comentário pertence
            IdUser = idUser; // Define o ID do usuário que fez o comentário
        }
        public string Content { get; private set; }
        public int Id { get; private set; }
        public int IdProject { get; private set; }
        public Project Project { get; private set; }
        public int IdUser { get; private set; }
        public User User { get; private set; }
    }
}
