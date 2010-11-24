using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SimpleNotif.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OhSimpleService" in code, svc and config file together.
    public class OhSimpleService : IOhSimpleService
    {
        public void SendInfo(Guid trackingId, string message)
        {
            SampleData.TrackingInfos.Add(
                new PerfEx.Infrastructure.LotUpdate.TrackingInformation {
                    TrackingID = trackingId,
                    Status = message,
                });
        }

        public Guid SendMessage(string message)
        {
            Guid trackingId = Guid.NewGuid();

            SampleData.TrackingInfos.Add(
                new PerfEx.Infrastructure.LotUpdate.TrackingInformation {
                    TrackingID = trackingId,
                    Status = message,
                });

            return trackingId;
        }
    }
}
