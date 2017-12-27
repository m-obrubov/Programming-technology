using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using PayService.Model;
using PayService.DAO;

namespace PayService
{
    /// <summary>
    /// Сводное описание для PayService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class PayService : System.Web.Services.WebService
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
            ClientAccount currentAccount = new ClientAccount(cardNumber, expYear, expMonth, cardHolderName, cvcCode);
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
