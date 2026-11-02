using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauas : MonoBehaviour
{
    public GameObject menuPausa;
    private bool isPaused = false;
    public Button[] botones;
    public int seleccionado = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))

        {
            if (isPaused == false)
            {
                menuPausa.SetActive(true);
                isPaused = true;
                Time.timeScale = 0f;
                Cursor.visible = true;
                control();
            }

            else if (isPaused == true)
            {
                Resumir();
            }

           void control()
            {
                if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                {
                    seleccionado++;
                    if (seleccionado >= botones.Length) seleccionado = 0;
                    visualActivado();
                }
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                {
                    seleccionado--;
                    if (seleccionado < 0) seleccionado = botones.Length - 1;
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
                
                seleccionado = 0;
                visualActivado();
            }
        }
        
    }

    public void Resumir()
        {
            menuPausa.SetActive(false);
            isPaused = false;
            Time.timeScale = 1f;
            Cursor.visible = false;
        }

    public void Exit()
    {
        isPaused = false;
        Time.timeScale = 1f;
        Cursor.visible = false;
        SceneManager.LoadScene("Menu");
    }
}
