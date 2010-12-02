using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MefFactory.RealConcepts
{
    public interface IServiceObjectProvider<T>
        where T : class
    {
        /// <summary>
        /// Gets the service instance.
        /// </summary>
        T ServiceProxy { get; }
    }
}
