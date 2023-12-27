using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class apiManager : MonoBehaviour
{
    string baseUrl = "http://your-neo4j-api-url"; // Neo4j REST API URL'si

    IEnumerator GetNode(string nodeId)
    {
        string getNodeUrl = baseUrl + "/node/" + nodeId;

        UnityWebRequest request = UnityWebRequest.Get(getNodeUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string response = request.downloadHandler.text;
            Debug.Log("Node Info: " + response);
            // �stenilen i�lemleri burada yapabilirsiniz.
        }
        else
        {
            Debug.LogError("Error: " + request.error);
        }
    }

    // Di�er HTTP istekleri i�in gerekli fonksiyonlar� buraya ekleyebilirsiniz.
}