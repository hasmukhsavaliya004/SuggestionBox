using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace SuggestionBox
{
    public class SuggestionService
    {
        public int Add(Suggestion ObjSuggestion)
        {
            int returnVal;
            try
            {
                string address = "http://localhost:12563/api/API";
                HttpWebRequest httpWebRequest = WebRequest.Create(address) as HttpWebRequest;
                httpWebRequest.ContentType = "text/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(ObjSuggestion.GetType());
                    StreamWriter writer = new StreamWriter(httpWebRequest.GetRequestStream());
                    JavaScriptSerializer jss = new JavaScriptSerializer();

                    string json = jss.Serialize(ObjSuggestion);
                    writer.Write(json);
                    writer.Close();
                }

                try
                {
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        returnVal = Convert.ToInt32(streamReader.ReadToEnd());
                        streamReader.Close();
                        httpResponse.Close();
                    }
                }
                catch (WebException ex)
                {
                    returnVal = 0;
                }
                finally
                {
                    httpWebRequest.Abort();
                }
            }
            catch (Exception ex)
            {
                returnVal = 0;
            }
            return returnVal;
        }

        public List<Suggestion> GetAll()
        {
            List<Suggestion> returnVal ;
            try
            {
                string address = "http://localhost:12563/api/API";
                HttpWebRequest httpWebRequest = WebRequest.Create(address) as HttpWebRequest;
                httpWebRequest.ContentType = "text/json";
                httpWebRequest.Method = "GET";
                
                try
                {
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        JavaScriptSerializer jss = new JavaScriptSerializer();
                        returnVal = jss.Deserialize<List<Suggestion>>(streamReader.ReadToEnd());
                        streamReader.Close();
                        httpResponse.Close();
                    }
                }
                catch (WebException ex)
                {
                    returnVal = null;
                }
                finally
                {
                    httpWebRequest.Abort();
                }
            }
            catch (Exception ex)
            {
                returnVal = null;
            }
            return returnVal;
        }

        public int DeleteByID(int id)
        {
            int returnVal;
            try
            {
                string address = "http://localhost:12563/api/API/"+id;
                HttpWebRequest httpWebRequest = WebRequest.Create(address) as HttpWebRequest;
                httpWebRequest.ContentType = "text/json";
                httpWebRequest.Method = "DELETE";

                try
                {
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        returnVal = Convert.ToInt32(streamReader.ReadToEnd());
                        streamReader.Close();
                        httpResponse.Close();
                    }
                }
                catch (WebException ex)
                {
                    returnVal = 0;
                }
                finally
                {
                    httpWebRequest.Abort();
                }
            }
            catch (Exception ex)
            {
                returnVal = 0;
            }
            return returnVal;
        }
    }
}