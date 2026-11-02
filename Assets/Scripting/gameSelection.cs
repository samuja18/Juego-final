using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameSelection : MonoBehaviour
{
    public Button[] botones;
    public int seleccionado = 0;

    // Update is called once per frame
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

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                botones[seleccionado].onClick.Invoke();
            }

            void visualActivado()
            {
                botones[seleccionado].Select();
            }
            
        

    }
    public void Arcade()
    {
        SceneManager.LoadScene("characterSelection");
    }

    public void Coop()
    {
        SceneManager.LoadScene("stageSelection");
    }
    public void pantallaInicio()
    {
        SceneManager.LoadScene("menu");
    }

}
