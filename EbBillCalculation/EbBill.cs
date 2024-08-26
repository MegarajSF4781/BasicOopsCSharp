using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbBillCalculation
{
    public class EbBill
    {
        private static int s_meterId = 1000;

        public string MeterId { get; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }
        public int Units = 0;


        public EbBill(string userName, string emailId, string phone)
        {
            s_meterId++;
            MeterId = "EB" + s_meterId;
            UserName = userName;
            EmailId = emailId;
            PhoneNumber = phone;
        }

        public EbBill()
        {

        }

        public double CalculateAmount()
        {
            double amount =0 ;
            if (Units > 500)
            {
                amount += (Units - 500) * 10;
                Units = 500;
            }
            if (Units > 400)
            {
                amount += (Units - 400) * 9;
                Units = 400;
            }

            if (Units > 200)
            {
                amount += (Units - 200) * 5;
                Units = 200;
            }
            if (Units > 100)
            {
                amount += (Units - 100) * 2.5;
            }

            return amount;

        }


    }
}