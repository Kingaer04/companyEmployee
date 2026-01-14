using Entities.Models;

public interface ICompanyService
{
    IEnumerable<Company> GetAllCompanies(bool trackChanges);
}