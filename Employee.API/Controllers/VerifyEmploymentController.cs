using Employee.Data;
using Employee.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Employee.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VerifyEmploymentController : ControllerBase
	{
		private readonly IValidateUser _validate;
		public VerifyEmploymentController(IValidateUser validate)
		{
			_validate = validate;
		}

		[HttpPost, Route("verify-employment")]
		public IActionResult EmployeeVerification(EmploymentVerificationRequest model)
		{
			bool isValidEmployee = _validate.ValidateEmpDetails(model);
			bool isValidCode = _validate.ValidateCode(model.EmployeeId, model.VerificationCode);
			int getStatusCode = 0;
			if (isValidEmployee && isValidCode)
			{
				getStatusCode = (int)HttpStatusCode.OK;
			}
			else
			{
				getStatusCode = (int)HttpStatusCode.BadRequest;
			}
			var response = new EmploymentVerificationResponse
			{
				StatusCode = getStatusCode,
				IsVerified = isValidEmployee && isValidCode,
				Message = isValidEmployee && isValidCode ? "Employment verified." : "Invalid employee ID or verification code."
			};
			if (isValidEmployee && isValidCode)
			{
				return Ok(response);
			}
			else
			{
				return BadRequest(response);
			}
		}
	}
}
