﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Diagnostics;

namespace DoubleCounter_Bypass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"[{Utils.Time()}] Insert Verify Link:");
            string code = Console.ReadLine();
            Bypass(code);
            Console.WriteLine($"[{Utils.Time()}] Finished. Press enter to leave...");
            Console.ReadLine();
            Process.GetCurrentProcess().Kill();
        }


        public static void Bypass(string code)
        {
            #region webheader
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{code}");
            httpWebRequest.Method = "GET";
            httpWebRequest.Headers.Add("Name", "verify.dcounter.space");
            httpWebRequest.KeepAlive = true;
            httpWebRequest.Headers.Add("sec-ch-ua", "Not A;Brand\";v =\"99\",\"Chromium\";v =\"98\",\"Google Chrome\";v =\"98\"");
            httpWebRequest.Headers.Add("Name", "application/json");
            httpWebRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
            httpWebRequest.Headers.Add("sec-ch-ua-mobile", "?0");
            httpWebRequest.ContentType = "application/json;charset=utf-8";
            httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/99.0.4844.51 Safari/537.36";
            httpWebRequest.Headers.Add("sec-ch-ua-platform", "\"Windows\"");
            httpWebRequest.Headers.Add("Cookie", "");
            httpWebRequest.Headers.Add("Origin", "verify.dcounter.space");
            httpWebRequest.Headers.Add("Sec-Fetch-Site", "none");
            httpWebRequest.Headers.Add("Sec-Fetch-Mode", "navigate");
            httpWebRequest.Headers.Add("Sec-Fetch-Dest", "document");
            httpWebRequest.Headers.Add("Accept-Language", "it-IT,it;q=0.9,en;q=0.8,en-US;q=0.7");
            httpWebRequest.Headers.Add("AcceptEncoding", "gzip, deflate");
            httpWebRequest.Headers.Add("Upgrade-Insecure-Requests", "1");
            #endregion
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            Console.WriteLine($"[{Utils.Time()}] Request Status Code: {httpResponse.StatusCode}");
            string result;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
                
            }
        }
    }
}
