using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PerfEx.Infrastructure.LotUpdate;
using System.Diagnostics;

namespace SimpleNotif.Web
{
    /// <summary>
    /// Summary description for GetLotData
    /// </summary>
    public class GetLotData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string lotNo = context.Request.QueryString["lot"];
            string prevLotNo = "";
            var qry = from it in SampleData.TrackingInfos
                      where it.LotNo == lotNo
                      select it;
            var qryPrev = from it in SampleData.TrackingInfos
                          where string.Compare(it.LotNo, lotNo) < 0
                          select it.LotNo;
            if (qryPrev.Any()) {
                prevLotNo = qryPrev.Max();
            }

            LotWriter writer = new LotWriter();
            //Trace.Assert(lotNo != null, "lotNo");
            //Trace.Assert(prevLotNo != null, "prevLotNo");
            //Trace.Assert(context.Response.Output != null, "output");
            writer.WriteLotData(context.Response.Output
                , lotNo
                , prevLotNo, "http://localhost:49491/GetLotData.ashx?lot={0}"
                , qry);
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