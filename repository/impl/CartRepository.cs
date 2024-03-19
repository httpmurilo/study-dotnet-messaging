using Microsoft.EntityFrameworkCore;
using study_project.db;
using study_project.model;

namespace study_project.repository.impl
{
    public class CartRepository : ICartRepository, IDisposable
    {
        private DatabaseContext context;

        public CartRepository(DatabaseContext context)
        {
            this.context = context;
            
        }
        public void CreateCart(Cart cart)
        {
            context.cart.Add(cart);
        }

        public void DeleteCart(int cartID)
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

        public Cart getCartById(int cartID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cart> GetCarts()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateCart(Cart cart)
        {
            context.Entry(cart).State = EntityState.Modified;
        }
    }
}
