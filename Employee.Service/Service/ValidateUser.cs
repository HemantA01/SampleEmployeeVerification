using Employee.Data;
using Employee.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Service.Service
{
	public class ValidateUser : IValidateUser
	{
		private readonly ApplicationContext _context;
		public ValidateUser(ApplicationContext context)
		{ 
			_context = context;
		}
		public bool ValidateEmpDetails(EmploymentVerificationRequest model)
		{
			var getdetails = _context.tblEmployeeVerification.Where(x => x.EmployeeId == model.EmployeeId && x.CompanyName == model.CompanyName).FirstOrDefault();
			if (getdetails != null)
				return true;
			else
				return false;
		}
		public bool ValidateCode(int employeeId, string? verificationCode)
		{
			var getdetails = _context.tblEmployeeVerification.Where(x => x.EmployeeId == employeeId && x.VerificationCode == verificationCode).FirstOrDefault();
			if (getdetails != null)
				return true;
			else
				return false;
		}
	}
}
