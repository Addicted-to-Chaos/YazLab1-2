using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class aa : MonoBehaviour
{
    string baseUrl = "https://bb533638.databases.neo4j.io"; // Neo4j REST API URL'si

    private void Start()
    {
        StartCoroutine(GetNode());
    }

    IEnumerator GetNode()
    {
        string getNodeUrl = baseUrl + "/node/";

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
