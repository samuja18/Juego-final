using UnityEngine;
using UnityEngine.Events;

public class personajeatras : MonoBehaviour


{
    public NEWenemigo voltearknockback;
    public ControlAtaques novoltear;
    public controladelanteatras voltearpersonaje;
    public float rotacion;
    public float rotacionknockback;
    public bool inputalrevez;
    public GameObject Jugador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (voltearpersonaje != null)
    {
        rotacion = voltearpersonaje.rotatejugador;
    }
        if (voltearknockback != null)
    {
        rotacionknockback = voltearknockback.direccionKnockBack;
    }
    if(Jugador.name == "jugador1")
    {
        inputalrevez = false;
    }
    if(Jugador.name == "jugador2")
    {
        inputalrevez = true;
    }
    
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
        rotacionknockback = voltearknockback.direccionKnockBack;
    }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("jugador2") && (novoltear.atacando == false))
        {
            Debug.Log("VOLTEATE PERSOnAJE 1");
            voltearpersonaje.rotatejugador = -rotacion;
            inputalrevez = !inputalrevez;
        }
        if (other.gameObject.CompareTag("jugador2") && (novoltear.atacando == false))
        {
            voltearknockback.direccionKnockBack = -rotacionknockback;
        }
        if (other.gameObject.CompareTag("jugador1") && (novoltear.atacando == false))
        {
            Debug.Log("VOLTEATE PERSOnAJE 1");
            voltearpersonaje.rotatejugador = -rotacion;
            inputalrevez = !inputalrevez;
        }
        if (other.gameObject.CompareTag("jugador1") && (novoltear.atacando == false))
        {
            voltearknockback.direccionKnockBack = -rotacionknockback;
        }
    }

}
