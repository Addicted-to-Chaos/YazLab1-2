using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EkleCikarManager : MonoBehaviour
{
    DropdownDatas dd;
    [SerializeField] string p_ders_id;
    [SerializeField] string p_ogretmen_id;
    public string dersSinifSelected;

    public TMP_InputField ders_adi;
    public TMP_InputField ogretmen_adi;
    public TMP_Dropdown aa;

    private void Update()
    {
        dd = FindObjectOfType<DropdownDatas>();
        p_ders_id = dd.seciliDersID;
        p_ogretmen_id = dd.SeciliOgretmen();
        dersSinifSelected = aa.value.ToString();

    }




    public async void DersCikar()
    {
        if (await MysqlPostManager.dersSil(p_ders_id))
        {
            print("BaþarýylaSilindi");
        }
        else
            print("Silinmedi");
    }

    public async void DersEkle()
    {
        if (await MysqlPostManager.dersEkle(ders_adi.text, dersSinifSelected))
        {
            print("BaþarýylaSilindi");
        }
        else
            print("Silinmedi");
    }

    public async void OgretmenEkle()
    {
        if (await MysqlPostManager.ogretmenEkle(ogretmen_adi.text))
        {
            print("BaþarýylaSilindi");
        }
        else
            print("Silinmedi");
    }

    public async void OgretmenSil()
    {
        if (await MysqlPostManager.ogretmenSil(p_ogretmen_id))
        {
            print("BaþarýylaSilindi");
        }
        else
            print("Silinmedi");
    }

    public void MenuBack()
    {
        DeleteLesson.silmeEnabled = false;
        SceneManager.LoadScene("Menu");
    }
}