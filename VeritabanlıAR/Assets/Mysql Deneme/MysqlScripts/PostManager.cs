using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PostManager : MonoBehaviour
{
    [Header ("DersProgramiEkle")]
    string p_ders_id;
    string p_derslik_id;
    string p_ogretmen_id;
    string p_gun_id;
    string p_saat_id;

    [Header("DersEkle")]
    string ders_ogretmen_id;
    string ders_id;
    string ogretmen_id;

    [Header("DersOgretmenEkle")]
    string Dders_ogretmen_id;
    string Dders_id;
    string Dogretmen_id;

    [Header("OgretmenEkle")]
    string Oogretmen_id;
    string ad;

    public async void DersProgramiEklendi()
    {
        if (await MysqlPostManager.dersprogramiEkle(p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id))
        {
            print("Ders Programý eklendi");
        }
        else
            print("Eklenemedi");
    }
    public async void DersEkle()
    {
        if (await MysqlPostManager.dersEkle(ders_ogretmen_id, ders_id, ogretmen_id))
        {
            print("Ders Programý eklendi");
        }
        else
            print("Eklenemedi");
    }
    public async void DersOgretmenEkle()
    {
        if (await MysqlPostManager.dersOgretmenEkle(Dders_ogretmen_id, Dders_id, Dogretmen_id))
        {
            print("Ders Programý eklendi");
        }
        else
            print("Eklenemedi");
    }
    public async void OgretmenEkle()
    {
        if (await MysqlPostManager.ogretmenEkle(Oogretmen_id, ad))
        {
            print("Ders Programý eklendi");
        }
        else
            print("Eklenemedi");
    }
}
