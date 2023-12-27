using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using System;

public class Neo4jRequester : MonoBehaviour
{
    public string url = "https://localhost:7051/DB/executeOneNode";
    public string query = "Match(n) return n;";

    string responseString;

    void Start()
    {
        ExecuteRequest();
    }

    async void ExecuteRequest()
    {
        try
        {
            // Create HTTP client and request
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                // Set headers
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                request.Content = new StringContent(query, Encoding.UTF8, "application/json");

                // Send request and await response
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    // Assign response content to string
                    responseString = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    Debug.LogError("Request failed with status code: " + response.StatusCode);
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Error during request: " + ex.Message);
        }
    }
}
