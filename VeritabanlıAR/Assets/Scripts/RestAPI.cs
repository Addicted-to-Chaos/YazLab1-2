using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class RestAPI : MonoBehaviour
{
    private const string baseUrl = "https://localhost:7051/DB/";


    private void Start()
    {
        ExecuteOneNode("Match(n) return n;");
    }
    public void ExecuteOneNode(string query)
    {
        StartCoroutine(IExecuteOneNode(query));
    }

    public IEnumerator IExecuteOneNode(string query)
    {
        string url = baseUrl + "executeOneNode";
        string jsonData = JsonUtility.ToJson(new { query });

        UnityWebRequest request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("accept", "text/plain");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Response: " + request.downloadHandler.text);
            // Baþarýlý istek durumunda cevabý iþleyebilirsiniz.
        }
        else
        {
            Debug.LogError("Error: " + request.error);
            // Hata durumunda ne yapýlacaðýný burada iþleyebilirsiniz.
        }
    }

    public void Execute(string query)
    {
        StartCoroutine(IExecute(query));
    }

    public IEnumerator IExecute(string query)
    {
        string url = baseUrl + "execute";
        string jsonData = JsonUtility.ToJson(new { query });

        UnityWebRequest request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("accept", "text/plain");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Response: " + request.downloadHandler.text);
            // Baþarýlý istek durumunda cevabý iþleyebilirsiniz.
        }
        else
        {
            Debug.LogError("Error: " + request.error);
            // Hata durumunda ne yapýlacaðýný burada iþleyebilirsiniz.
        }
    }

    public void ExecuteReturnless(string query)
    {
        StartCoroutine(IExecuteReturnless(query));
    }

    public IEnumerator IExecuteReturnless(string query)
    {
        string url = baseUrl + "executeReturnless";
        string jsonData = JsonUtility.ToJson(new { query });

        UnityWebRequest request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("accept", "text/plain");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Response: " + request.downloadHandler.text);
            // Baþarýlý istek durumunda cevabý iþleyebilirsiniz.
        }
        else
        {
            Debug.LogError("Error: " + request.error);
            // Hata durumunda ne yapýlacaðýný burada iþleyebilirsiniz.
        }
    }
}
