using UnityEngine;

public class perso : MonoBehaviour
{
    public Controldelanteatras2 voltearpersonaje;
    public ControlAtaque2 novoltear;
    public Knockback2 voltearknockback;
    public float rotacion;
    public float rotacionknockback;
    public bool inputalrevez;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    if (voltearpersonaje != null)
    {
        rotacion = voltearpersonaje.rotatejugador;
    }
    
    if (voltearknockback != null)
    {
        rotacionknockback = voltearknockback.direccionKnockBack2;
    }
    inputalrevez = false;
    
    }

    // Update is called once per frame
    void Update()
    {
        if (voltearpersonaje != null)
    {
        rotacion = voltearpersonaje.rotatejugador;
    }
    
    if (voltearknockback != null)
    {
        rotacionknockback = voltearknockback.direccionKnockBack2;
    }

    }
    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("jugador1") && (novoltear.atacando == false))
        {
            voltearknockback.direccionKnockBack2 = -rotacionknockback;
            inputalrevez = !inputalrevez;
        }
        if (other.gameObject.CompareTag("jugador1") && (novoltear.atacando == false))
        {
            voltearpersonaje.rotatejugador = -rotacion;
        }
    }
}
