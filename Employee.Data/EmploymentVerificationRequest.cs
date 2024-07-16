using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Data
{
	public class EmploymentVerificationRequest
	{
		[Key]
		public int EmployeeId { get; set; }
		[Required(ErrorMessage = "Please enter the company name")]
		public string? CompanyName { get; set; }
		[Required(ErrorMessage = "Please enter the verification code")]
		public string? VerificationCode { get; set; }
	}
}
