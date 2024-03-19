using Microsoft.Extensions.Hosting;

namespace study_project.model
{
    public class Customer
    {
        public int ID { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public bool isActive { get; set; }
        public List<Itens> itens { get; } = [];
    }
}
