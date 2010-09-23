using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MvcWebSite.Models.Services;

namespace MvcWebSite.wsv
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BasicWcf" in code, svc and config file together.
    public class BasicWcf : IBasicWcf
    {
        public void DoWork()
        {
        }

        public Models.Services.BasicSimpleResponse BasicSimple(Models.Services.BasicSimpleRequest req)
        {
            return new BasicSimpleResponse {
                Message = "RSP: " + req.Message,
            };
        }
    }
}
