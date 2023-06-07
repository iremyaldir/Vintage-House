namespace VintageHouse.Repositories
{
    public interface IShowroomRepository
    {
        Task<IEnumerable<Category>> Categories();
        
        Task<IEnumerable<Product>> GetProducts(string search = "", int categoryId = 0);
    }
}