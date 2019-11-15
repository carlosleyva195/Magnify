using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using RestSharp.Authenticators;

namespace Magnify.Controllers
{
    public class MailController : Controller
    {
        public static IRestResponse SendSimpleMessage(IdentityMessage message)
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator = new HttpBasicAuthenticator("api",
                                "aad5f7e3a9082ad9340b7422bc34bcde-2416cf28-055585c1"); RestRequest request = new RestRequest();
            request.AddParameter("domain", "blackmarlingroup.mx", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "<Info@xipetechnology.com>");
            //request.AddParameter("to", message.Destination);
            request.AddParameter("to", "carlos@xipetechnology.com");
            request.AddParameter("subject", message.Subject);
            request.AddParameter("html", message.Body);
            request.Method = Method.POST;
            var result = client.Execute(request);
            return result;
        }
    }
}
