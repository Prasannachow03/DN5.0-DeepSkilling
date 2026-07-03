namespace HOL4_DependencyInjection.Services;
public interface IProductService
{
    IEnumerable<string> GetAll();
    string GetById(int id);
    void Add(string product);
}