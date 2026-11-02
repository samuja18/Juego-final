using UnityEngine;

public class enter : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            // Load the next scene
            UnityEngine.SceneManagement.SceneManager.LoadScene("gameSelection");
        }
    }
}
