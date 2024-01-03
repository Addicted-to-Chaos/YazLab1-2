using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTableData : MonoBehaviour
{
    public string p_saat_id;
    public string p_gun_id;
    public string p_derslik_id; 

    TimetableButtons tb;
    private void Awake()
    {
        tb = FindObjectOfType<TimetableButtons>();
        p_derslik_id = tb.p_derslik_id.ToString();
    }
    public async void delMonday1_1()
    {
        p_saat_id = "1";
        p_gun_id = "1";

        if (await MysqlPostManager.dersprogramiSil(p_derslik_id, p_gun_id, p_saat_id))
        {
            print("Silme islemi basarili");
        }
        else
            print("Silme islemi basarisiz");
    }
}
