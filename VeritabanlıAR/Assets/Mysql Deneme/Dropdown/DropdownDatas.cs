using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropdownDatas : MonoBehaviour
{
    [Header("Ogretmenler")]
    [SerializeField] TMP_Dropdown ogretmenlerDropDown;
    List<string> ogretmenlerID=new List<string>();
    List<string> ogretmenlerAd=new List<string>();
    string[] ogretmenler;

    /* Bunlar �nemli*/
    public string seciliOgretmenID; 
    public string seciliOgretmenAD;

    [Header("Dersler")]
    [SerializeField] TMP_Dropdown derslerDropDown;
    string[] dersler;
    List<string> dersID = new List<string>();
    List<string> dersADI = new List<string>();
    List<string> dersSinifi = new List<string>();


    /* Bunlar �nemli*/
    public string seciliDersID;
    public string seciliDersADI;
    public string seciliDersSinifi;

    MysqlDataFetch dataFetch;

    #region Ogretmenler
    void LoadOgretmenler()
    {
        for (int i = 0; i < ogretmenler.Length - 1; i++)
        {
            string[] parcalar = ogretmenler[i].Trim().Split(",");
            ogretmenlerID.Add(parcalar[0]);
            ogretmenlerAd.Add(parcalar[1]); 

            var option=new TMP_Dropdown.OptionData(parcalar[1]);
            ogretmenlerDropDown.options.Add(option);
        }
        
    }
    public void HandleOgretmenlerData()
    {
        string valString = ogretmenlerDropDown.value.ToString();
        int size = ogretmenlerAd.Count;
        for(int i = 0; i < size; i++)
        {
            if (valString.Equals(ogretmenlerID[i]))
            {
                seciliOgretmenID = ogretmenlerID[i];
                seciliOgretmenAD = ogretmenlerAd[i];
            }
        }
    }
    #endregion Ogretmenler

    #region Dersler
    void LoadDersler()
    {
        for(int i=0; i<dersler.Length-1; i++)
        {
            string[] parcalar = dersler[i].Trim().Split(",");
            dersID.Add(parcalar[0]);
            dersADI.Add(parcalar[1]);
            dersSinifi.Add(parcalar[2]);

            var option = new TMP_Dropdown.OptionData(parcalar[1] + " / " + parcalar[2]+". s�n�f");
            derslerDropDown.options.Add(option);
        }

    }

    public void HandleDerslerData()
    {
        string valString = derslerDropDown.value.ToString();
        int size = dersADI.Count;
        for (int i = 0; i < size; i++)
        {
            if (valString.Equals(dersID[i]))
            {
                seciliDersID = dersID[i];
                seciliDersADI = dersADI[i];
                seciliDersSinifi = dersSinifi[i];
            }
        }
    }
    #endregion Dersler
    private void Start()
    {
        dataFetch=FindObjectOfType<MysqlDataFetch>(); 
        ogretmenler=dataFetch.OgretmenlerMetot();
        dersler=dataFetch.DerslerMetot();
        LoadOgretmenler();
        LoadDersler();
    }

    
    private void Update()
    {
    }

    public string SeciliOgretmen()
    {
        return seciliOgretmenID;
    }
    public string SeciliDers()
    {
        return seciliDersID;
    }
    public string DersAdi()
    {
        return seciliDersADI;
    }
    public string OgretmenADi()
    {
        return seciliOgretmenAD;
    }
   public List<string> LDersADI()
    {
        return dersADI;
    }
    public List<string> LDersID()
    {
        return dersID;
    } 
    public List<string> LOgretmenADI()
    {
        return ogretmenlerAd;
    }
    public List<string> LOgretmenID()
    {
        return ogretmenlerID;
    }
    public string SeciliDersSINIFI()
    {
        return seciliDersSinifi;
    }
}
