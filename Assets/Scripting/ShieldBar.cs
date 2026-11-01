using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    public Slider shieldSlider;
    public Slider easeShieldSlider;

    public float maxShield = 100f;
    public float shield;

    [Header("Regeneración")]
    public float regenRate = 10f;      // puntos por segundo
    public float regenDelay = 2f;      // segundos sin recibir daño antes de regenerar
    public float brokenDelay = 4f;     // delay más largo si el escudo llegó a 0

    private float lerpSpeed = 0.05f;
    private float regenTimer;

    void Start()
    {
        shield = maxShield;
        shieldSlider.maxValue = maxShield;
        easeShieldSlider.maxValue = maxShield;
        shieldSlider.value = shield;
        easeShieldSlider.value = shield;
    }

    void Update()
    {
        // Regeneración
        if (regenTimer > 0)
        {
            regenTimer -= Time.deltaTime;
        }
        else if (shield < maxShield)
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            takeDamage(10);
        }
    }

    // Lo llama quien haga los ataques cuando el escudo recibe un golpe
    public void TakeShieldDamage(float amount)
    {
        shield = Mathf.Clamp(shield - amount, 0, maxShield);
        regenTimer = (shield <= 0) ? brokenDelay : regenDelay;
    }

    // Útil para tu sistema de parrys: un parry exitoso devuelve escudo
    public void RestoreShield(float amount)
    {
        shield = Mathf.Clamp(shield + amount, 0, maxShield);
    }

    public bool HasShield()
    {
        return shield > 0;
    }
    void takeDamage(float damage)
    {
        shield -= damage;
    }
}