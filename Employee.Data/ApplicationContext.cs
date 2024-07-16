using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Data
{
	public class ApplicationContext: DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options) { }
		public virtual DbSet<EmploymentVerificationRequest> tblEmployeeVerification { get; set; }
	}
}
