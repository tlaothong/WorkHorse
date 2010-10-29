using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.ChipExchange.Models
{
   public class ExchangeInformation
    {
       /// <summary>
       /// จำนวนเงิน
       /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// ชื่อผู้เล่น
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// ประเภทของบัตรเครดิต
        /// </summary>
        public string CardType { get; set; }

        /// <summary>
        /// หมายเลขบัญชี
        /// </summary>
        public int AccountNo { get; set; }

        /// <summary>
        /// รหัสตรวจสอบหมายเลขบัญชี
        /// </summary>
        public int CVV { get; set; }

        /// <summary>
        /// วันหมดอายุของบัญชี
        /// </summary>
        public DateTime ExpireDate { get; set; }

        /// <summary>
        /// ชื่อจริง
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// นามสกุล
        /// </summary>
        public string LastName { get; set; }
    }
}
