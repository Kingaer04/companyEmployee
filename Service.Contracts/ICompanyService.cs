using Entities.Models;

public interface ICompanyService
{
    IEnumerable<Company> GetAllCompanis(bool trackChanges);
}