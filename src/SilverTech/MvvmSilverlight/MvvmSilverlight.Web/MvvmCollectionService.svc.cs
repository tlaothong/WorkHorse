using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MvvmSilverlight.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MvvmCollectionService" in code, svc and config file together.
    public class MvvmCollectionService : IMvvmCollectionService
    {
        public IEnumerable<Person> ListPeople()
        {
            return new Person[] {
                new Person {
                    FirstName = "John",
                    LastName = "Doe",
                    BirthDate = DateTime.Today.AddYears(-17),
                },
                new Person {
                    FirstName = "Tom",
                    LastName = "Hanks",
                    BirthDate = DateTime.Today.AddYears(-24),
                },
                new Person {
                    FirstName = "Tom",
                    LastName = "Cruise",
                    BirthDate = DateTime.Today.AddYears(-27),
                },
            };
        }
    }
}
