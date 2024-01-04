using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EkleCikarManager : MonoBehaviour
{
    DropdownDatas dd;
    [SerializeField]string p_ders_id;
    private void Start()
    {
        dd= FindObjectOfType<DropdownDatas>();
        p_ders_id = dd.SeciliDers();
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
}
