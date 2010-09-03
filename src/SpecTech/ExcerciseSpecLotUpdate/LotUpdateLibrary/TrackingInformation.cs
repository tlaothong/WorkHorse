using System;

namespace PerfEx.Infrastructure.LotUpdate
{
    public partial class TrackingInformation
    {
        public Guid TrackingID { get; set; }
        public string Status { get; set; }

        // For client use only
        public string LotNo { get; set; }
    }
}
