using UnityEngine;
using UnityEngine.UI;

public class ParryCharges : MonoBehaviour
{
    [Header("Iconos de carga (en orden)")]
    public Image[] chargeIcons;   // arrastra aquí Charge1, Charge2, Charge3

    [Header("Configuración")]
    public int maxCharges = 3;
    public int currentCharges;

    [Header("Colores")]
    public Color fullColor = Color.white;
    public Color emptyColor = new Color(1f, 1f, 1f, 0.15f);

    void Start()
    {
        currentCharges = maxCharges;
        UpdateUI();
    }

    // Gasta una carga. Devuelve true si se pudo hacer el parry
    public bool UseCharge()
    {
        if (currentCharges <= 0) return false;

        currentCharges--;
        UpdateUI();
        return true;
    }

    // Recupera una carga
    public void RestoreCharge()
    {
        if (currentCharges >= maxCharges) return;

        currentCharges++;
        UpdateUI();
    }

    public bool HasCharges()
    {
        return currentCharges > 0;
    }

    void UpdateUI()
    {
        for (int i = 0; i < chargeIcons.Length; i++)
        {
            chargeIcons[i].color = (i < currentCharges) ? fullColor : emptyColor;
        }
    }
}