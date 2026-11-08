using UnityEngine;
using UnityEngine.SceneManagement;

public class stageInvocator : MonoBehaviour
{
    private string Selected_Scene;

    void Start()
    {
        Selected_Scene = PlayerPrefs.GetString("SelectedScene","");
    }

    // Update is called once per frame
    public void StageSpawner()
    {
        switch (Selected_Scene)
        {
            case "Street":
                SceneManager.LoadScene("Street");
                break;

            case "Train":
                SceneManager.LoadScene("Train");
                break;
        }
    }
}