using study_project.model;

namespace study_project.repository
{
    public interface IItensRepository
    {
        IEnumerable<Itens> getItens();
        Itens getItensById(int itensId);
        void insertItens(Itens itens);
        void DeleteItens(int itensId);
        void UpdateItens(Itens itens);
        void Save();
    }
}
