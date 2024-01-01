using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tablo : MonoBehaviour
{

    public int rows = 10;
    public int cols = 10;
    private GameObject[,] grid;

    void Start()
    {
        grid = new GameObject[rows, cols];
        CreateGridWithText();
    }

  

    void CreateGridWithText()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                GameObject cell = new GameObject("Cell_" + i + "_" + j);
                cell.transform.position = new Vector3(i, 0, j);

                // Text bileþeni ekleme
                Text textComponent = cell.AddComponent<Text>();
                textComponent.text = "Text_" + i + "_" + j;
                textComponent.font = Resources.GetBuiltinResource<Font>("Arial.ttf");  // Varsayýlan bir font kullanabilirsiniz
                textComponent.fontSize = 20;

                grid[i, j] = cell;
            }
        }
    }
    public Text GetTextAtPosition(int row, int col)
    {
        if (row >= 0 && row < rows && col >= 0 && col < cols)
        {
            GameObject cell = grid[row, col];
            if (cell != null)
            {
                return cell.GetComponent<Text>();
            }
        }
        return null;
    }



}
