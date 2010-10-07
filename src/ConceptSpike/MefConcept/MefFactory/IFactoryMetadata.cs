using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MefFactory
{
    public interface IFactoryMetadata
    {
        Type TargetType { get; }
    }
}
