using UnityEngine;
using UnityEngine.UI;

public class Healtbar : MonoBehaviour
{
    public Slider Healthslider;
    public Slider easeHealthSlider;
    public float maxHealth = 100f;
    public float health;
    private float lerpspeed = 0.05f; 
    public GameObject Jugador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(Healthslider.value != health)
        {
            Healthslider.value = health;
        }
        if(Healthslider.value != easeHealthSlider.value)
        {
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, health, lerpspeed);
        }
        if (health == 0)
        {
            if(Jugador.name == "jugador1")
            {
                Debug.Log("El ganador fue jugador 2");
            }
            if(Jugador.name == "jugador2")
            {
                Debug.Log("El ganador fue jugador 1");
            }
            
        }
    }
    public void takeDamage(float damage)
    {
        health -= damage;
    }
}
