using UnityEngine;

public class CharacterInvoqueP2 : MonoBehaviour
{
    public GameObject kiroP2;
    public GameObject pointBP2;
    public GameObject kakaretaP2;
    public Transform spawnPoint;
    void Start()
    {

        string character = PlayerPrefs.GetString(key: "SelectedCharacterP2");
        SpawnCharacter(character);
    }
    void SpawnCharacter(string character)
    {
        if (character == "Kiro")
        {
            Instantiate(kiroP2, spawnPoint.position, spawnPoint.rotation);
            Debug.Log("personaje cargado");
        }
        if (character == "PointB")
        {
            Instantiate(pointBP2, spawnPoint.position, spawnPoint.rotation);
        }
        if (character == "Kakareta")
        {
            Instantiate(kakaretaP2, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
