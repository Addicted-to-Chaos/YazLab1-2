using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeleteLesson : MonoBehaviour
{
    public GameObject silmePaneli;
    private void Start()
    {
        silmePaneli.SetActive(false);
    }

    [SerializeField] string derslik_id;
    public TMP_Dropdown saatId;
    public TMP_Dropdown gunId;
    public async void dersSil()
    {
        if (await MysqlPostManager.dersprogramiSil(derslik_id ,gunId.value.ToString(), saatId.value.ToString()))
        {
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
    }
}
