using study_project.model;

namespace study_project.repository
{
    public interface ICartRepository : IDisposable
    {
        IEnumerable<Cart> GetCarts();
        Cart getCartById(int cartID);
        void CreateCart(Cart cart);
        void DeleteCart(int cartID);
        void UpdateCart(Cart cart);
        void Save();
    }
}
