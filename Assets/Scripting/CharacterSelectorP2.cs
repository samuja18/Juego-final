using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectorP2 : MonoBehaviour
{
    public Button[] botonesP2;
    public Button kiroBotonP2;
    public Button pointBBotonP2;
    public Button kakaretaBotonP2;

    public int seleccionadoP2 = 0;

    private void Start()
    {
        kiroBotonP2.onClick.AddListener(kiroP2);
        pointBBotonP2.onClick.AddListener(pointBP2);
        kakaretaBotonP2.onClick.AddListener(kakaretaP2);
    }

    private void SaveCharacterAs(string character)
    {
        PlayerPrefs.SetString("SelectedCharacterP2", character);

        Debug.Log("Jugador 2 seleccionó: " + character);
    }

    void kiroP2()
    {
        SaveCharacterAs("Kiro");
    }

    void pointBP2()
    {
        SaveCharacterAs("PointB");
    }

    void kakaretaP2()
    {
        SaveCharacterAs("Kakareta");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            seleccionadoP2++;

            if (seleccionadoP2 >= botonesP2.Length)
                seleccionadoP2 = 0;

            visualActivadoP2();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            seleccionadoP2--;

            if (seleccionadoP2 < 0)
                seleccionadoP2 = botonesP2.Length - 1;

            visualActivadoP2();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            botonesP2[seleccionadoP2].onClick.Invoke();
        }
    }

    void visualActivadoP2()
    {
        botonesP2[seleccionadoP2].Select();
    }
}
