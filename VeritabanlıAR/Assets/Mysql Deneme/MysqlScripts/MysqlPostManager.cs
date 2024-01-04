using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using UnityEngine.Networking;

static class MysqlPostManager 
{
    readonly static string server_url = "localhost:80/veritabanlýAR";

    //dersProgramý
    public static async Task<bool> dersprogramiEkle(string p_ders_id, string p_derslik_id, string p_ogretmen_id, string p_gun_id, string p_saat_id)
    {
        string url = $"{server_url}/dersprograminaEkle.php";

        return await sendPostRequest(url, new Dictionary<string, string>()
        {
            {"p_ders_id",p_ders_id},
            {"p_derslik_id",p_derslik_id}, //Post ile belirtilen php dosyasýna gönderilen deðerler
            {"p_ogretmen_id",p_ogretmen_id},
            {"p_gun_id",p_gun_id},
            {"p_saat_id",p_saat_id}
        });
    }
    //
    public static async Task<bool> dersEkle(string ders_adi, string ders_sinif)
    {
        string url = $"{server_url}/dersEkle.php";

        return await sendPostRequest(url, new Dictionary<string, string>()
        {
            {"ders_adi",ders_adi}, //Post ile belirtilen php dosyasýna gönderilen deðerler
            {"ders_sinif",ders_sinif},
        });
    }

    public static async Task<bool> dersOgretmenEkle(string ders_ogretmen_id, string ders_id, string ogretmen_id)
    {
        string url = $"{server_url}/dersOgretmenEkle.php";

        return await sendPostRequest(url, new Dictionary<string, string>()
        {
            {"ders_ogretmen_id",ders_ogretmen_id},
            {"ders_id",ders_id}, //Post ile belirtilen php dosyasýna gönderilen deðerler
            {"ogretmen_id",ogretmen_id},
        });
    }
    public static async Task<bool> ogretmenEkle( string ad)
    {
        string url = $"{server_url}/ogretmenEkle.php";

        return await sendPostRequest(url, new Dictionary<string, string>()
        {
            {"ad",ad}, //Post ile belirtilen php dosyasýna gönderilen deðerler
        });
    }

    static async Task<bool> sendPostRequest(string url, Dictionary<string,string> data)
    {
        using (UnityWebRequest req = UnityWebRequest.Post(url, data))
        {
            req.SendWebRequest();
            
            while(!req.isDone) await Task.Delay(100);

            if (req.error != null||!string.IsNullOrWhiteSpace(req.error)||HasErrorMessage(req.downloadHandler.text))
                return false;
            return true;
        }
    }


    public static async Task<bool> dersprogramiSil(string p_derslik_id, string p_gun_id, string p_saat_id)
    {
        string url = $"{server_url}/dersprogramiSil.php";

        return await sendPostRequest(url, new Dictionary<string, string>()
        {
            {"derslik_id",p_derslik_id}, //Post ile belirtilen php dosyasýna gönderilen deðerler
            {"gun_id",p_gun_id},
            {"saat_id",p_saat_id}
        });
    }
    public static async Task<bool> dersSil(string ders_id)
    {
        string url = $"{server_url}/dersSil.php";

        return await sendPostRequest(url, new Dictionary<string, string>()
        {
            {"ders_id",ders_id} //Post ile belirtilen php dosyasýna gönderilen deðerler
            
        });
    }
    public static async Task<bool> ogretmenSil(string ogretmen_id)
    {
        string url = $"{server_url}/ogretmenSil.php";

        return await sendPostRequest(url, new Dictionary<string, string>()
        {
            {"ogretmen_id",ogretmen_id} //Post ile belirtilen php dosyasýna gönderilen deðerler
            
        });
    }

    static bool HasErrorMessage(string msg) => int.TryParse(msg, out var res);

}

