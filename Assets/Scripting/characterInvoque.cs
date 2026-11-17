using UnityEngine;
using UnityEngine.SceneManagement;

public class characterInvoque : MonoBehaviour
{
    public GameObject kiro;
    public GameObject pointB;
    public GameObject kakareta;
    public Transform spawnPoint;
    void Start()
    {
        
        string character = PlayerPrefs.GetString(key:"SelectedCharacter");
        SpawnCharacter(character);
    }
    void SpawnCharacter(string character)
    {
        if (character == "Kiro")
        {
            Instantiate(kiro, spawnPoint.position, spawnPoint.rotation);
            Debug.Log("personaje cargado");
        }
        if (character == "PointB")
        {
            Instantiate(pointB, spawnPoint.position, spawnPoint.rotation);
        }
        if (character == "Kakareta")
        {
            Instantiate(kakareta, spawnPoint.position, spawnPoint.rotation);
        }
    }
    
}
