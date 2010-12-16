using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.Common.Services.ImplementationServices
{
    public class GenerateTrackingID 
        : IGenerateTrackingID
    {
        Guid IGenerateTrackingID.GenerateTrackingID()
        {
            return Guid.NewGuid();
        }
    }
}
