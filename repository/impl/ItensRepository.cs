using Microsoft.EntityFrameworkCore;
using study_project.db;
using study_project.model;

namespace study_project.repository.impl
{
    public class ItensRepository : IItensRepository, IDisposable
    {

        private DatabaseContext context;

        public ItensRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public void DeleteItens(int itensId)
        {
            throw new NotImplementedException();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Itens> getItens()
        {
            return context.itens.ToList();
        }

        public Itens getItensById(int itensId)
        {
            throw new NotImplementedException();
        }

        public void insertItens(Itens itens)
        {
            context.itens.Add(itens);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateItens(Itens itens)
        {
            context.Entry(itens).State = EntityState.Modified;

        }
    }
}
