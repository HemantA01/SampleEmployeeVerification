using Employee.Data;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net;
using System.Text;

namespace Employee.Web.Service
{
	public class ValidateUser : IValidateUser
	{
		private readonly ApplicationContext _context;
		private readonly HelpersApi aPIHelper;
		public ValidateUser(ApplicationContext context)
		{
			_context = context;
			this.aPIHelper = new HelpersApi();
		}
		public async Task<EmploymentVerificationResponse> ValidateResponse(EmploymentVerificationRequest model)
		{
			try
			{
				EmploymentVerificationResponse userLoginResult = new EmploymentVerificationResponse();
				var client = aPIHelper.Initial();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				var company = System.Text.Json.JsonSerializer.Serialize(model);
				var requestContent = new StringContent(company, Encoding.UTF8, "application/json");
				var response = await client.PostAsync("api/VerifyEmployment/verify-employment", requestContent);
				var result1 = response.Content.ReadAsStringAsync().Result;
				var content = await response.Content.ReadAsStringAsync();


				if (response.StatusCode == HttpStatusCode.OK)
				{
					userLoginResult = JsonConvert.DeserializeObject<EmploymentVerificationResponse>(await response.Content.ReadAsStringAsync());
				}
				else if (response.StatusCode == HttpStatusCode.InternalServerError)
				{
					throw new Exception(await response.Content.ReadAsStringAsync());
				}

				return userLoginResult;
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}
