using UnityEngine;

public class characterInvoque : MonoBehaviour
{
    public GameObject kiro;
    public GameObject pointB;
    public GameObject kakareta;
    void Start()
    {
        string character = PlayerPrefs.GetString(key:"SelectedCharacter");
        SpawnCharacter(character);
    }
    void SpawnCharacter(string character)
    {
        if (character == "Kiro")
        {
            Instantiate(kiro);
        }
        if (character == "PointB")
        {
            Instantiate(pointB);
        }
        if (character == "Kakareta")
        {
            Instantiate(kakareta);
        }
    }
}
