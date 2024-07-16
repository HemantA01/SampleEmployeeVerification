using Employee.Data;
using Employee.Web.Service;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Web.Controllers
{
	public class EmpValidateController : Controller
	{
		private readonly IValidateUser _ivalid;
		public EmpValidateController(IValidateUser ivalid)
		{
			_ivalid = ivalid;
		}

		public IActionResult EmploymentVerificationForm()
		{
			return View();
		}
		[HttpPost]
		public async Task<JsonResult> EmploymentVerification(EmploymentVerificationRequest model)
		{
			var details = await _ivalid.ValidateResponse(model);
			if (details != null)
			{
				return Json(details);
			}
			return Json(null);
		}
	}
}
