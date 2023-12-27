using UnityEngine;
using System;
using System.Net;
using System.IO;
using System.Text;

public class apiManager : MonoBehaviour
{
    public string SendCurlRequest()
    {
        string url = "https://localhost:7051/DB/executeOneNode";
        string data = "{\"query\": \"Match(n) return n\"}";
        string result = "";

        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "text/plain";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(data);
                streamWriter.Flush();
                streamWriter.Close();
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
        }
        catch (WebException e)
        {
            // Handle exceptions here
            if (e.Response != null)
            {
                using (var errorResponse = (HttpWebResponse)e.Response)
                {
                    using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                    {
                        string error = reader.ReadToEnd();
                        Debug.LogError(error);
                    }
                }
            }
        }

        return result;
    }

    // Örnek kullaným
    void Start()
    {
        string response = SendCurlRequest();
        Debug.Log("Curl isteði cevabý: " + response);
    }
}
