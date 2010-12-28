using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.PlayerAccount.Models;
using TheS.Casinova.PlayerAccount.Commands;

namespace TheS.Casinova.PlayerAccount.Validator
{
    public class PlayerAccountInformation_EditPlayerAccountValidators
         : ValidatorBase<PlayerAccountInformation, EditPlayerAccountCommand>
    {
        public override void Validate(PlayerAccountInformation entity, EditPlayerAccountCommand command, ValidationErrorCollection errors)
        {
            //ตรวจสอบข้อมูลชนิดบัญชีว่ามีหรือไม่
            if (string.IsNullOrEmpty(entity.AccountType)) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่า AccountType ไม่ถูกต้อง",
                });
            }

            //ตรวจสอบข้อมูลชนิดบัตรเครดิตว่ามีหรือไม่
            if (string.IsNullOrEmpty(entity.CardType)) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่า CardType ไม่ถูกต้อง",
                });
            }

            //ตรวจสอบข้อมูลหมายเลข cvv
            if (string.IsNullOrEmpty(entity.CVV)) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "หมายเลข CVV ไม่ถูกต้อง",
                });
            }

            //ตรวจสอบข้อมูลจำนวนหมายเลขบัตรเครดิต
             if(!string.IsNullOrEmpty(entity.CVV)){
                 int countCVV = entity.CVV.Count();
                 if (countCVV != 4 ) {
                     errors.Add(new ValidationError {
                         Instance = entity,
                         ErrorMessage = "จำนวนหมายเลข CVV ไม่ถูกต้อง",
                     });
                 }
            }
             #region Credit card validation

             string CardType;            //ประเภทบัตรเครดิต
             bool accountNoValidate;    //ผลการตรวจสอบหมายเลขบัตรเครดิต

             //ตรวจสอบข้อมูลหมายเลขบัตรเครดิต
             if (string.IsNullOrEmpty(entity.AccountNo)) {
                 errors.Add(new ValidationError {
                     Instance = entity,
                     ErrorMessage = "ต้องกรอกข้อมูลหมายเลขบัตรเครดิต",
                 });
             }

             if (!string.IsNullOrEmpty(entity.AccountNo)) {

                 //ประเภทบัตรเครดิต        
                 CardType = Convert.ToString(GetCardType(entity.AccountNo));
                 //ผลการตรวจสอบหมายเลขบัตรเครดิต
                 accountNoValidate = IsCreditCardValid(entity.AccountNo);

                 //ตรวจสอบความถูกต้องของประเภทบัตรเครดิต
                 if (CardType != entity.CardType) {
                     errors.Add(new ValidationError {
                         Instance = entity,
                         ErrorMessage = "ประเภทบัตรเครดิตไม่ถูกต้อง",
                     });
                 }

                 //ตรวจสอบความถูกต้องของหมายเลขบัตรเครดิต
                 if (accountNoValidate == false) {
                     errors.Add(new ValidationError {
                         Instance = entity,
                         ErrorMessage = "หมายเลขบัตรเครดิตไม่ถูกต้อง",
                     });
                 }
             }

             #endregion Credit card validation
        }

        #region cardType validation
        public enum CardType
        {
            Invalid,
            Unknown,
            MasterCard,
            Visa,
        }

        //ตรวจสอบประเภทของบัตรเครดิต จากหมายเลขบัตร
        public CardType GetCardType(string cardNumber)
        {
            cardNumber = cardNumber.Replace(" ", "");

            // Check MasterCard
            if ((Convert.ToInt32(cardNumber.Substring(0, 2)) >= 51 &&
            Convert.ToInt32(cardNumber.Substring(0, 2)) <= 55))

                if (cardNumber.Length == 16)
                    return CardType.MasterCard;

                else
                    return CardType.Invalid;

            // Check Visa Card
            if (cardNumber.Substring(0, 1) == "4")
                if (cardNumber.Length == 16 || cardNumber.Length == 13)
                    return CardType.Visa;

                else
                    return CardType.Invalid;

            return CardType.Unknown;
        }
        #endregion cardType validation

        #region Account number validation
        public bool IsCreditCardValid(string cardNumber)
        {
            const string allowed = "0123456789";
            int i;

            StringBuilder cleanNumber = new StringBuilder();

            //หมายเลขบัตรเครดิต
            for (i = 0; i < cardNumber.Length; i++) {
                if (allowed.IndexOf(cardNumber.Substring(i, 1)) >= 0)
                    cleanNumber.Append(cardNumber.Substring(i, 1));
            }

            //ตรวจสอบจำนวนหมายเลขบัตรเครดิต มี 13 หลัก หรือ 16 หลักก็ได้
            if (cleanNumber.Length < 13 || cleanNumber.Length > 16)
                return false;

            //เพิ่มจำนวนหมายเลขบัตรเครดิต visa แบบ 13 หลัก ให้เป็น 16 หลัก
            for (i = cleanNumber.Length + 1; i <= 16; i++)
                cleanNumber.Insert(0, "0");

            //ตรวจสอบความถูกต้องของหมายเลขบัตรเครดิต 
            int multiplier, digit, sum, total = 0;
            string number = cleanNumber.ToString();

            for (i = 1; i <= 16; i++) {
                multiplier = 1 + (i % 2);
                digit = int.Parse(number.Substring(i - 1, 1));
                sum = digit * multiplier;
                if (sum > 9)
                    sum -= 9;
                total += sum;
            }
            return (total % 10 == 0);
        }
        #endregion Account number validation
    }
}
