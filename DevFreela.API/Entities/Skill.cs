using System.Globalization;

namespace DevFreela.API.Entities
{
    public class Skill : BaseEntity // Herança da classe BaseEntity
    {
        public Skill(string description)
            : base() // Chama o construtor da classe base BaseEntity
        {
            Description = description;
        }
        public String Description { get; private set; }

        
    }
}
