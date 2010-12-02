﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.ChipExchange.Commands;
using TheS.Casinova.ChipExchange.BackServices;
using TheS.Casinova.ChipExchange.DAL;
using TheS.Casinova.PlayerAccount.Models;
using TheS.Casinova.ChipExchange.Command;
using TheS.Casinova.ChipExchange.Models;

namespace TheS.Casinova.ChipExchange.WebExecutors
{
    /// <summary>
    /// แลกชิพเป็นด้วยเงิน
    /// </summary>
    public class MoneyToChipsExecutor
    : SynchronousCommandExecutorBase<MoneyToChipsCommand>
    {
        private IMoneyToChips _iMoneyToChips;
        private IGetPlayerAccountInfo _iGetPlayerAccount; 

        public MoneyToChipsExecutor(IChipsExchangeModuleBackService dac, IChipsExchangeModuleDataQuery dqr)
        {
            _iMoneyToChips = dac;
            _iGetPlayerAccount = dqr;
        }

        protected override void ExecuteCommand(MoneyToChipsCommand command)
        {
            string CardType;            //ประเภทบัตรเครดิต
            bool accountNoValidate ;    //ผลการตรวจสอบหมายเลขบัตรเครดิต

            #region Credit card validation

            //ดึงข้อมูลบัญชีบัตรเครดิต
            GetPlayerAccountInfoCommand cmd_PlayerAccount = new GetPlayerAccountInfoCommand { 
                UserName = command.UserName,
                AccountType = command.AccountType
            };

            //ข้อมูลบัตรเครดิต
            cmd_PlayerAccount.PlayerAccountInfo = _iGetPlayerAccount.Get(cmd_PlayerAccount);

            //ประเภทบัตรเครดิต
            CardType = Convert.ToString(GetCardType(cmd_PlayerAccount.PlayerAccountInfo.AccountNo));

            //ตรวจสอบความถูกต้องของประเภทบัตรเครดิต
            if (CardType != cmd_PlayerAccount.PlayerAccountInfo.CardType) {
                Console.WriteLine("ประเภทบัตรเครดิตไม่ถูกต้อง");
            }
            else {
                //ตรวจสอบความถูกต้องของหมายเลขบัตรเครดิต
                accountNoValidate = IsCreditCardValid(cmd_PlayerAccount.PlayerAccountInfo.AccountNo);

                if (accountNoValidate == false) {
                    Console.WriteLine("หมายเลขบัตรเครดิตไม่ถูกต้อง");
                }
                else {

                    //TODO: Generate trackingID
                    _iMoneyToChips.MoneyToChips(command);
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
