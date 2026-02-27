using Service.Contracts;

public interface IServiceManager
{
    ICompanyService CompanyService { get; }  // ← PROMISE: "I will have this property"
    IEmployeeService EmployeeService { get; }
    IAuthenticationService AuthenticationService { get; }
}