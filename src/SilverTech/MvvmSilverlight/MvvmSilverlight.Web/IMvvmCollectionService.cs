using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MvvmSilverlight.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMvvmCollectionService" in both code and config file together.
    [ServiceContract]
    public interface IMvvmCollectionService
    {
        [OperationContract]
        IEnumerable<Person> ListPeople();
    }
}
