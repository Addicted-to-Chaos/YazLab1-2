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

    /* Bunlar önemli*/
    public string seciliOgretmenID; 
    public string seciliOgretmenAD;

    [Header("Dersler")]
    [SerializeField] TMP_Dropdown derslerDropDown;
    string[] dersler;
    List<string> dersID = new List<string>();
    List<string> dersADI = new List<string>();
    List<string> dersSinifi = new List<string>();


    /* Bunlar önemli*/
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
        int i = ogretmenlerDropDown.value;
        
                seciliOgretmenID = ogretmenlerID[i-1];
                seciliOgretmenAD = ogretmenlerAd[i-1];
            
        
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

            var option = new TMP_Dropdown.OptionData(parcalar[1] + " / " + parcalar[2]+". sýnýf");
            derslerDropDown.options.Add(option);
        }

    }

    public void HandleDerslerData()
    {
        int i = derslerDropDown.value;       
            
                seciliDersID = dersID[i-1];
                seciliDersADI = dersADI[i-1];
                seciliDersSinifi = dersSinifi[i - 1];           
        
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
    public List<string> LSeciliDersSINIFI()
    {
        return dersSinifi;
    }
}
