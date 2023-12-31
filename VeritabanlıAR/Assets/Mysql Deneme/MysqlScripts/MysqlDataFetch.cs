using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MysqlDataFetch : MonoBehaviour
{
    readonly static string server_url = "localhost:80/veritabanlýAR";
    public string[] dersProgramlari;
    public string[] dersler;
    public string[] dersOgretmen;
    public string[] ogretmenler;

    void Start()
    {
        StartCoroutine(getDersProgrami());
        StartCoroutine(getDersler());
        StartCoroutine(getDersOgretmen());
        StartCoroutine(getOgretmen());
    }

    public IEnumerator getDersProgrami()
    {
        UnityWebRequest www = UnityWebRequest.Get(server_url+ "goster/dersprogramý.php");
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
            dersProgramlari= new string[size];
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
                za.Trim();
            }
        }
    }

    public IEnumerator getDersler()
    {
        UnityWebRequest www = UnityWebRequest.Get(server_url + "goster/dersler.php");
        yield return www.SendWebRequest();
        if (www.isHttpError || www.isNetworkError)
        {
            Debug.Log("Baglanti Hatasi");
        }
        else
        {
            string s = www.downloadHandler.text;
            //ilk ders_id
            //ikinci ders_adi
            //ücüncü ders_sinif
             
            string[] cogul = s.Split("<br>");
            int size = cogul.Length;
            dersler = new string[size];
            int i = 0;

            foreach (string he in cogul)
            {
                if (i < dersler.Length)
                {
                    dersler[i] += he;
                    i++;
                }
                else
                {
                    break;
                }

            }
            foreach (string za in dersler)
            {
                za.Trim();
            }
        }
    }

    public IEnumerator getDersOgretmen()
    {
        UnityWebRequest www = UnityWebRequest.Get(server_url + "goster/dersOgretmen.php");
        yield return www.SendWebRequest();
        if (www.isHttpError || www.isNetworkError)
        {
            Debug.Log("Baglanti Hatasi");
        }
        else
        {
            string s = www.downloadHandler.text;
            //ilk ders_ogretmen_id
            //ikinci ders_id
            //ücüncü ogretmen_id

            string[] cogul = s.Split("<br>");
            int size = cogul.Length;
            dersOgretmen = new string[size];
            int i = 0;

            foreach (string he in cogul)
            {
                if (i < dersOgretmen.Length)
                {
                    dersOgretmen[i] += he;
                    i++;
                }
                else
                {
                    break;
                }

            }
            foreach (string za in dersOgretmen)
            {
                za.Trim();
            }
        }
    }

    public IEnumerator getOgretmen()
    {
        UnityWebRequest www = UnityWebRequest.Get(server_url + "goster/dersOgretmen.php");
        yield return www.SendWebRequest();
        if (www.isHttpError || www.isNetworkError)
        {
            Debug.Log("Baglanti Hatasi");
        }
        else
        {
            string s = www.downloadHandler.text;
            //ilk ogretmen_id
            //ikinci ad

            string[] cogul = s.Split("<br>");
            int size = cogul.Length;
            ogretmenler = new string[size];
            int i = 0;

            foreach (string he in cogul)
            {
                if (i < ogretmenler.Length)
                {
                    ogretmenler[i] += he;
                    i++;
                }
                else
                {
                    break;
                }

            }
            foreach (string za in ogretmenler)
            {
                za.Trim();
            }
        }
    }

}
