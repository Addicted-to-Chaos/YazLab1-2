using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TimetableButtons : MonoBehaviour
{
    [SerializeField] GameObject[] mondayButtons;
    [SerializeField] GameObject[] tuesdayButtons;
    [SerializeField] GameObject[] wednesdayButtons;
    [SerializeField] GameObject[] thursdayButtons;
    [SerializeField] GameObject[] fridayButtons;

    public Color[] colorList = new Color[]
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
    public string p_derslik_id;
    public string p_ogretmen_id;

    public void ShowToast(string message, float duration)
    {
        StartCoroutine(ShowToastCoroutine(message, duration));
    }
    private IEnumerator ShowToastCoroutine(string message, float duration)
    {
        // Metni g�ster
        toastText.text = message;
        toastText.gameObject.SetActive(true);

        // Belirtilen s�re kadar bekle
        yield return new WaitForSeconds(duration);

        // S�re doldu�unda metni gizle
        toastText.gameObject.SetActive(false);
    }
    #region dersAtama
    public async void Monday1_1Async()
    {
        p_saat_id = "1";
        p_gun_id = "1";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-1.1")|| hangiDonem == PlayerPrefs.GetString("1036O-1.1"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-1.1") || hangiDonem == PlayerPrefs.GetString("1040O-1.1"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-1.1") || hangiDonem == PlayerPrefs.GetString("1041O-1.1"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-1.1") || hangiDonem == PlayerPrefs.GetString("1044O-1.1"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }
        

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
                mondayButtons[0].GetComponentInChildren<TextMeshProUGUI>().text = dersAdi + "\n" + ogretmenAdi;
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-1.1", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-1.1", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-1.1", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-1.1", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-1.1", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-1.1", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-1.1", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-1.1", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);

    }



    public async void Monday2_1Async()
    {
        p_saat_id = "2";
        p_gun_id = "1";

        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-2.1")|| hangiHoca == PlayerPrefs.GetString("1036O-2.1"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-2.1") || hangiHoca == PlayerPrefs.GetString("1040O-2.1"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-2.1") || hangiHoca == PlayerPrefs.GetString("1041O-2.1"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-2.1") || hangiHoca == PlayerPrefs.GetString("1044O-2.1"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-2.1", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-2.1", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-2.1", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-2.1", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-2.1", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-2.1", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-2.1", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-2.1", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
            }
        }
    Son:
        ShowToast("!", 2f);

    }
    public async void Monday3_1Async()
    {
        p_saat_id = "3";
        p_gun_id = "1";

        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();


        if (hangiDonem == PlayerPrefs.GetString("1036-3.1")||hangiHoca== PlayerPrefs.GetString("1036O-3.1"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-3.1") || hangiHoca == PlayerPrefs.GetString("1040O-3.1"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-3.1") || hangiHoca == PlayerPrefs.GetString("1041O-3.1"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-3.1") || hangiHoca == PlayerPrefs.GetString("1044O-3.1"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-3.1", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-3.1", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-3.1", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-3.1", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-3.1", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-3.1", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-3.1", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-3.1", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
            }
        }
    Son:
        ShowToast("!", 2f);

    }
    public async void Monday4_1Async()
    {
        p_saat_id = "4";
        p_gun_id = "1";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca= dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-4.1")||hangiHoca==PlayerPrefs.GetString("1036O-4.1"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-4.1") || hangiHoca == PlayerPrefs.GetString("1040O-4.1"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-4.1") || hangiHoca == PlayerPrefs.GetString("1041O-4.1"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-4.1") || hangiHoca == PlayerPrefs.GetString("1044O-4.1"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-4.1", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-4.1", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-4.1", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-4.1", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-4.1", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-4.1", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-4.1", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-4.1", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);

    }
    public async void Monday5_1Async()
    {
        p_saat_id = "5";
        p_gun_id = "1";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-5.1")||hangiHoca==PlayerPrefs.GetString("1036O-5.1"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-5.1") || hangiHoca == PlayerPrefs.GetString("1040O-5.1"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-5.1") || hangiHoca == PlayerPrefs.GetString("1041O-5.1"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-5.1") || hangiHoca == PlayerPrefs.GetString("1044O-5.1"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-5.1", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-5.1", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-5.1", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-5.1", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-5.1", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-5.1", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-5.1", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-5.1", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
            }
        }
    Son:
        ShowToast("!", 2f);

    }
    public async void Monday6_1Async()
    {
        p_saat_id = "6";
        p_gun_id = "1";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-6.1")||hangiHoca==PlayerPrefs.GetString("1036O-6.1"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-6.1") || hangiHoca == PlayerPrefs.GetString("1040O-6.1"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-6.1") || hangiHoca == PlayerPrefs.GetString("1041O-6.1"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-6.1") || hangiHoca == PlayerPrefs.GetString("1044O-6.1"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-6.1", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-6.1", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-6.1", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-6.1", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-6.1", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-6.1", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-6.1", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-6.1", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
            }
        }
    Son:
        ShowToast("!", 2f);
    }
    public async void Monday7_1Async()
    {
        p_saat_id = "7";
        p_gun_id = "1";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();

        if (hangiDonem == PlayerPrefs.GetString("1036-7.1"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-7.1"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-7.1"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-7.1"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-7.1", dropdownDatas.SeciliDersSINIFI());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-7.1", dropdownDatas.SeciliDersSINIFI());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-7.1", dropdownDatas.SeciliDersSINIFI());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-7.1", dropdownDatas.SeciliDersSINIFI());
                }
            }
            else
            {
            }
        }
    Son:
        ShowToast("!", 2f);
    }
    public async void Monday8_1Async()
    {
        p_saat_id = "8";
        p_gun_id = "1";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();


        if (hangiDonem == PlayerPrefs.GetString("1036-8.1")||hangiHoca==PlayerPrefs.GetString("1036O-8.1"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-8.1") || hangiHoca == PlayerPrefs.GetString("1040O-8.1"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-8.1") || hangiHoca == PlayerPrefs.GetString("1041O-8.1"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-8.1") || hangiHoca == PlayerPrefs.GetString("1044O-8.1"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-8.1", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-8.1", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-8.1", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-8.1", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-8.1", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-8.1", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-8.1", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-8.1", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }
    public async void Monday9_1Async()
    {
        p_saat_id = "9";
        p_gun_id = "1";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-9.1")||hangiHoca== PlayerPrefs.GetString("1036O-9.1"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-9.1") || hangiHoca == PlayerPrefs.GetString("1040O-9.1"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-9.1") || hangiHoca == PlayerPrefs.GetString("1041O-9.1"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-9.1") || hangiHoca == PlayerPrefs.GetString("1044O-9.1"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-9.1", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-9.1", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-9.1", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-9.1", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-9.1", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-9.1", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-9.1", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-9.1", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }

    public async void Tuesday1_2Async()
    {
        p_saat_id = "1";
        p_gun_id = "2";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-1.2")||hangiHoca== PlayerPrefs.GetString("1036O-1.2"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-1.2") || hangiHoca == PlayerPrefs.GetString("1040O-1.2"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-1.2") || hangiHoca == PlayerPrefs.GetString("1041O-1.2"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-1.2") || hangiHoca == PlayerPrefs.GetString("1044O-1.2"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-1.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-1.2", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-1.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-1.2", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-1.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-1.2", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-1.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-1.2", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }
    public async void Tuesday2_2Async()
    {
        p_saat_id = "2";
        p_gun_id = "2";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca=dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-2.2")||hangiHoca==PlayerPrefs.GetString("1036O-2.2"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-2.2") || hangiHoca == PlayerPrefs.GetString("1040O-2.2"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-2.2") || hangiHoca == PlayerPrefs.GetString("1041O-2.2"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-2.2") || hangiHoca == PlayerPrefs.GetString("1044O-2.2"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-2.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-2.2", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-2.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-2.2", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-2.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-2.2", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-2.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-2.2", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }
    public async void Tuesday3_2Async()
    {
        p_saat_id = "3";
        p_gun_id = "2";

        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-3.2")||hangiHoca==PlayerPrefs.GetString("1036O-3.2"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-3.2") || hangiHoca == PlayerPrefs.GetString("1040O-3.2"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-3.2") || hangiHoca == PlayerPrefs.GetString("1041O-3.2"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-3.2") || hangiHoca == PlayerPrefs.GetString("1041O-3.2"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-3.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-3.2", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-3.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-3.2", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-3.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-3.2", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-3.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-3.2", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }
    public async void Tuesday4_2Async()
    {
        p_saat_id = "4";
        p_gun_id = "2";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-4.2")||hangiHoca==PlayerPrefs.GetString("1036O-4.2"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-4.2") || hangiHoca == PlayerPrefs.GetString("1040O-4.2"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-4.2") || hangiHoca == PlayerPrefs.GetString("1041O-4.2"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-4.2") || hangiHoca == PlayerPrefs.GetString("1044O-4.2"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-4.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-4.2", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-4.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-4.2", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-4.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-4.2", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-4.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-4.2", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }
    public async void Tuesday5_2Async()
    {
        p_saat_id = "5";
        p_gun_id = "2";

        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-5.2")||hangiHoca== PlayerPrefs.GetString("1036O-5.2"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-5.2") || hangiHoca == PlayerPrefs.GetString("1040O-5.2"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-5.2") || hangiHoca == PlayerPrefs.GetString("1041O-5.2"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-5.2") || hangiHoca == PlayerPrefs.GetString("1044O-5.2"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-5.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-5.2", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-5.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-5.2", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-5.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-5.2", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-5.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-5.2", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }
    public async void Tuesday6_2Async()
    {
        p_saat_id = "6";
        p_gun_id = "2";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-6.2")||hangiHoca==PlayerPrefs.GetString("1036O-6.2"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-6.2") || hangiHoca == PlayerPrefs.GetString("1040O-6.2"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-6.2") || hangiHoca == PlayerPrefs.GetString("1041O-6.2"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-6.2") || hangiHoca == PlayerPrefs.GetString("1044O-6.2"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-6.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-6.2", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-6.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-6.2", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-6.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-6.2", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-6.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-6.2", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }
    public async void Tuesday7_2Async()
    {
        p_saat_id = "7";
        p_gun_id = "2";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-7.2")||hangiHoca==PlayerPrefs.GetString("1036O-7.2"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-7.2")||hangiHoca == PlayerPrefs.GetString("1040O-7.2"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-7.2")|| hangiHoca == PlayerPrefs.GetString("1041O-7.2"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-7.2")|| hangiHoca == PlayerPrefs.GetString("1044O-7.2"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-7.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-7.2", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-7.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-7.2", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-7.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-7.2", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-7.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-7.2", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }
    public async void Tuesday8_2Async()
    {
        p_saat_id = "8";
        p_gun_id = "2";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-8.2")||hangiHoca==PlayerPrefs.GetString("1036O-8.2"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-8.2") || hangiHoca == PlayerPrefs.GetString("1040O-8.2"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-8.2") || hangiHoca == PlayerPrefs.GetString("1041O-8.2"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-8.2") || hangiHoca == PlayerPrefs.GetString("1044O-8.2"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-8.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-8.2", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-8.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-8.2", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-8.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-8.2", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-8.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-8.2", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }
    public async void Tuesday9_2Async()
    {
        p_saat_id = "9";
        p_gun_id = "2";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();


        if (hangiDonem == PlayerPrefs.GetString("1036-9.2") || hangiHoca == PlayerPrefs.GetString("1036O-9.2"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-9.2") || hangiHoca == PlayerPrefs.GetString("1040O-9.2"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-9.2") || hangiHoca == PlayerPrefs.GetString("1041O-9.2"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-9.2") || hangiHoca == PlayerPrefs.GetString("1044O-9.2"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-9.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-9.2", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-9.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-9.2", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-9.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-9.2", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-9.2", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-9.2", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }
    public async void Wednesday1_3Async()
    {
        p_saat_id = "1";
        p_gun_id = "3";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-1.3") || hangiHoca == PlayerPrefs.GetString("1036O-1.3"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-1.3") || hangiHoca == PlayerPrefs.GetString("1040O-1.3"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-1.3") || hangiHoca == PlayerPrefs.GetString("1041O-1.3"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-1.3") || hangiHoca == PlayerPrefs.GetString("1044O-1.3"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-1.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-1.3", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-1.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-1.3", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-1.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-1.3", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-1.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-1.3", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }
    public async void Wednesday2_3Async()
    {
        p_saat_id = "2";
        p_gun_id = "3";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-2.3")||hangiHoca== PlayerPrefs.GetString("1036O-2.3"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-2.3") || hangiHoca == PlayerPrefs.GetString("1040O-2.3"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-2.3") || hangiHoca == PlayerPrefs.GetString("1041O-2.3"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-2.3") || hangiHoca == PlayerPrefs.GetString("1044O-2.3"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-2.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-2.3", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-2.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-2.3", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-2.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-2.3", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-2.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-2.3", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }
    public async void Wednesday3_3Async()
    {
        p_saat_id = "3";
        p_gun_id = "3";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-3.3") || hangiHoca == PlayerPrefs.GetString("1036O-3.3"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-3.3") || hangiHoca == PlayerPrefs.GetString("1040O-3.3"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-3.3") || hangiHoca == PlayerPrefs.GetString("1041O-3.3"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-3.3") || hangiHoca == PlayerPrefs.GetString("1044O-3.3"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-3.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-3.3", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-3.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-3.3", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-3.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-3.3", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-3.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-3.3", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }
    public async void Wednesday4_3Async()
    {
        p_saat_id = "4";
        p_gun_id = "3";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca=dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-4.3")||hangiHoca==PlayerPrefs.GetString("1036O-4.3"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-4.3") || hangiHoca == PlayerPrefs.GetString("1040O-4.3"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-4.3") || hangiHoca == PlayerPrefs.GetString("1041O-4.3"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-4.3") || hangiHoca == PlayerPrefs.GetString("1044O-4.3"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-4.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-4.3", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-4.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-4.3", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-4.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-4.3", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-4.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-4.3", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }
    public async void Wednesday5_3Async()
    {
        p_saat_id = "5";
        p_gun_id = "3";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-5.3")||hangiHoca==PlayerPrefs.GetString("1036O-5,3"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-5.3") || hangiHoca == PlayerPrefs.GetString("1040O-5,3"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-5.3") || hangiHoca == PlayerPrefs.GetString("1041O-5,3"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-5.3") || hangiHoca == PlayerPrefs.GetString("1044O-5,3"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-5.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-5.3", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-5.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-5.3", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-5.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-5.3", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-5.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-5.3", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }
    public async void Wednesday6_3Async()
    {
        p_saat_id = "6";
        p_gun_id = "3";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-6.3")||hangiHoca==PlayerPrefs.GetString("1036O-6.3"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-6.3") || hangiHoca == PlayerPrefs.GetString("1040O-6.3"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-6.3") || hangiHoca == PlayerPrefs.GetString("1041O-6.3"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-6.3") || hangiHoca == PlayerPrefs.GetString("1044O-6.3"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-6.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-6.3", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-6.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-6.3", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-6.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-6.3", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-6.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-6.3", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }
    public async void Wednesday7_3Async()
    {
        p_saat_id = "7";
        p_gun_id = "3";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-7.3")||hangiHoca==PlayerPrefs.GetString("1036O-7.3"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-7.3") || hangiHoca == PlayerPrefs.GetString("1040O-7.3"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-7.3") || hangiHoca == PlayerPrefs.GetString("1041O-7.3"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-7.3") || hangiHoca == PlayerPrefs.GetString("1044O-7.3"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-7.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-7.3", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-7.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-7.3", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-7.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-7.3", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-7.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-7.3", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }
    public async void Wednesday8_3Async()
    {
        p_saat_id = "8";
        p_gun_id = "3";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-8.3")||hangiHoca==PlayerPrefs.GetString("1036O-8.3"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-8.3") || hangiHoca == PlayerPrefs.GetString("1040O-8.3"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-8.3") || hangiHoca == PlayerPrefs.GetString("1041O-8.3"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-8.3") || hangiHoca == PlayerPrefs.GetString("1044O-8.3"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-8.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-8.3", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-8.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-8.3", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-8.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-8.3", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-8.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-8.3", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }
    public async void Wednesday9_3Async()
    {
        p_saat_id = "9";
        p_gun_id = "3";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-9.3")||hangiHoca==PlayerPrefs.GetString("1036O-9.3"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-9.3") || hangiHoca == PlayerPrefs.GetString("1040O-9.3"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-9.3") || hangiHoca == PlayerPrefs.GetString("1041O-9.3"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-9.3") || hangiHoca == PlayerPrefs.GetString("1044O-9.3"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-9.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-9.3", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-9.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-9.3", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-9.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-9.3", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-9.3", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-9.3", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }

    public async void Thursday1_4Async()
    {
        p_saat_id = "1";
        p_gun_id = "4";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-1.4")||hangiHoca==PlayerPrefs.GetString("1036O-1.4"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-1.4") || hangiHoca == PlayerPrefs.GetString("1040O-1.4"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-1.4") || hangiHoca == PlayerPrefs.GetString("1041O-1.4"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-1.4") || hangiHoca == PlayerPrefs.GetString("1044O-1.4"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-1.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-1.4", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-1.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-1.4", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-1.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-1.4", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-1.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-1.4", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }
    public async void Thursday2_4Async()
    {
        p_saat_id = "2";
        p_gun_id = "4";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-2.4")||hangiHoca==PlayerPrefs.GetString("1036O-2.4"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-2.4") || hangiHoca == PlayerPrefs.GetString("1040O-2.4"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-2.4") || hangiHoca == PlayerPrefs.GetString("1041O-2.4"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-2.4") || hangiHoca == PlayerPrefs.GetString("1044O-2.4"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-2.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-2.4", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-2.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-2.4", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-2.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-2.4", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-2.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-2.4", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }
    public async void Thursday3_4Async()
    {
        p_saat_id = "3";
        p_gun_id = "4";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-3.4")|| hangiHoca==PlayerPrefs.GetString("1036O-3.4"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-3.4") || hangiHoca == PlayerPrefs.GetString("1040O-3.4"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-3.4") || hangiHoca == PlayerPrefs.GetString("1041O-3.4"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-3.4") || hangiHoca == PlayerPrefs.GetString("1044O-3.4"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-3.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-3.4", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-3.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-3.4", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-3.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-3.4", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-3.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-3.4", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }
    public async void Thursday4_4Async()
    {
        p_saat_id = "4";
        p_gun_id = "4";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-4.4")||hangiHoca==PlayerPrefs.GetString("1036O-4.4"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-4.4") || hangiHoca == PlayerPrefs.GetString("1040O-4.4"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-4.4") || hangiHoca == PlayerPrefs.GetString("1041O-4.4"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-4.4") || hangiHoca == PlayerPrefs.GetString("1044O-4.4"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-4.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-4.4", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-4.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-4.4", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-4.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-4.4", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-4.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-4.4", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }
    public async void Thursday5_4Async()
    {
        p_saat_id = "5";
        p_gun_id = "4";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-5.4")||hangiHoca==PlayerPrefs.GetString("1036O-5.4"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-5.4") || hangiHoca == PlayerPrefs.GetString("1040O-5.4"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-5.4") || hangiHoca == PlayerPrefs.GetString("1041O-5.4"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-5.4") || hangiHoca == PlayerPrefs.GetString("1044O-5.4"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-5.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-5.4", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-5.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-5.4", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-5.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-5.4", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-5.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-5.4", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }
    public async void Thursday6_4Async()
    {
        p_saat_id = "6";
        p_gun_id = "4";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-6.4")||hangiHoca== PlayerPrefs.GetString("1036O-6.4"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-6.4") || hangiHoca == PlayerPrefs.GetString("1040O-6.4"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-6.4") || hangiHoca == PlayerPrefs.GetString("1041O-6.4"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-6.4") || hangiHoca == PlayerPrefs.GetString("1044O-6.4"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-6.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-6.4", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-6.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-6.4", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-6.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-6.4", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-6.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-6.4", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }
    public async void Thursday7_4Async()
    {
        p_saat_id = "7";
        p_gun_id = "4";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-7.4") || hangiHoca == PlayerPrefs.GetString("1036O-7.4"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-7.4")|| hangiHoca==PlayerPrefs.GetString("1040O-7.4"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-7.4") || hangiHoca == PlayerPrefs.GetString("1041O-7.4"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-7.4") || hangiHoca == PlayerPrefs.GetString("1044O-7.4"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-7.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-7.4", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-7.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-7.4", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-7.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-7.4", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-7.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-7.4", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }
    public async void Thursday8_4Async()
    {
        p_saat_id = "8";
        p_gun_id = "4";

        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-8.4")||hangiHoca==PlayerPrefs.GetString("1036O-8.4"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-8.4") || hangiHoca == PlayerPrefs.GetString("1040O-8.4"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-8.4") || hangiHoca == PlayerPrefs.GetString("1041O-8.4"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-8.4") || hangiHoca == PlayerPrefs.GetString("1044O-8.4"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-8.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-8.4", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-8.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-8.4", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-8.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-8.4", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-8.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-8.4", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }
    public async void Thursday9_4Async()
    {
        p_saat_id = "9";
        p_gun_id = "4";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-9.4")||hangiHoca==PlayerPrefs.GetString("1036O-9.4"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-9.4") || hangiHoca == PlayerPrefs.GetString("1040O-9.4"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-9.4") || hangiHoca == PlayerPrefs.GetString("1041O-9.4"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-9.4") || hangiHoca == PlayerPrefs.GetString("1044O-9.4"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-9.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-9.4", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-9.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-9.4", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-9.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-9.4", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-9.4", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-9.4", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }
    public async void Friday1_5Async()
    {
        p_saat_id = "1";
        p_gun_id = "5";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-1.5")||hangiHoca==PlayerPrefs.GetString("1036O-1.5"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-1.5") || hangiHoca == PlayerPrefs.GetString("1040O-1.5"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-1.5") || hangiHoca == PlayerPrefs.GetString("1041O-1.5"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-1.5") || hangiHoca == PlayerPrefs.GetString("1044O-1.5"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-1.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-1.5", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-1.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-1.5", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-1.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-1.5", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-1.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-1.5", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }

    public async void Friday2_5Async()
    {
        p_saat_id = "2";
        p_gun_id = "5";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-2.5")||hangiHoca==PlayerPrefs.GetString("1036O-2.5"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-2.5") || hangiHoca == PlayerPrefs.GetString("1040O-2.5"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-2.5") || hangiHoca == PlayerPrefs.GetString("1041O-2.5"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-2.5") || hangiHoca == PlayerPrefs.GetString("1044O-2.5"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-2.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-2.5", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-2.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-2.5", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-2.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-2.5", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-2.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-2.5", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }
    public async void Friday3_5Async()
    {
        p_saat_id = "3";
        p_gun_id = "5";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-3.5")||hangiDonem==PlayerPrefs.GetString("1036O-3.5"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-3.5") || hangiDonem == PlayerPrefs.GetString("1040O-3.5"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-3.5") || hangiDonem == PlayerPrefs.GetString("1041O-3.5"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-3.5") || hangiDonem == PlayerPrefs.GetString("1044O-3.5"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-3.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-3.5", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-3.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-3.5", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-3.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-3.5", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-3.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-3.5", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }

    public async void Friday4_5Async()
    {
        p_saat_id = "4";
        p_gun_id = "5";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-4.5")||hangiHoca==PlayerPrefs.GetString("1036O-4.5"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-4.5") || hangiHoca == PlayerPrefs.GetString("1040O-4.5"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-4.5") || hangiHoca == PlayerPrefs.GetString("1041O-4.5"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-4.5") || hangiHoca == PlayerPrefs.GetString("1044O-4.5"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-4.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-4.5", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-4.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-4.5", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-4.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-4.5", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-4.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-4.5", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }
    public async void Friday5_5Async()
    {
        p_saat_id = "5";
        p_gun_id = "5";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-5.5")||hangiHoca==PlayerPrefs.GetString("1036O-5.5"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-5.5") || hangiHoca == PlayerPrefs.GetString("1040O-5.5"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-5.5") || hangiHoca == PlayerPrefs.GetString("1041O-5.5"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-5.5") || hangiHoca == PlayerPrefs.GetString("1044O-5.5"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-5.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-5.5", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-5.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-5.5", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-5.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-5.5", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-5.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-5.5", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }

    public async void Friday6_5Async()
    {
        p_saat_id = "6";
        p_gun_id = "5";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-6.5")|| hangiHoca==PlayerPrefs.GetString("1036O-6.5"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-6.5") || hangiHoca == PlayerPrefs.GetString("1040O-6.5"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-6.5") || hangiHoca == PlayerPrefs.GetString("1041O-6.5"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-6.5") || hangiHoca == PlayerPrefs.GetString("1044O-6.5"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-6.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-6.5", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-6.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-6.5", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-6.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-6.5", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-6.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-6.5", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }

    public async void Friday7_5Async()
    {
        p_saat_id = "7";
        p_gun_id = "5";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-7.5")|| hangiHoca==PlayerPrefs.GetString("1036O-7.5"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-7.5") || hangiHoca == PlayerPrefs.GetString("1040O-7.5"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-7.5") || hangiHoca == PlayerPrefs.GetString("1041O-7.5"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-7.5") || hangiHoca == PlayerPrefs.GetString("1044O-7.5"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-7.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-7.5", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-7.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-7.5", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-7.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-7.5", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-7.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-7.5", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }
    public async void Friday8_5Async()
    {
        p_saat_id = "8";
        p_gun_id = "5";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-8.5")||hangiHoca==PlayerPrefs.GetString("1036O-8.5"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-8.5") || hangiHoca == PlayerPrefs.GetString("1040O-8.5"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-8.5") || hangiHoca == PlayerPrefs.GetString("1041O-8.5"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-8.5") || hangiHoca == PlayerPrefs.GetString("1044O-8.5"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-8.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-8.5", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-8.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-8.5", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-8.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-8.5", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-8.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-8.5", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }
    public async void Friday9_5Async()
    {
        p_saat_id = "9";
        p_gun_id = "5";
        string hangiDonem = dropdownDatas.SeciliDersSINIFI();
        string hangiHoca = dropdownDatas.SeciliOgretmen();

        if (hangiDonem == PlayerPrefs.GetString("1036-9.5")||hangiHoca==PlayerPrefs.GetString("1036O-9.5"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1040-9.5") || hangiHoca == PlayerPrefs.GetString("1040O-9.5"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1041-9.5") || hangiHoca == PlayerPrefs.GetString("1041O-9.5"))
        {
            goto Son;
        }
        else if (hangiDonem == PlayerPrefs.GetString("1044-9.5") || hangiHoca == PlayerPrefs.GetString("1044O-9.5"))
        {
            goto Son;
        }
        else
        {
            goto Devam;
        }

    Devam:
        {
            if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
            {
                //buton deaktif olup text yaz�cak dersad� ve s�n�f�
                
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

                if (p_derslik_id == "1")
                {
                    PlayerPrefs.SetString("1036-9.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1036O-9.5", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "2")
                {
                    PlayerPrefs.SetString("1040-9.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1040O-9.5", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "3")
                {
                    PlayerPrefs.SetString("1041-9.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1041O-9.5", dropdownDatas.SeciliOgretmen());
                }
                else if (p_derslik_id == "4")
                {
                    PlayerPrefs.SetString("1044-9.5", dropdownDatas.SeciliDersSINIFI());
                    PlayerPrefs.SetString("1044O-9.5", dropdownDatas.SeciliOgretmen());
                }
            }
            else
            {
                
            }
        }
    Son:
        ShowToast("!", 2f);
    }
    #endregion dersAtama
    string dersAdi;
    string ogretmenAdi;

    public Button[] buttons;


    // Update is called once per frame
    void Update()
    {
        p_ders_id = dropdownDatas.SeciliDers();
        p_ogretmen_id = dropdownDatas.SeciliOgretmen();
        dersAdi = dropdownDatas.DersAdi();
        ogretmenAdi = dropdownDatas.OgretmenADi();

        if (String.IsNullOrWhiteSpace(p_ogretmen_id) || String.IsNullOrWhiteSpace(p_ders_id))
        {

            foreach (Button button in buttons)
            {

                button.GetComponent<Button>().interactable = false;
            }
        }
        else
        {

            foreach (Button button in buttons)
            {
                if (String.IsNullOrWhiteSpace(button.GetComponentInChildren<TextMeshProUGUI>().text))
                {


                    button.GetComponent<Button>().interactable = true;
                }

            }
        }


    }
}
