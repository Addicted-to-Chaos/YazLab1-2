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
            // Ýstenilen iþlemleri burada yapabilirsiniz.
        }
        else
        {
            Debug.LogError("Error: " + request.error);
        }
    }

    // Diðer HTTP istekleri için gerekli fonksiyonlarý buraya ekleyebilirsiniz.
}