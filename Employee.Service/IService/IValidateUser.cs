using Employee.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Service.IService
{
	public interface IValidateUser
	{
		bool ValidateEmpDetails(EmploymentVerificationRequest model);
		bool ValidateCode(int employeeId, string? verificationCode);

	}
}
