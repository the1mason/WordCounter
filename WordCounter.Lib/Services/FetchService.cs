using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace WordCounter.Lib.Services
{
    internal static class FetchService
    {
        public static string FetchFromUrl(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                //it's just word counter, so SSL certificate validation is removed
                request.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyError) => true;
                request.Method = "GET";

                WebResponse response = request.GetResponse();
                using (StreamReader sr = new(response.GetResponseStream(), Encoding.UTF8))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                throw new Exceptions.CounterException("Can't fetch from url", ex);
            }
        }

        public static string FetchFromFile(string path)
        {
            try
            {
                using (StreamReader sr = new(path))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                throw new Exceptions.CounterException("Can't fetch from file", ex);
            }
        }
    }
}
