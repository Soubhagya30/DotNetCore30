using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razorpay.Api;

namespace dotnetCore30
{
    public class PaymentModel : PageModel
    {
        public string orderId;

        //protected void Page_Load(object sender, EventArgs e)
        public void OnGet()
        {
            Dictionary<string, object> input = new Dictionary<string, object>();
            input.Add("amount", 100); // this amount should be same as transaction amount
            input.Add("currency", "INR");//
            input.Add("receipt", "12121");
            input.Add("payment_capture", 1);

            string key = "rzp_test_2pjQoIV7c1RY6C";
            string secret = "nWwe91xQO3NIDzJUp1mUmr9O";

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;


            RazorpayClient client = new RazorpayClient(key, secret);

            Razorpay.Api.Order order = client.Order.Create(input);
            orderId = order["id"].ToString();


        }
    }
}
