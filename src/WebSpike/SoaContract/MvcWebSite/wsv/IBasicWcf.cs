using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MvcWebSite.Models.Services;

namespace MvcWebSite.wsv
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBasicWcf" in both code and config file together.
    [ServiceContract]
    public interface IBasicWcf
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        BasicSimpleResponse BasicSimple(BasicSimpleRequest req);
    }
}
