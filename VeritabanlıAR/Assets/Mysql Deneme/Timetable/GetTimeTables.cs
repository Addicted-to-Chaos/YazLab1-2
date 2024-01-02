using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetTimeTables : MonoBehaviour
{



    //ilk ders_programi_id
    //ikinci ders_id
    //ücüncü derslik_id
    //dördüncü gun_id
    //besinci saat_id
    //altinci ders_sinif  
    MysqlDataFetch dataFetch;

    #region sinifProgramlari
    string[] dersProgrami1036;
    string[] dersProgrami1040;
    string[] dersProgrami1041;
    string[] dersProgrami1044;
    
    #endregion sinifProgramlari

    List<string> ders_programi_id = new List<string>();
    List<string> ders_id = new List<string>();
    List<string> ogretmen_id = new List<string>();
    List<string> derslik_id = new List<string>();
    List<string> gun_id = new List<string>();
    List<string> saat_id = new List<string>();
    List<string> ders_sinif = new List<string>();

    [SerializeField] bool bin36=false;
    [SerializeField] bool bin40=false;
    [SerializeField] bool bin41=false;
    [SerializeField] bool bin44=false;

    [SerializeField] GameObject[] pazartesi;
    [SerializeField] GameObject[] sali;
    [SerializeField] GameObject[] carsamba;
    [SerializeField] GameObject[] persembe;
    [SerializeField] GameObject[] cuma;

    DropdownDatas dropdownDatas;
    List<string> dropDownDersID;
    List<string> dropDownDersADI;
    List<string> dropDownOgretmenlerID;
    List<string> dropDownOgretmenlerADI;

    string ders;
    string ogretmen;

    private void Awake()
    {
        
    }

    private void Start()
    {
        dataFetch = FindObjectOfType<MysqlDataFetch>();
        dropdownDatas = FindObjectOfType<DropdownDatas>();
        dropDownDersADI = dropdownDatas.LDersADI();
        dropDownDersID = dropdownDatas.LDersID();
        dropDownOgretmenlerADI = dropdownDatas.LOgretmenADI();
        dropDownOgretmenlerID = dropdownDatas.LOgretmenID();
        dersProgrami1036 = dataFetch.bin36();
        dersProgrami1040 = dataFetch.bin40();
        dersProgrami1041 = dataFetch.bin41();
        dersProgrami1044 = dataFetch.bin44();

        if (bin36)
        {
            b1036();
        }
        if (bin40)
        {
            b1040();
        }
        else if (bin41)
        {
            b1041();
        }
        else if (bin44)
        {
            b1044();
        }
    }
    private void Update()
    {
        //dersProgrami1036 = dataFetch.bin36();
       Debug.Log(dropDownDersID.Count);
        //b1036();
        
    }

    void b1036()
    {

        for (int i = 0; i < dataFetch.dersProgrami1036.Length - 1; i++)
        {
            string[] parcalar = dataFetch.dersProgrami1036[i].Trim().Split(",");
            ders_programi_id.Add(parcalar[0]);
            ders_id.Add(parcalar[1]);
            ogretmen_id.Add(parcalar[2]);
            derslik_id.Add(parcalar[3]);
            gun_id.Add(parcalar[4]);
            saat_id.Add(parcalar[5]);
            ders_sinif.Add(parcalar[6]);

            ////////

            for (int j = 0; j < dropDownDersID.Count; j++)
            {
                if (parcalar[1].Equals(dropDownDersID[j]))
                {
                    ders = dropDownDersADI[j];

                    Debug.Log(ders);
                }
                if (parcalar[2].Equals(dropDownOgretmenlerID[j]))
                {
                    ogretmen = dropDownOgretmenlerADI[j];
                    Debug.Log(ogretmen);
                }

            }


            switch (parcalar[4])
            {
                case "1":
                    int index1;
                    if (int.TryParse(parcalar[5], out index1))
                    {
                        pazartesi[index1-1].GetComponentInChildren<TextMeshProUGUI>().text = ders + "\n" + ogretmen;
                        pazartesi[index1-1].GetComponent<Button>().interactable = false;
                    }
                    break;
                case "2":
                    int index2;
                    if (int.TryParse(parcalar[5], out index2))
                    {
                        sali[index2-1].GetComponentInChildren<TextMeshProUGUI>().text = ders + "\n" + ogretmen;
                        sali[index2 - 1].GetComponent<Button>().interactable = false;
                    }
                    break;
                case "3":
                    int index3;
                    if (int.TryParse(parcalar[5], out index3))
                    {
                        carsamba[index3-1].GetComponentInChildren<TextMeshProUGUI>().text = ders + "\n" + ogretmen;
                        carsamba[index3-1].GetComponent<Button>().interactable = false;
                    }
                    break;
                case "4":
                    int index4;
                    if (int.TryParse(parcalar[5], out index4))
                    {
                        persembe[index4-1].GetComponentInChildren<TextMeshProUGUI>().text = ders + "\n" + ogretmen;
                        persembe[index4 - 1].GetComponent<Button>().interactable = false;
                    }
                    break;
                case "5":
                    int index5;
                    if (int.TryParse(parcalar[5], out index5))
                    {
                        cuma[index5-1].GetComponentInChildren<TextMeshProUGUI>().text = ders + "\n" + ogretmen;
                        cuma[index5 - 1].GetComponent<Button>().interactable = false;
                    }
                    break;
                default:
                    break;
            }
        }

    }
            

    
    void b1040()
    {
        if (dersProgrami1036[0].Trim() != "0 result")
        {
            for (int i = 0; i < dersProgrami1040.Length - 1; i++)
            {
                string[] parcalar = dersProgrami1040[i].Trim().Split(",");
                ders_programi_id.Add(parcalar[0]);
                ders_id.Add(parcalar[1]);
                ogretmen_id.Add(parcalar[2]);
                derslik_id.Add(parcalar[3]);
                gun_id.Add(parcalar[4]);
                saat_id.Add(parcalar[5]);
                ders_sinif.Add(parcalar[6]);

            }

            
        }
    }
    void b1041()
    {
        if (dersProgrami1036[0].Trim() != "0 result")
        {
            for (int i = 0; i < dersProgrami1041.Length - 1; i++)
            {
                string[] parcalar = dersProgrami1041[i].Trim().Split(",");
                ders_programi_id.Add(parcalar[0]);
                ders_id.Add(parcalar[1]);
                ogretmen_id.Add(parcalar[2]);
                derslik_id.Add(parcalar[3]);
                gun_id.Add(parcalar[4]);
                saat_id.Add(parcalar[5]);
                ders_sinif.Add(parcalar[6]);

            }
        }

    }
    void b1044()
    {
        if (dersProgrami1036[0].Trim() != "0 result")
        {
            for (int i = 0; i < dersProgrami1044.Length - 1; i++)
            {
                string[] parcalar = dersProgrami1044[i].Trim().Split(",");
                ders_programi_id.Add(parcalar[0]);
                ders_id.Add(parcalar[1]);
                ogretmen_id.Add(parcalar[2]);
                derslik_id.Add(parcalar[3]);
                gun_id.Add(parcalar[4]);
                saat_id.Add(parcalar[5]);
                ders_sinif.Add(parcalar[6]);

            }
        }
    }
}
