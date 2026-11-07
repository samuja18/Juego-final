using Unity.VectorGraphics;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class stageSelector : MonoBehaviour
{
    public string sceneName;
    public Button[] botones;

    public Button streetButton;
    public Button trainButton;
    public int seleccionado = 0;

    public void Start()
    {
        streetButton.onClick.AddListener(street);
        trainButton.onClick.AddListener(train);
    }

    private void SaveSceneAs(string scene)
    {
        PlayerPrefs.SetString("SelectedScene", scene);
    }
    void street()
    {
        SaveSceneAs(scene: "Street");
    }
    void train()
    {
        SaveSceneAs(scene: "Train");
    }
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
            SceneManager.LoadScene("characterSelectionCoop");
        }

        void visualActivado()
        {
            botones[seleccionado].Select();
        }

    }
    
}

