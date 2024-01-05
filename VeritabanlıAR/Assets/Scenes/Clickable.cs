using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clickable : MonoBehaviour
{
    [SerializeField] bool bin36 = false;
    [SerializeField] bool bin40 = false;
    [SerializeField] bool bin41 = false;
    [SerializeField] bool bin44 = false;
    private void OnMouseUpAsButton()
    {
        if (bin36)
        {
            SceneManager.LoadScene("MysqlDeneme");
        }
        else if (bin40)
        {
            SceneManager.LoadScene("1040");
        }
        else if(bin41)
        {
            SceneManager.LoadScene("1041");
        }
        else if (bin44)
        {
            SceneManager.LoadScene("1044");
        }
        Debug.Log("aaa");
    }
}
