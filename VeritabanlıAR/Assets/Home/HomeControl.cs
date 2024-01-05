using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeControl : MonoBehaviour
{

    
    public void scene1036()
    {
        DeleteLesson.silmeEnabled = false;
        SceneManager.LoadScene("MysqlDeneme");
    }
    public void scene1040()
    {
        DeleteLesson.silmeEnabled = false;
        SceneManager.LoadScene("1040");
    }
    public void scene1041()
    {
        DeleteLesson.silmeEnabled = false;
        SceneManager.LoadScene("1041");
    }
    public void scene1044()
    {
        DeleteLesson.silmeEnabled = false;
        SceneManager.LoadScene("1044");
    }
    public void sceneEkleCikar()
    {
        DeleteLesson.silmeEnabled = false;
        SceneManager.LoadScene("EkleCikar");
    }public void sceneAR()
    {
        DeleteLesson.silmeEnabled = false;
        SceneManager.LoadScene("SampleScene");
    }
    public void MenuBack()
    {
        DeleteLesson.silmeEnabled = false;
        SceneManager.LoadScene("Menu");
    }
}
