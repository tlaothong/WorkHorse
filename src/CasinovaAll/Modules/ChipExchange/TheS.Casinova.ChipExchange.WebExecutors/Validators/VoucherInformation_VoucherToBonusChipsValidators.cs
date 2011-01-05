using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ChipExchange.Commands;
using TheS.Casinova.ChipExchange.Models;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.ChipExchange.Validators
{
    public class VoucherInformation_VoucherToBonusChipsValidators
         : ValidatorBase<VoucherInformation, VoucherToBonusChipsCommand>
    {
        public override void Validate(VoucherInformation entity, VoucherToBonusChipsCommand command, ValidationErrorCollection errors)
        {
            string checksum;
            string checkVoucherCode;

            //ตรวจสอบการป้อนข้อมูลรหัสคูปอง
            if (entity.VoucherCode == null) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่า VoucherCode ไม่ถูกต้อง",
                });
            }

            else {
                //ตรวจสอบจำนวนรหัสคูปอง
                int count = entity.VoucherCode.Count();
                if (count != 16) {
                    errors.Add(new ValidationError {
                        Instance = entity,
                        ErrorMessage = "จำนวน VoucherCode ไม่ถูกต้อง",
                    });
                }

                //ตรวจสอบความถูกต้องรหัสคูปอง
                else {
                    checksum = GetChecksumCode(entity.VoucherCode);
                    checkVoucherCode = entity.VoucherCode.Substring(14, 2);

                    if (checksum != checkVoucherCode) {
                        errors.Add(new ValidationError {
                            Instance = entity,
                            ErrorMessage = "VoucherCode ไม่ถูกต้อง",
                        });
                    }
                }
            }
        }

        #region Checksum Code
        string GetChecksumCode(string preVoucherCode)
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
