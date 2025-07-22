namespace DevFreela.API.Entities
{
    //Nossa Entidade Base, vai ter apenas algumas configurações que são utilizadas em todas as entidades
    public abstract class BaseEntity
    {
        protected BaseEntity() //Construtor padrão para inicializar propriedades comuns
        {
            CreatedAt = DateTime.UtcNow; // Define a data de criação como a data atual em UTC
            IsDeleted = false; // Inicializa IsDeleted como false
        }
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public void SetAsDeleted()
        {
            IsDeleted = true;
        }
    }
}
