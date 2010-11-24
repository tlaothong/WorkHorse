using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace MefFactory.RealConcepts
{
    public abstract class MefServiceObjectProviderBase<T> : IServiceObjectProvider<T>
        where T : class
    {
        public MefServiceObjectProviderBase(CompositionContainer container)
        {
            container.ComposeParts(this);
        }

        [Import]
        public T ServiceProxy { get; set; }
    }

    public abstract class MefServiceObjectProviderBase<T, I> : IServiceObjectProvider<I>
        where T : class, I
        where I : class
    {
        public MefServiceObjectProviderBase(CompositionContainer container)
        {
            container.ComposeParts(this);
        }

        [Import]
        public T ServiceObject { get; set; }

        public I ServiceProxy
        {
            get { return ServiceObject; }
        }
    }

    // These classes are OK but should not in the framework!
    public class MefServiceObjectProvider<T> : MefServiceObjectProviderBase<T>
        where T : class
    {
        public MefServiceObjectProvider(CompositionContainer container)
            : base(container)
        {
        }
    }

    public class MefServiceObjectProvider<T, I> : MefServiceObjectProviderBase<T, I>
        where T : class, I
        where I : class
    {
        public MefServiceObjectProvider(CompositionContainer container)
            : base(container)
        {
        }
    }
}
