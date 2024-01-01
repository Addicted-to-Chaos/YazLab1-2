using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MysqlDataFetch : MonoBehaviour
{
    readonly static string server_url = "localhost:80/veritabanl�AR";
    public string[] dersProgramlari;
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
        UnityWebRequest www = UnityWebRequest.Get(server_url+ "/dersprogram�.php");
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
            //�c�nc� derslik_id
            //d�rd�nc� gun_id
            //besinci saat_id
            //altinci ders_sinif    
            dersProgramlari = s.Split("<br>");
            
            foreach (string za in dersProgramlari)
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
            //�c�nc� ders_sinif
             
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
            //�c�nc� ogretmen_id

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

    public string[] OgretmenlerMetot()
    {
        return ogretmenler;
    }

    public string[] DerslerMetot()
    {
        return dersler;
    }

}
