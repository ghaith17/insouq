using System;
using System.Collections.Generic;
using System.Text;

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.IO;
using System.Net;

namespace insouq.Shared.Utility
{
    public class SmsHelper
    {
        public static bool SMSSend(string code, string mobileNumber)
        {
            try
            {
                if (mobileNumber.StartsWith("00"))
                {
                    mobileNumber = mobileNumber.Substring(2, mobileNumber.Length - 2);
                    WebClient client = new WebClient();
                    string baseurl= "http://josmsservice.com/sms/api/SendBulkMessages.cfm?numbers=" + mobileNumber + "&senderid=HUDHUD&AccName=HUDHUD&AccPass=U2@lK4@JsX2&msg="+ code + "&requesttimeout=5000000";
                    //string baseurl = "https://mshastra.com/sendurl.aspx?user=20101102&pwd=kdzd26&senderid=AD-INSOUQ&mobileno=+" + mobileNumber + "&msgtext=" + code + "&priority=High&CountryCode=ALL";
                    Stream data = client.OpenRead(baseurl);
                    StreamReader reader = new StreamReader(data);
                    string s = reader.ReadToEnd();
                    data.Close();
                    reader.Close();
                    // for UAE replace invalid success and remove !
                    if (!s.Contains("invalid")) return true;

                    return false;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}


