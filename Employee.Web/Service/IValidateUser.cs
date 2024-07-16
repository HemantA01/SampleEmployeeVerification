using Employee.Data;

namespace Employee.Web.Service
{
	public interface IValidateUser
	{
		Task<EmploymentVerificationResponse> ValidateResponse(EmploymentVerificationRequest model);
	}
}
