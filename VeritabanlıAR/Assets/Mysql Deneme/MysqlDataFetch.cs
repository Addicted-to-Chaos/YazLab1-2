using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MysqlDataFetch : MonoBehaviour
{
    readonly static string server_url = "localhost:80/veritabanlýAR";

    void Start()
    {
        getDersProgrami("/dersprogramý.php");
    }

    IEnumerator getData(string url)
    {
        UnityWebRequest www = UnityWebRequest.Get(server_url+url);
        yield return www.SendWebRequest();
        if (www.isHttpError || www.isNetworkError)
        {
            Debug.Log("Baglanti Hatasi");
        }
        else
        {
            string s = www.downloadHandler.text;
            //ilk ders_programi_id
            //ikinci ders_id
            //ücüncü derslik_id
            //dördüncü gun_id
            //besinci saat_id
            //altinci ders_sinif    
            string[] cogul = s.Split("<br>");
            int size= cogul.Length;
            string[] dersProgramlari= new string[size];
            int i = 0;

            foreach (string he in cogul)
            {
                if (i < dersProgramlari.Length)
                {
                    dersProgramlari[i] +=he;
                    i++;
                }
                else
                {
                    break;
                }

            }
            foreach (string za in dersProgramlari)
            {
                Debug.Log(za);
            }
        }
    }
    public void getDersProgrami(string url)
    {
        StartCoroutine(getData(url));
    }
}
