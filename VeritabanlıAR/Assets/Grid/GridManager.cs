using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    public int width = 10;
    public int height = 10;

    public GameObject cellPrefab; // Bu prefab'ý kullanmayacaðýz.
    public GameObject textPrefab; // Text UI için prefab

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

                // Text UI prefab'ýný instantiate ederek hücreyi oluþtur
                GameObject cell = Instantiate(textPrefab, position, Quaternion.identity, transform);

                // GameObject içerisindeki Text bileþenine eriþerek metni ayarla
                Text cellText = cell.GetComponent<Text>();

                // Örnek bir metin ekleyelim (Hücrenin koordinatlarýný yazdýrýyoruz)
                cellText.text = $"({x}, {y})";

                // Eðer metni stillemek isterseniz, Text bileþeninin özelliklerini kullanabilirsiniz.
                cellText.fontStyle = FontStyle.Bold;
                cellText.fontSize = 20;
                cellText.color = Color.grey;
            }
        }
    }
}