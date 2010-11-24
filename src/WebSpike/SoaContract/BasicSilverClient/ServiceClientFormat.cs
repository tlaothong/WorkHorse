using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace BasicSilverClient
{
    public class ServiceClientFormat
    {
        public void UsingWebSer()
        {
            var svc = new BasicWebSerThruWcf.BasicWebServiceSoapClient();
            BasicWebSerThruWcf.BasicWebServiceSoapChannel ch = null;
            BasicWebSerThruWcf.BasicWebServiceSoap itf = null;
            itf.BeginBasicSimple(new BasicWebSerThruWcf.BasicSimpleRequest {
                Message = ""
            }, null, null);
            itf.EndBasicSimple(null);
        }

        public void UsingWcf()
        {
            var svc = new BasicWcfSvc.BasicWcfClient();
            BasicWcfSvc.IBasicWcfChannel ch = null;
            BasicWcfSvc.IBasicWcf itf = null;
            itf.BeginBasicSimple(new BasicWcfSvc.BasicSimpleRequest {
                Message = ""
            }, null, null);
            itf.EndBasicSimple(null);
        }
    }
}
