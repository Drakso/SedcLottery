using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Lottery.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            // This is the initializing of the AutoFac IOC Container
            // We call the initialize function here which initializes the container
            // Since the container methods are static we can call them without making an instance of the class anywhere
            IocConfig.Initialize(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configuration
      .Formatters
      .JsonFormatter
      .SerializerSettings
      .ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
