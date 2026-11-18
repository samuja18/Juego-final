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
    public NEWenemigo Knockback;
    public Animator DERROTAAA;
    public bool yaempezo = false;
    private float fixedDeltaTime;
    private float relantizacionDeTiempo = 0.1f;
    public ControlAtaques ControlAtaques;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        this.fixedDeltaTime = Time.fixedDeltaTime;
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
        if ((health < 1) && !yaempezo)
        {
            
            yaempezo = true;
            if((Jugador.name == "jugador1")&& (Time.timeScale == 1.0f))
            {
                
                Knockback.ganaste2.SetActive(true);
                Debug.Log("El ganador fue jugador 2");
                DERROTAAA.SetTrigger("DERROTAAA");
                Time.timeScale = relantizacionDeTiempo;
                ControlAtaques.AtaqueAturdido();
                
            }
            if((Jugador.name == "jugador2")&& (Time.timeScale == 1.0f))
            {
                Knockback.ganaste1.SetActive(true);
                Debug.Log("El ganador fue jugador 1");
                DERROTAAA.SetTrigger("DERROTAAA");
                Time.timeScale = relantizacionDeTiempo;
                ControlAtaques.AtaqueAturdido();
            }

        }
    }
    public void takeDamage(float damage)
    {
        health -= damage;
    }
   
}
