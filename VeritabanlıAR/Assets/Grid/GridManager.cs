using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    public int width = 10;
    public int height = 10;

    public GameObject cellPrefab; // Bu prefab'� kullanmayaca��z.
    public GameObject textPrefab; // Text UI i�in prefab

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector2 position = new Vector2(x, y);

                // Text UI prefab'�n� instantiate ederek h�creyi olu�tur
                GameObject cell = Instantiate(textPrefab, position, Quaternion.identity, transform);

                // GameObject i�erisindeki Text bile�enine eri�erek metni ayarla
                Text cellText = cell.GetComponent<Text>();

                // �rnek bir metin ekleyelim (H�crenin koordinatlar�n� yazd�r�yoruz)
                cellText.text = $"({x}, {y})";

                // E�er metni stillemek isterseniz, Text bile�eninin �zelliklerini kullanabilirsiniz.
                cellText.fontStyle = FontStyle.Bold;
                cellText.fontSize = 20;
                cellText.color = Color.grey;
            }
        }
    }
}