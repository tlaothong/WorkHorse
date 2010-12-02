using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PerfEx.Infrastructure.LotUpdate
{
    public class LotWriter
    {
        public void WriteLotNo(TextWriter writer, string lotNo, string lotDataUrlFormatString)
        {
            if (string.IsNullOrEmpty(lotNo)) {
                throw new ArgumentNullException("lotNo");
            }

            writer.WriteLine(lotNo);
            if (!string.IsNullOrEmpty(lotDataUrlFormatString)) {
                writer.WriteLine(lotDataUrlFormatString, lotNo);
            }
        }
        public void WriteLotNo(TextWriter writer, string lotNo)
        {
            WriteLotNo(writer, lotNo, null);
        }

        public string WriteLotNo(string lotNo, string lotDataUrlFormatString)
        {
            if (string.IsNullOrEmpty(lotNo)) {
                throw new ArgumentNullException("lotNo");
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(lotNo);
            if (!string.IsNullOrEmpty(lotDataUrlFormatString)) {
                sb.AppendFormat(lotDataUrlFormatString, lotNo);
                sb.AppendLine();
            }
            return sb.ToString();
        }
        public string WriteLotNo(string lotNo)
        {
            return WriteLotNo(lotNo, null);
        }

        public void WriteLotData(TextWriter writer, string lotNo, string prevLotNo, string lotDataUrlFormatString, IEnumerable<TrackingInformation> trackingInfo)
        {
            if (string.IsNullOrEmpty(lotNo)) {
                throw new ArgumentNullException("lotNo");
            }
            if (string.IsNullOrEmpty(prevLotNo)) {
                throw new ArgumentNullException("prevLotNo");
            }
            writer.WriteLine(lotNo);
            writer.WriteLine(prevLotNo);
            if (string.IsNullOrEmpty(lotDataUrlFormatString)) {
                writer.WriteLine();
            }
            else {
                writer.WriteLine(lotDataUrlFormatString, prevLotNo);
            }
            foreach (var item in trackingInfo) {
                writer.WriteLine("{0:N}:{1}", item.TrackingID, item.Status);
            }
        }
        public string WriteLotData(string lotNo, string prevLotNo, string lotDataUrlFormatString, IEnumerable<TrackingInformation> trackingInfo)
        {
            if (string.IsNullOrEmpty(lotNo)) {
                throw new ArgumentNullException("lotNo");
            }
            if (string.IsNullOrEmpty(prevLotNo)) {
                throw new ArgumentNullException("prevLotNo");
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(lotNo);
            sb.AppendLine(prevLotNo);
            if (string.IsNullOrEmpty(lotDataUrlFormatString)) {
                sb.AppendLine();
            }
            else {
                sb.AppendFormat(lotDataUrlFormatString, prevLotNo).AppendLine();
            }
            foreach (var item in trackingInfo) {
                sb.AppendFormat("{0:N}:{1}", item.TrackingID, item.Status).AppendLine();
            }
            return sb.ToString();
        }
    }
}
