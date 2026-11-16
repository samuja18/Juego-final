using JetBrains.Annotations;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class characterSelector : MonoBehaviour
{
    //variables
    
    public Button[] botones;
    public Button kiroBoton;
    public Button pointBBoton;
    public Button kakaretaBoton;
    public int seleccionado = 0;
    private void Start()
    {
        kiroBoton.onClick.AddListener(kiro);
        pointBBoton.onClick.AddListener(pointB);
        kakaretaBoton.onClick.AddListener(kakareta);
        
    }
    //guardar personajes
    private void SavePlayerAs(string character)
    {
        PlayerPrefs.SetString("SelectedCharacter", character);
    }
    void kiro()
    {
        SavePlayerAs(character: "Kiro");
    }

    void pointB()
    {
        SavePlayerAs(character: "PointB");
    }

    void kakareta()
    {
        SavePlayerAs(character: "Kakareta");
    }
    //seleccionar escenario
    //movimiento del menú
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            seleccionado++;
            if (seleccionado >= botones.Length) seleccionado = 0;
            visualActivado();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            seleccionado--;
            if (seleccionado < 0) seleccionado = botones.Length - 1;
            visualActivado();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            seleccionado -= 3;
            if (seleccionado < 0) seleccionado = botones.Length - 1;
            visualActivado();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            seleccionado += 3;
            if (seleccionado >= botones.Length) seleccionado = 0;
            visualActivado();
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            botones[seleccionado].onClick.Invoke();

        }

        void visualActivado()
        {
            botones[seleccionado].Select();
        }
    } 
    
}
