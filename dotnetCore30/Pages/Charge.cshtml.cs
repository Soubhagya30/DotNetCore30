﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razorpay.Api;

namespace dotnetCore30
{
    public class ChargeModel : PageModel
    {
        //protected void Page_Load(object sender, EventArgs e)
        public void OnGet()
        {

            string paymentId = Request.Form["razorpay_payment_id"];

                Dictionary<string, object> input = new Dictionary<string, object>();
                input.Add("amount", 100); // this amount should be same as transaction amount

                string key = "rzp_test_2pjQoIV7c1RY6C";
                string secret = "nWwe91xQO3NIDzJUp1mUmr9O";


                RazorpayClient client = new RazorpayClient(key, secret);

                Dictionary<string, string> attributes = new Dictionary<string, string>();

                attributes.Add("razorpay_payment_id", paymentId);
                attributes.Add("razorpay_order_id", Request.Form["razorpay_order_id"]);
                attributes.Add("razorpay_signature", Request.Form["razorpay_signature"]);

                Utils.verifyPaymentSignature(attributes);

                //Refund refund = new Razorpay.Api.Payment((string)paymentId).Refund();

                //Console.WriteLine(refund["id"]);
            }
        }
    }
    
