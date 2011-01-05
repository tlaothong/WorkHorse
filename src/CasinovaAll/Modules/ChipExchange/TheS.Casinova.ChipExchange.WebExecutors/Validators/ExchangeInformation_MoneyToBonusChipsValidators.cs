using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.ChipExchange.Models;
using TheS.Casinova.ChipExchange.Commands;
using TheS.Casinova.ChipExchange.Command;
using TheS.Casinova.ChipExchange.DAL;
using TheS.Casinova.PlayerAccount.Models;

namespace TheS.Casinova.ChipExchange.Validators
{
    public class ExchangeInformation_MoneyToBonusChipsValidators
         : ValidatorBase<ExchangeInformation, MoneyToBonusChipsCommand>
    {
        private IGetPlayerAccountInfo _iGetPlayerAccount;
        private IGetMultiLevelNetworkInfo _iGetBonusPoint;

        public ExchangeInformation_MoneyToBonusChipsValidators(IChipsExchangeModuleDataQuery dqr)
        {
            _iGetPlayerAccount = dqr;
            _iGetBonusPoint = dqr;
        }

        public override void Validate(ExchangeInformation entity, MoneyToBonusChipsCommand command, ValidationErrorCollection errors)
        {
            string cardType;            //ประเภทบัตรเครดิต
            bool accountNoValidate;     //ผลการตรวจสอบหมายเลขบัตรเครดิต

            //ตรวจสอบจำนวนเงิน
            if (entity.Amount < 1) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่า Amount ไม่ถูกต้อง",
                });
            }

            //ตรวจสอบข้อมูลชนิดบัญชี
            if (string.IsNullOrEmpty(entity.AccountType)) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่า AccountType ไม่ถูกต้อง",
                });
            }

            #region Credit card validation
            //ดึงข้อมูลบัญชีบัตรเครดิต
            GetPlayerAccountInfoCommand cmd_PlayerAccount = new GetPlayerAccountInfoCommand {
                PlayerAccount = new PlayerAccountInformation {
                    UserName = entity.UserName,
                    AccountType = entity.AccountType
                }
            };

            cmd_PlayerAccount.PlayerAccountInfo = _iGetPlayerAccount.Get(cmd_PlayerAccount);

            if (cmd_PlayerAccount.PlayerAccountInfo != null) {
                //ตรวจสอบความถูกต้องของประเภทบัตรเครดิต
                cardType = Convert.ToString(GetCardType(cmd_PlayerAccount.PlayerAccountInfo.AccountNo));

                if (cardType != cmd_PlayerAccount.PlayerAccountInfo.CardType) {
                    errors.Add(new ValidationError {
                        Instance = entity,
                        ErrorMessage = "ค่า CardType ไม่ถูกต้อง",
                    });
                }
                else {
                    //ตรวจสอบความถูกต้องของหมายเลขบัตรเครดิต
                    accountNoValidate = IsCreditCardValid(cmd_PlayerAccount.PlayerAccountInfo.AccountNo);

                    if (accountNoValidate == false) {
                        errors.Add(new ValidationError {
                            Instance = entity,
                            ErrorMessage = "ค่า AccountNo ไม่ถูกต้อง",
                        });
                    }
                }
            }
            #endregion Credit card validation

            #region Check bonus point

            //ดึงข้อมูลจำนวนโบนัส
            GetMultiLevelNetworkInfoCommand cmd_BonusPoint = new GetMultiLevelNetworkInfoCommand {
                UserName = entity.UserName
            };

            //จำนวนโบนัส
            cmd_BonusPoint.MultiLevelNetwork = _iGetBonusPoint.Get(cmd_BonusPoint);

            if (cmd_BonusPoint.MultiLevelNetwork != null) {   
                //ตรวจสอบจำนวนโบนัสว่่าเพียงพอที่จะแลกชิพตายหรือไม่
                if (entity.Amount > cmd_BonusPoint.MultiLevelNetwork.Bonus) {
                    errors.Add(new ValidationError {
                        Instance = entity,
                        ErrorMessage = "มีจำนวนโบนัสไม่เพียงพอ",
                    });
                }
            }

            #endregion Check bonus point
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

            //ตรวจสอบจำนวนหมายเลขบัตรเครดิต
            if (cleanNumber.Length < 13 || cleanNumber.Length > 16)
                return false;

            //เพิ่มจำนวนหมายเลขบัตรเครดิต visa แบบ 13 หลัก
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
