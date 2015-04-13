using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mrodaAzureTest
{
    /// <summary>
    /// Summary description for WebHookHandler
    /// </summary>
    public class WebHookHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}