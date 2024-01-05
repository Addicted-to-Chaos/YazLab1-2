using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeleteLesson : MonoBehaviour
{
    public GameObject silmePaneli;
    public static bool silmeEnabled = false;
    private void Start()
    {
        silmePaneli.SetActive(silmeEnabled);
    }

    [SerializeField] string derslik_id;
    public TMP_Dropdown saatId;
    public TMP_Dropdown gunId;
    public async void dersSil()
    {
        if (await MysqlPostManager.dersprogramiSil(derslik_id ,gunId.value.ToString(), saatId.value.ToString()))
        {
            string bir;
            string iki;
            if (derslik_id.Equals("1"))
            {
                 bir ="1036-" + saatId.value.ToString() + "." + gunId.value.ToString();
                 iki ="1036O-" + saatId.value.ToString() + "." + gunId.value.ToString();
                if (PlayerPrefs.HasKey(bir))
                {
                    PlayerPrefs.DeleteKey(bir);
                    PlayerPrefs.DeleteKey(iki);
                    silmeEnabled = true;
                }
                SceneManager.LoadScene("MysqlDeneme");
            }
            else if (derslik_id.Equals("2"))
            {
                 bir = "1040-" + saatId.value.ToString() + "." + gunId.value.ToString();
                 iki = "1040O-" + saatId.value.ToString() + "." + gunId.value.ToString();
                if (PlayerPrefs.HasKey(bir))
                {
                    PlayerPrefs.DeleteKey(bir);
                    PlayerPrefs.DeleteKey(iki);
                    silmeEnabled = true;
                }
                SceneManager.LoadScene("1040");
            }
            else if (derslik_id.Equals("3"))
            {
                 bir = "1041-" + saatId.value.ToString() + "." + gunId.value.ToString();
                 iki = "1041O-" + saatId.value.ToString() + "." + gunId.value.ToString();
                if (PlayerPrefs.HasKey(bir))
                {
                    PlayerPrefs.DeleteKey(bir);
                    PlayerPrefs.DeleteKey(iki);
                    silmeEnabled = true;
                }
                SceneManager.LoadScene("1041");
            }
            else if (derslik_id.Equals("4"))
            {
                 bir = "1044-" + saatId.value.ToString() + "." + gunId.value.ToString();
                 iki = "1044O-" + saatId.value.ToString() + "." + gunId.value.ToString();
                if (PlayerPrefs.HasKey(bir))
                {
                    PlayerPrefs.DeleteKey(bir);
                    PlayerPrefs.DeleteKey(iki);
                    silmeEnabled = true;
                }
                SceneManager.LoadScene("1044");
            }

            print("BaþarýylaSilindi");
            
        }
        else
            print("Silinmedi");
    }

    public void silmePaneliAc()
    {
        silmePaneli.SetActive(true);
    }
    public void silmePaneliKapat()
    {
        silmePaneli.SetActive(false);
        silmeEnabled = false;
    }
}
