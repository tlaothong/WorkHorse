using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.ChipExchange.Commands;

namespace TheS.Casinova.ChipExchange.GenerateVoucherService
{
    public class GenerateVoucherCodeExecutor
        : SynchronousCommandExecutorBase<GenerateVoucherCodeCommand>
    {
        protected override void ExecuteCommand(GenerateVoucherCodeCommand command)
        {
        #region Generate Voucher Code
            string amount;      //จำนวนเงินที่ซื้อคูปอง
            string amountCode;  //รหัสของจำนวนเงิน 
            string randomCode;  //รหัสสุ่ม
            DateTime dateTime;
            string dateTimeCode;    //รหัสเดือนและวันที่
            string timeCode;        //รหัสเวลา
            string yearsCode;       //รหัสปี
            string checksumCode;    //รหัสตรวจสอบ
            string VoucherCode = null; //รหัสคูปอง

            amount = Convert.ToString(command.Amount);
            dateTime = DateTime.Now;

            //Random : 3
            randomCode = GetRandomCode();
            VoucherCode += randomCode;

            //LookUpAmount : 2
            amountCode = GetVoucherAmountCode(amount);
            VoucherCode += amountCode;

            //GetDateTime (mmdd) : 4
            dateTimeCode = dateTime.ToString("MMdd");
            VoucherCode += dateTimeCode;

            //GetTime (min:sec => Hex) : 3
            timeCode = GetTimeCode(dateTime);
            VoucherCode += timeCode;

            //GetYear (YY) : 2
            yearsCode = Convert.ToString(dateTime.Year);
            yearsCode = yearsCode.Substring(2, 2);
            VoucherCode += yearsCode;

            //CheckSum : 2 
            checksumCode = GetChecksumCode(VoucherCode);
            
            //รหัสคูปอง
            command.VoucherCode = VoucherCode += checksumCode;

        }

        #endregion Generate Voucher Code

        #region Get Voucher Amount Code
        string GetVoucherAmountCode(string amount)
        {
            string amountCode;

            switch (amount) {
                case "100":
                    amountCode = "01";
                    break;
                case "200":
                    amountCode = "02";
                    break;
                case "300":
                    amountCode = "03";
                    break;
                case "500":
                    amountCode = "04";
                    break;
                case "1000":
                    amountCode = "05";
                    break;
                default:
                    amountCode = "00";
                    break;
            }
            return amountCode;
        }
        #endregion Get Voucher Amount Code

        #region Random Code
        static string GetRandomCode()
        {
            string randomCode = null;
            int number;
            Random ran = new Random(); //ประการตัวแปรเก็บค่าการสุ่มตัวเลข

            for (int i = 0; i < 3; i++) {
                number = ran.Next(0, 9); //กำหนดให้สุ่มตั่งแต่ 0-9
                number.ToString();

                randomCode += number;
            }

            return randomCode;
        }
        #endregion Random Code

        #region Time Code
        static string GetTimeCode(DateTime dateTime)
        {
            //แปลงเวลาเป็นเลขฐานสิบหก

            int minute; //เวลาในหน่วยนาที
            int second; //เวลาในหน่วยวินาที
            int minToSec; //เวลานาทีเป็นหน่วยวินาที
            int multiplier = 60;
            int sumSec; //ผลรวมเวลาในหน่วยวินาที
            string timeCode;

            minute = dateTime.Minute;
            second = dateTime.Second;
            minToSec = minute * multiplier;
            sumSec = minToSec + second;
            timeCode = string.Format("0x{0:X2}", sumSec);
            timeCode = timeCode.Substring(2);

            if (timeCode.Count() == 2) {
                timeCode = timeCode.Insert(0, "0");
            }
            return timeCode;
        }
        #endregion Time Code,.

        #region Checksum Code
        static string GetChecksumCode(string preVoucherCode)
        {
            string checksum = null;
            int mod16;
            int mod10;
            string convert;
            int[] voucherCode = new int[14];
            int multiplier, digit, sum, total = 0;

            //แปลง string เป็น int
            for (int i = 0; i <= 13; i++) {

                if (i == 9 || i == 10 || i == 11) {

                    //แปลงฐานสิบหกเป็นฐานสิบ
                    convert = preVoucherCode.Substring(i, 1);
                    switch (convert) {
                        case "A":
                            voucherCode[i] = 10;
                            break;
                        case "B":
                            voucherCode[i] = 11;
                            break;
                        case "C":
                            voucherCode[i] = 12;
                            break;
                        case "D":
                            voucherCode[i] = 13;
                            break;
                        case "E":
                            voucherCode[i] = 14;
                            break;
                        case "F":
                            voucherCode[i] = 15;
                            break;
                        default:
                            voucherCode[i] = Int32.Parse(convert);
                            break;
                    }

                }
                else {
                    voucherCode[i] = int.Parse(preVoucherCode.Substring(i, 1));
                }
            }

            //หาค่า checksum
            for (int i = 1; i <= 14; i++) {
                multiplier = 1 + (i % 2);
                digit = voucherCode[i - 1];
                sum = digit * multiplier;

                total += sum;
            }

            mod16 = total % 16; //checksum หลักที่ 15
            mod10 = total % 10; //checksum หลักที่ 16

            //แปลงฐานสิบเป็นฐานสิบหก
            switch (mod16) {
                case 10:
                    checksum = "A";
                    break;
                case 11:
                    checksum = "B";
                    break;
                case 12:
                    checksum = "C";
                    break;
                case 13:
                    checksum = "D";
                    break;
                case 14:
                    checksum = "E";
                    break;
                case 15:
                    checksum = "F";
                    break;
                default:
                    checksum = Convert.ToString(mod16);
                    break;
            }

            checksum += Convert.ToString(mod10);

            return checksum;
        }
        #endregion Checksum Code
    
    }
}
