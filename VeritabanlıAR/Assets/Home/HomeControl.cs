using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeControl : MonoBehaviour
{
   
    
    public void scene1036()
    {
        SceneManager.LoadScene("MysqlDeneme");
    }
    public void scene1040()
    {
        SceneManager.LoadScene("1040");
    }
    public void scene1041()
    {
        SceneManager.LoadScene("1041");
    }
    public void scene1044()
    {
        SceneManager.LoadScene("1044");
    }
    public void sceneEkleCikar()
    {
        SceneManager.LoadScene("EkleCikar");
    }
    public void MenuBack()
    {
        SceneManager.LoadScene("Menu");
    }
}
