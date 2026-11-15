using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    public Slider shieldSlider;
    public Slider easeShieldSlider;

    public float maxShield = 100f;
    public float shield;

    [Header("Regeneracion")]
    public float regenRate = 10f;      // puntos por segundo
    public float regenDelay = 10f;      // segundos sin recibir da�o antes de regenerar
    public float brokenDelay = 4f;     // delay m�s largo si el escudo lleg� a 0

    private float lerpSpeed = 0.05f;
    private float regenTimer;

    public bool escudoRoto;

    void Awake()
    {
        shield = maxShield;
        shieldSlider.maxValue = maxShield;
        easeShieldSlider.maxValue = maxShield;
        shieldSlider.value = shield;
        easeShieldSlider.value = shield;
        
    }
    

       
    
    void Update()
    {

        if (escudoRoto == true)
        {
            regenRate = 30;
        }
        if (escudoRoto == false)
        {
            regenRate = 5;
        }
        Debug.Log(escudoRoto);
        // Regeneraci�n

        if (regenTimer > 0)
        {
            regenTimer -= Time.deltaTime;
        }
    
        if (shield < maxShield)
        {
            shield += regenRate * Time.deltaTime;
            shield = Mathf.Clamp(shield, 0, maxShield);
        }
        // Barra principal
        
        
        if (shieldSlider.value != shield)
        {
            shieldSlider.value = shield;
        }
        
        // Barra de easing: baja suave, pero sube de inmediato al regenerar
        
        if (easeShieldSlider.value < shield)
        {
            easeShieldSlider.value = shield;
        }
        
        else if (easeShieldSlider.value > shield)
        {
            easeShieldSlider.value = Mathf.Lerp(easeShieldSlider.value, shield, lerpSpeed);
        }
        
        if (shield == 0)
        {
            escudoRoto = true;
            Debug.Log("escudo roto" + escudoRoto);
            
        }
        if ((shield == 100) && (escudoRoto == true))
        {
                escudoRoto = false;
        }
    }

        public void TakeShieldDamage(float amount)
    {
        shield = Mathf.Clamp(shield - amount, 0, maxShield);
        regenTimer = (shield <= 0) ? brokenDelay : regenDelay;
    }
    
    public bool HasShield()
    {
        return shield > 0;
    }
    
    public void takeDamage(float damage)
    {
        shield -= damage;
    }
    
    
}