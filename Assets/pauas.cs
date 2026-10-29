using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class pauas : MonoBehaviour
{
    public GameObject menuPausa;
    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { if (isPaused == false)
            { menuPausa.SetActive(true);
            isPaused = true;
            Time.timeScale = 0f;
            Cursor.visible = true;
            }

            else if (isPaused == true)
            {
                Resumir();
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
}
