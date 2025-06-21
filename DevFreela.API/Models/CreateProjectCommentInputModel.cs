using System.Globalization;

namespace DevFreela.API.Models
{
    public class CreateProjectCommentInputModel
    {
        public String Content { get; set; }
        public int IdProject { get; set; }
        public int IdUser { get; set; }
    }
}
