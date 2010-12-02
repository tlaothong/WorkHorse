using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PerfEx.Infrastructure.LotUpdate;

namespace SimpleNotif.Web
{
    /// <summary>
    /// Summary description for LatestLotNo
    /// </summary>
    public class LatestLotNo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            var qryNull = from it in SampleData.TrackingInfos
                          where string.IsNullOrEmpty(it.LotNo)
                          select it;
            if (qryNull.Any()) {
                string newLotNo = DateTime.Now.Ticks.ToString();
                foreach (var item in qryNull) {
                    item.LotNo = newLotNo;
                }
            }

            var qry = from it in SampleData.TrackingInfos
                      select it.LotNo;
            string lotNo = qry.Any() ? qry.Max() : "";

            LotWriter writer = new LotWriter();
            writer.WriteLotNo(context.Response.Output
                , lotNo,
                "http://localhost:49491/GetLotData.ashx?lot={0}");
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