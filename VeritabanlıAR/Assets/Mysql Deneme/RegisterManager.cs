using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RegisterManager : MonoBehaviour
{
    [SerializeField] TMP_InputField reg_email;
    [SerializeField] TMP_InputField reg_username;
    [SerializeField] TMP_InputField reg_password;

    public async void OnRegisterPressed()
    {
        if (string.IsNullOrWhiteSpace(reg_email.text))
        {
            Debug.Log("Gecerli bir eposta gir");
            return;
        }
        if (string.IsNullOrWhiteSpace(reg_username.text))
        {
            Debug.Log("Gecerli bir kullanici adi gir");
            return;
        }
        if (string.IsNullOrWhiteSpace(reg_password.text))
        {
            Debug.Log("Gecerli bir sifre gir");
            return;
        }

        if (await MysqlManager.registerUser(reg_email.text, reg_username.text, reg_password.text))
        {
            print("basariyla kayit olundu");
        }
        else
            print("kayit basarisiz");
    }
}
