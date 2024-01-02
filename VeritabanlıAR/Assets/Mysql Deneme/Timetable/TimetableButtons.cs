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

    public Color[] colorList=new Color[]
        {
            new Color(1.0f, 0.0f, 0.0f),     // Red
            new Color(1.0f, 0.5f, 0.0f),   // Orange
            new Color(1.0f, 1.0f, 0.0f),   // Yellow
            new Color(0.0f, 1.0f, 0.0f),   // Green
            new Color(0.0f, 1.0f, 1.0f),   // Cyan
            new Color(0.0f, 0.0f, 1.0f),   // Blue
            new Color(1.0f, 0.0f, 1.0f),   // Magenta
            new Color(0.5f, 0.0f, 0.5f),   // Purple
            new Color(0.7f, 0.7f, 0.7f),   // Grey
            new Color(1.0f, 1.0f, 1.0f),   // White
            new Color(0.0f, 0.0f, 0.0f),   // Black
            new Color(0.5f, 0.5f, 0.0f),   // Olive
            new Color(0.5f, 0.0f, 0.5f),   // Maroon
            new Color(0.0f, 0.5f, 0.5f),   // Teal
            new Color(0.5f, 0.5f, 1.0f)    // Light Blue
        };

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
    #region dersAtama
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

            for (int i = 0; i < colorList.Length; i++) 
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = mondayButtons[0].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            mondayButtons[1].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            mondayButtons[1].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = mondayButtons[1].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }

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
            mondayButtons[2].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            mondayButtons[2].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = mondayButtons[2].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            mondayButtons[3].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            mondayButtons[3].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = mondayButtons[3].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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

            mondayButtons[4].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            mondayButtons[4].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = mondayButtons[4].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            mondayButtons[5].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            mondayButtons[5].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = mondayButtons[5].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            mondayButtons[6].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            mondayButtons[6].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = mondayButtons[6].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            mondayButtons[7].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            mondayButtons[7].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = mondayButtons[7].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            mondayButtons[8].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            mondayButtons[8].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = mondayButtons[8].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            tuesdayButtons[0].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            tuesdayButtons[0].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = tuesdayButtons[0].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            tuesdayButtons[1].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            tuesdayButtons[1].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = tuesdayButtons[1].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            tuesdayButtons[2].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            tuesdayButtons[2].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = tuesdayButtons[2].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            tuesdayButtons[3].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            tuesdayButtons[3].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = tuesdayButtons[3].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            tuesdayButtons[4].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            tuesdayButtons[4].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = tuesdayButtons[4].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            tuesdayButtons[5].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            tuesdayButtons[5].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = tuesdayButtons[5].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            tuesdayButtons[6].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            tuesdayButtons[6].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = tuesdayButtons[6].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            tuesdayButtons[7].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            tuesdayButtons[7].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = tuesdayButtons[7].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            tuesdayButtons[8].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            tuesdayButtons[8].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = tuesdayButtons[8].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            wednesdayButtons[0].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            wednesdayButtons[0].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = wednesdayButtons[0].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            wednesdayButtons[1].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            wednesdayButtons[1].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = wednesdayButtons[1].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            wednesdayButtons[2].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            wednesdayButtons[2].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = wednesdayButtons[2].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            wednesdayButtons[3].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            wednesdayButtons[3].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = wednesdayButtons[3].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            wednesdayButtons[4].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            wednesdayButtons[4].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = wednesdayButtons[4].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            wednesdayButtons[5].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            wednesdayButtons[5].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = wednesdayButtons[5].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            wednesdayButtons[6].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            wednesdayButtons[6].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = wednesdayButtons[6].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            wednesdayButtons[7].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            wednesdayButtons[7].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = wednesdayButtons[7].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            wednesdayButtons[8].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            wednesdayButtons[8].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = wednesdayButtons[8].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            thursdayButtons[0].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            thursdayButtons[0].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = thursdayButtons[0].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            thursdayButtons[1].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            thursdayButtons[1].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = thursdayButtons[1].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            thursdayButtons[2].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            thursdayButtons[2].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = thursdayButtons[2].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            thursdayButtons[3].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            thursdayButtons[3].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = thursdayButtons[3].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            thursdayButtons[4].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            thursdayButtons[4].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = thursdayButtons[4].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            thursdayButtons[5].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            thursdayButtons[5].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = thursdayButtons[5].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            thursdayButtons[6].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            thursdayButtons[6].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = thursdayButtons[6].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            thursdayButtons[7].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            thursdayButtons[7].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = thursdayButtons[7].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            thursdayButtons[8].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            thursdayButtons[8].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = thursdayButtons[8].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            fridayButtons[0].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            fridayButtons[0].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = fridayButtons[0].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            fridayButtons[1].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            fridayButtons[1].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = fridayButtons[1].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            fridayButtons[2].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            fridayButtons[2].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = fridayButtons[2].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            fridayButtons[3].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            fridayButtons[3].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = fridayButtons[3].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            fridayButtons[4].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            fridayButtons[4].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = fridayButtons[4].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            fridayButtons[5].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            fridayButtons[5].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = fridayButtons[5].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            fridayButtons[6].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            fridayButtons[6].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = fridayButtons[6].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            fridayButtons[7].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            fridayButtons[7].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = fridayButtons[7].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
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
            fridayButtons[8].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
            fridayButtons[8].GetComponent<Button>().interactable = false;
            for (int i = 0; i < colorList.Length; i++)
            {
                if (p_ders_id.Equals(i.ToString()))
                {
                    Debug.Log("hehe");
                    Image buttonImage = fridayButtons[8].GetComponent<Image>();
                    buttonImage.color = colorList[i];
                }
            }
        }
        else
        {
            ShowToast("Eklenemedi!", 2f);


        }

    }
    #endregion dersAtama
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
