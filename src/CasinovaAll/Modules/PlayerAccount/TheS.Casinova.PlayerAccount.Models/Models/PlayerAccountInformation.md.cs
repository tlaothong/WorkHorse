using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TheS.Casinova.PlayerAccount.Models
{
   [MetadataType(typeof(MD))]
   partial class PlayerAccountInformation
    {
       public class MD {

           public int PlayerAccoundID { get; set; }

           [Required]
           public string UserName { get; set; }

           public string FirstName { get; set; }

           public string LastName { get; set; }

           public string AccountType { get; set; }

           public string CardType { get; set; }

           public string AccountNo { get; set; }

           public int CVV { get; set; }

           public DateTime ExpireDate { get; set; }

           public bool Active { get; set; }
       }
    }
}
