using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayService.Model;


namespace PayService.DAO
{
    public class ClientAccountDAO
    {
        private PayDataEntities entities = new PayDataEntities();

        public ClientAccount GetByCardNumber(string cardNumber) => entities.ClientAccount.FirstOrDefault(n => n.CardNumber == cardNumber);

        public bool WriteOff(string cardNumber, decimal writeOffSum)
        {
            ClientAccount account = GetByCardNumber(cardNumber);
            if (account.Balance - writeOffSum >= 0)
            {
                account.Balance -= writeOffSum;
                return entities.SaveChanges() == 1 ? true : false;
            }
            else
                return false;
        }
    }
}