namespace study_project.model
{
    public class Cart
    {
        public int ID { get; set; }
        public List<Customer> customerItens { get; set; }
        public string status { get; set; }
        public List<Itens>  itensLists { get; set; }
    }
}
