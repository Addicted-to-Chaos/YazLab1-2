using System.Collections;
using System.Collections.Generic;

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimetableButtons : MonoBehaviour
{
    [SerializeField] GameObject[] mondayButtons;
    [SerializeField] GameObject[] tuesdayButtons;
    [SerializeField] GameObject[] wednesdayButtons;
    [SerializeField] GameObject[] thursdayButtons;
    [SerializeField] GameObject[] fridayButtons;

    DropdownDatas dropdownDatas;

    public TextMeshProUGUI toastText;


    private void Awake()
    {
        dropdownDatas = FindObjectOfType<DropdownDatas>();
       
    }

    public string p_saat_id;
    public string p_gun_id;

    public string p_ders_id;
    [SerializeField] string p_derslik_id;
    public string p_ogretmen_id;

    public void ShowToast(string message, float duration)
    {
        StartCoroutine(ShowToastCoroutine(message, duration));
    }
    private IEnumerator ShowToastCoroutine(string message, float duration)
    {
        // Metni göster
        toastText.text = message;
        toastText.gameObject.SetActive(true);

        // Belirtilen süre kadar bekle
        yield return new WaitForSeconds(duration);

        // Süre dolduðunda metni gizle
        toastText.gameObject.SetActive(false);
    }

    public async void Monday1_1Async()
    {
        p_saat_id = "1";
        p_gun_id = "1";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
            mondayButtons[0].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi+"\n"+ ogretmenAdi;
            mondayButtons[0].GetComponent<Button>().interactable = false;
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);
           
            
        }
            

    }
    public async void Monday2_1Async()
    {
        p_saat_id = "2";
        p_gun_id = "1";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }
    }
    public async void Monday3_1Async()
    {
        p_saat_id = "3";
        p_gun_id = "1";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }
    }
    public async void Monday4_1Async()
    {
        p_saat_id = "4";
        p_gun_id = "1";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }
    }
    public async void Monday5_1Async()
    {
        p_saat_id = "5";
        p_gun_id = "1";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }
    }
    public async void Monday6_1Async()
    {
        p_saat_id = "6";
        p_gun_id = "1";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }
    }
    public async void Monday7_1Async()
    {
        p_saat_id = "7";
        p_gun_id = "1";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }
    }
    public async void Monday8_1Async()
    {
        p_saat_id = "8";
        p_gun_id = "1";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }
    }
    public async void Monday9_1Async()
    {
        p_saat_id = "9";
        p_gun_id = "1";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }
    }

    public async void Tuesday1_2Async()
    {
        p_saat_id = "1";
        p_gun_id = "2";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }
    }
    public async void Tuesday2_2Async()
    {
        p_saat_id = "2";
        p_gun_id = "2";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }
    }
    public async void Tuesday3_2Async()
    {
        p_saat_id = "3";
        p_gun_id = "2";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }
    }
    public async void Tuesday4_2Async()
    {
        p_saat_id = "4";
        p_gun_id = "2";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }
    }
    public async void Tuesday5_2Async()
    {
        p_saat_id = "5";
        p_gun_id = "2";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }
    }
    public async void Tuesday6_2Async()
    {
        p_saat_id = "6";
        p_gun_id = "2";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }
    }
    public async void Tuesday7_2Async()
    {
        p_saat_id = "7";
        p_gun_id = "2";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }
    }
    public async void Tuesday8_2Async()
    {
        p_saat_id = "8";
        p_gun_id = "2";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }
    }
    public async void Tuesday9_2Async()
    {
        p_saat_id = "9";
        p_gun_id = "2";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }
    }
    public async void Wednesday1_3Async()
    {
        p_saat_id = "1";
        p_gun_id = "3";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }
    }
    public async void Wednesday2_3Async()
    {
        p_saat_id = "2";
        p_gun_id = "3";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }
    }
    public async void Wednesday3_3Async()
    {
        p_saat_id = "3";
        p_gun_id = "3";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }
    }
    public async void Wednesday4_3Async()
    {
        p_saat_id = "4";
        p_gun_id = "3";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }
    }
    public async void Wednesday5_3Async()
    {
        p_saat_id = "5";
        p_gun_id = "3";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }
    }
    public async void Wednesday6_3Async()
    {
        p_saat_id = "6";
        p_gun_id = "3";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }
    }
    public async void Wednesday7_3Async()
    {
        p_saat_id = "7";
        p_gun_id = "3";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }
    }
    public async void Wednesday8_3Async()
    {
        p_saat_id = "8";
        p_gun_id = "3";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }
    }
    public async void Wednesday9_3Async()
    {
        p_saat_id = "9";
        p_gun_id = "3";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }

    }

    public async void Thursday1_4Async()
    {
        p_saat_id = "1";
        p_gun_id = "4";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }

    }
    public async void Thursday2_4Async()
    {
        p_saat_id = "2";
        p_gun_id = "4";
        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }

    }
    public async void Thursday3_4Async()
    {
        p_saat_id = "3";
        p_gun_id = "4";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }

    }
    public async void Thursday4_4Async()
    {
        p_saat_id = "4";
        p_gun_id = "4";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }

    }
    public async void Thursday5_4Async()
    {
        p_saat_id = "5";
        p_gun_id = "4";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }

    }
    public async void Thursday6_4Async()
    {
        p_saat_id = "6";
        p_gun_id = "4";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }

    }
    public async void Thursday7_4Async()
    {
        p_saat_id = "7";
        p_gun_id = "4";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }

    }
    public async void Thursday8_4Async()
    {
        p_saat_id = "8";
        p_gun_id = "4";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }

    }
    public async void Thursday9_4Async()
    {
        p_saat_id = "9";
        p_gun_id = "4";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }

    }
    public async void Friday1_5Async()
    {
        p_saat_id = "1";
        p_gun_id = "5";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }

    }

    public async void Friday2_5Async()
    {
        p_saat_id = "2";
        p_gun_id = "5";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }

    }

    public async void Friday3_5Async()
    {
        p_saat_id = "3";
        p_gun_id = "5";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }

    }

    public async void Friday4_5Async()
    {
        p_saat_id = "4";
        p_gun_id = "5";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }

    }
    public async void Friday5_5Async()
    {
        p_saat_id = "5";
        p_gun_id = "5";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }

    }

    public async void Friday6_5Async()
    {
        p_saat_id = "6";
        p_gun_id = "5";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }

    }

    public async void Friday7_5Async()
    {
        p_saat_id = "7";
        p_gun_id = "5";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }

    }

    public async void Friday8_5Async()
    {
        p_saat_id = "8";
        p_gun_id = "5";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }

    }
    public async void Friday9_5Async()
    {
        p_saat_id = "9";
        p_gun_id = "5";

        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            //buton deaktif olup text yazýcak dersadý ve sýnýfý
            ShowToast("Eklendi!", 2f);
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }

    }
    string dersAdi;
    string ogretmenAdi;



    // Update is called once per frame
    void Update()
    {
        p_ders_id = dropdownDatas.SeciliDers();
        p_ogretmen_id = dropdownDatas.SeciliOgretmen();
        dersAdi= dropdownDatas.DersAdi();
        ogretmenAdi=dropdownDatas.OgretmenADi();
      

    }
}
