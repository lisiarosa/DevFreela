using System.Globalization;

namespace DevFreela.API.Entities
{
    public class Skill : BaseEntity // Herança da classe BaseEntity
    {
        public Skill(string description)
            : base() // Chama o construtor da classe base BaseEntity
        {
            Description = description; //teste
        }
        public String Description { get; private set; }
        public List<UserSkill> UserSkills { get; private set; } // Lista de UserSkills associadas a esta Skill


    }
}
