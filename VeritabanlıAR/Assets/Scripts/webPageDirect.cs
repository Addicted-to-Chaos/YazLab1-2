using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using System;

public class Neo4jRequester : MonoBehaviour
{
    string url= "file:///C:/Users/kaan4/OneDrive/Belgeler/GitHub/KutuOyunu-Satis-Sitesi/aksesuar.html";

    public void OpenWebPage()
    {
        Application.OpenURL(url);
    }
}
