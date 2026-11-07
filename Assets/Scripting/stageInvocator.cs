using UnityEngine;
using UnityEngine.SceneManagement;

public class stageInvocator : MonoBehaviour
{
    
    void Start()
    {
        string scene = PlayerPrefs.GetString(key: "SelectedScene");
    }

    // Update is called once per frame
    public void StageSpawner(string scene)
    {
        if (scene == "Street")
        {
            SceneManager.LoadScene("Street");
        }
        if (scene == "Train")
        {
            SceneManager.LoadScene("Train");
            Debug.Log("escena cargada:");
        }
    }
}
