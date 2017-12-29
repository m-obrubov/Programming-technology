using PayService.DAO;
using PayService.Model;
using System;
using System.Web.Services;

namespace PayService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class PayService : WebService
    {

        [WebMethod]
        public bool PayOnline(string cardNumber, int expYear, int expMonth, string cardHolderName, string cvcCode, decimal purchaseSum)
        {
            ClientAccount account = CheckInfo(cardNumber, expYear, expMonth, cardHolderName, cvcCode);
            if (account == null) return false;
            ClientAccountDAO clientAccountDAO = new ClientAccountDAO();
            return clientAccountDAO.WriteOff(account.CardNumber, purchaseSum);
        }

        private ClientAccount CheckInfo(string cardNumber, int expYear, int expMonth, string cardHolderName, string cvcCode)
        {
            ClientAccount currentAccount = new ClientAccount(cardNumber, expYear, expMonth, cardHolderName.ToUpper(), cvcCode);
            DateTime expDate = new DateTime(expYear, expMonth, 1);
            if (expDate < DateTime.Now || cardNumber.Length != 16)
                return null;
            ClientAccountDAO clientAccountDAO = new ClientAccountDAO();
            ClientAccount expectedAccount = clientAccountDAO.GetByCardNumber(cardNumber);
            if (currentAccount.Equals(expectedAccount))
                return expectedAccount;
            else
                return null;
        }
    }
}
