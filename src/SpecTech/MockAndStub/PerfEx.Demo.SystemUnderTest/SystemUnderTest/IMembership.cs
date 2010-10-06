using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;

namespace PerfEx.Demo.SystemUnderTest
{
    public interface IMembership
    {
        IPrincipal User { get; }
    }
}
