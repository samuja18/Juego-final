using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.Build.Content;

public class stageSelector : MonoBehaviour
{
    public string sceneName;
    
    public Button[] botones;
    public int seleccionado = 0;
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


    public void selectedStreet(string Street)
    {
        sceneName = Street;
        Debug.Log("Selected scenario: " + sceneName);
        SceneManager.LoadScene("Street");
    }
    public void selectedTrain (string Train)
    {
        sceneName = Train;
        Debug.Log("Selected scenario: " + sceneName);
        SceneManager.LoadScene("Train");
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}

