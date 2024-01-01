using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MysqlDataFetch : MonoBehaviour
{
    readonly static string server_url = "localhost:80/veritabanlýAR";
    public string[] dersProgramlari;
    public string[] dersProgrami1036;
    public string[] dersProgrami1040;
    public string[] dersProgrami1041;
    public string[] dersProgrami1044;
    public string[] dersler;
    public string[] dersOgretmen;
    public string[] ogretmenler;

    void Awake()
    {
        StartCoroutine(getDersProgrami());
        StartCoroutine(getDersler());
        StartCoroutine(getDersOgretmen());
        StartCoroutine(getOgretmen());
    }
    //private void Update()
    //{
    //    StartCoroutine(getDersProgrami());
    //    StartCoroutine(getDersler());
    //    StartCoroutine(getDersOgretmen());
    //    StartCoroutine(getOgretmen());
    //}

    public IEnumerator getDersProgrami()
    {
        UnityWebRequest www = UnityWebRequest.Get(server_url+ "/dersprogramý.php");
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
            dersProgramlari = s.Split("<br>");
            
            foreach (string za in dersProgramlari)
            {
                za.Trim();
            }
        }
    }

    public IEnumerator getDersProgrami1036()
    {
        UnityWebRequest www = UnityWebRequest.Get(server_url + "/dersprogramý1036.php");
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
            dersProgrami1036 = s.Split("<br>");

            foreach (string za in dersProgrami1036)
            {
                za.Trim();
            }
        }
    }

    public IEnumerator getDersProgrami1040()
    {
        UnityWebRequest www = UnityWebRequest.Get(server_url + "/dersprogramý1040.php");
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
            dersProgrami1040 = s.Split("<br>");

            foreach (string za in dersProgrami1040)
            {
                za.Trim();
            }
        }
    }

    public IEnumerator getDersProgrami1041()
    {
        UnityWebRequest www = UnityWebRequest.Get(server_url + "/dersprogramý1041.php");
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
            dersProgrami1041 = s.Split("<br>");

            foreach (string za in dersProgrami1041)
            {
                za.Trim();
            }
        }
    }

    public IEnumerator getDersProgrami1044()
    {
        UnityWebRequest www = UnityWebRequest.Get(server_url + "/dersprogramý1044.php");
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
            dersProgrami1044 = s.Split("<br>");

            foreach (string za in dersProgrami1044)
            {
                za.Trim();
            }
        }
    }

    public IEnumerator getDersler()
    {
        UnityWebRequest www = UnityWebRequest.Get(server_url + "/dersler.php");
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
             
            dersler = s.Split("<br>");
            
            foreach (string za in dersler)
            {
                za.Trim();
            }
        }
    }

    public IEnumerator getDersOgretmen()
    {
        UnityWebRequest www = UnityWebRequest.Get(server_url + "/dersOgretmen.php");
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

             dersOgretmen = s.Split("<br>");
            
            
            foreach (string za in dersOgretmen)
            {
                za.Trim();
            }
        }
    }

    public IEnumerator getOgretmen()
    {
        UnityWebRequest www = UnityWebRequest.Get(server_url + "/ogretmenler.php");
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

            ogretmenler = s.Split("<br>");
            
            foreach (string za in ogretmenler)
            {
                za.Trim();
            }
        }
    }

    public string[] bin36()
    {
        StartCoroutine(getDersProgrami1036());
        return dersProgrami1036;
    }
    public string[] bin40()
    {
        StartCoroutine(getDersProgrami1040());
        return dersProgrami1040;
    }
    public string[] bin41()
    {
        StartCoroutine(getDersProgrami1041());
        return dersProgrami1041;
    }
    public string[] bin44()
    {
        StartCoroutine(getDersProgrami1044());
        return dersProgrami1044;
    }

    public string[] OgretmenlerMetot()
    {
        return ogretmenler;
    }

    public string[] DerslerMetot()
    {
        return dersler;
    }


}
