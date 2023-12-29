using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using UnityEngine.Networking;

static class MysqlManager 
{
    readonly static string server_url = "localhost:80/veritabanlıAR";
    public static async Task<bool> registerUser(string email, string username, string password)
    {
        string register_user_url = $"{server_url}/userRegister.php";

        return await sendPostRequest(register_user_url, new Dictionary<string, string>()
        {
            {"email",email},
            {"username",username}, //Post ile belirtilen php dosyasına gönderilen değerler
            {"password",password}
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

    static bool HasErrorMessage(string msg) => int.TryParse(msg, out var res);

}
public class DatabaseUser
{
    public string email;
    public string username;
    public string password;
}
