using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TimetableButtons : MonoBehaviour
{
    [SerializeField] GameObject[] mondayButtons;
    [SerializeField] GameObject[] tuesdayButtons;
    [SerializeField] GameObject[] wednesdayButtons;
    [SerializeField] GameObject[] thursdayButtons;
    [SerializeField] GameObject[] fridayButtons;

    DropdownDatas dropdownDatas;

    private void Awake()
    {
        dropdownDatas = FindObjectOfType<DropdownDatas>();
        p_ders_id = dropdownDatas.seciliDersID;
        p_ogretmen_id = dropdownDatas.seciliOgretmenID;
    }

    public string p_saat_id;
    public string p_gun_id;

    public string p_ders_id;
    [SerializeField] string p_derslik_id;
    public string p_ogretmen_id;


    public async Task Monday1Async()
    {
        p_saat_id = "1";
        p_gun_id = "1";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
        }
        else
            print("Eklenemedi"); //unity toast message
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
