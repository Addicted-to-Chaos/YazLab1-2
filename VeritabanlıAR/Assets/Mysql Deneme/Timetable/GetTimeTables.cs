using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField] string derslik;
    #endregion sinifProgramlari

    List<string> ders_programi_id = new List<string>();
    List<string> ders_id = new List<string>();
    List<string> derslik_id = new List<string>();
    List<string> gun_id = new List<string>();
    List<string> saat_id = new List<string>();
    List<string> ders_sinif = new List<string>();

    private void Awake()
    {
        dataFetch=FindObjectOfType<MysqlDataFetch>();
        dersProgrami1036 = dataFetch.bin36();
        dersProgrami1040 = dataFetch.bin40();
        dersProgrami1041 = dataFetch.bin41();
        dersProgrami1044 = dataFetch.bin44();
    }

    private void Start()
    {
        if (derslik.Equals(dersProgrami1036))
        {
            b1036();
        }
        else if (derslik.Equals(dersProgrami1040))
        {
            b1040();
        }
        else if (derslik.Equals(dersProgrami1041))
        {
            b1041();
        }
        else if (derslik.Equals(dersProgrami1044))
        {
            b1044();
        }
    }


    void b1036()
    {
        for (int i = 0; i < dersProgrami1036.Length - 1; i++)
        {
            string[] parcalar = dersProgrami1036[i].Trim().Split(",");
            ders_programi_id.Add(parcalar[0]);
            ders_id.Add(parcalar[1]);
            derslik_id.Add(parcalar[2]);
            gun_id.Add(parcalar[3]);
            saat_id.Add(parcalar[4]);
            ders_sinif.Add(parcalar[5]);

        }
    }
    void b1040()
    {
        for (int i = 0; i < dersProgrami1040.Length - 1; i++)
        {
            string[] parcalar = dersProgrami1040[i].Trim().Split(",");
            ders_programi_id.Add(parcalar[0]);
            ders_id.Add(parcalar[1]);
            derslik_id.Add(parcalar[2]);
            gun_id.Add(parcalar[3]);
            saat_id.Add(parcalar[4]);
            ders_sinif.Add(parcalar[5]);

        }
    }
    void b1041()
    {
        for (int i = 0; i < dersProgrami1041.Length - 1; i++)
        {
            string[] parcalar = dersProgrami1041[i].Trim().Split(",");
            ders_programi_id.Add(parcalar[0]);
            ders_id.Add(parcalar[1]);
            derslik_id.Add(parcalar[2]);
            gun_id.Add(parcalar[3]);
            saat_id.Add(parcalar[4]);
            ders_sinif.Add(parcalar[5]);

        }

    }
    void b1044()
    {
        for (int i = 0; i < dersProgrami1044.Length - 1; i++)
        {
            string[] parcalar = dersProgrami1044[i].Trim().Split(",");
            ders_programi_id.Add(parcalar[0]);
            ders_id.Add(parcalar[1]);
            derslik_id.Add(parcalar[2]);
            gun_id.Add(parcalar[3]);
            saat_id.Add(parcalar[4]);
            ders_sinif.Add(parcalar[5]);

        }
    }
}
