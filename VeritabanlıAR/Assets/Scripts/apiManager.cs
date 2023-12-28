using UnityEngine;
using System.Collections;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using UnityEngine.Networking;
using Unity.VisualScripting;

public class apiManager : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(nope());
    }
    IEnumerator nope()
    {
        using (UnityWebRequest www = UnityWebRequest.Post("https://localhost:7051/DB/executeOneNode", "{\"query\":\"Match(n) return n;\"}"))
        {
            www.SetRequestHeader("accept", "text/plain");
            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
}


