namespace Employee.Web
{
	public class HelpersApi
	{
		HttpClientHandler httpClientHandler = new HttpClientHandler();
		public HelpersApi()
		{
			httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
		}

		public HttpClient Initial()
		{
			var client = new HttpClient(httpClientHandler);
			client.BaseAddress = new Uri("https://localhost:7142/");
			return client;
		}
	}
}
