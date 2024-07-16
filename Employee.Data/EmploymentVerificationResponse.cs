using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Data
{
	public class EmploymentVerificationResponse
	{
		public int StatusCode { get; set; }
		public bool IsVerified { get; set; } = false;
		public string? Message { get; set; }
	}
}
