//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PayService.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClientAccount
    {
        public ClientAccount()
        {
        }

        public ClientAccount(string cardNumber, int expYear, int expMonth, string cardHolder, string cvcCode)
        {
            CardNumber = cardNumber;
            CardHolder = cardHolder;
            CVC = cvcCode;
            ExpYear = expYear;
            ExpMonth = expMonth;
        }

        public string CardNumber { get; set; }
        public string CardHolder { get; set; }
        public string CVC { get; set; }
        public decimal Balance { get; set; }
        public int ExpYear { get; set; }
        public int ExpMonth { get; set; }

        public override bool Equals(object obj)
        {
            var account = obj as ClientAccount;
            return account != null &&
                   CardNumber == account.CardNumber &&
                   CardHolder == account.CardHolder &&
                   CVC == account.CVC &&
                   ExpYear == account.ExpYear &&
                   ExpMonth == account.ExpMonth;
        }
    }
}
