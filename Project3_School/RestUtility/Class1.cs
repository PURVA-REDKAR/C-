using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestUtility
{
    public class REST
    {
        private string baseUri;
        public REST(string bU)
        {
            this.baseUri = bU;
        }
        #region GetRest
        public string getRestJSON(string uri)
        {
            string baseuri = "http://ist.rit.edu/api";
            //connect to the api
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(baseuri + uri);
            try
            {
                WebResponse resp = req.GetResponse();
                using (Stream respStream = resp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream, Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                //stream - charachter by charachter h e l l o
                //However String is hello
                WebResponse err = ex.Response;

                using (Stream respStream = err.GetResponseStream())
                {
                    StreamReader r = new StreamReader(respStream, Encoding.UTF8);
                    string errorText = r.ReadToEnd();
                    //log it 
                }
                throw;
            }

            return "Hi";
        }
        #endregion

        public string getRestXML(string uri)
        {
            return "cool xml stuff";
        }

    }
}
