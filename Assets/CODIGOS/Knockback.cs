using UnityEngine;
using UnityEngine.Events; 
using System.Collections;   
public class NEWenemigo : MonoBehaviour
{
    public float direccionKnockBack = -1f;
    private float direccionKnockBackVertical = 10f;
    private Rigidbody rb;
    public float DELAYknockback = 2f;
    public float knockBackPARRY = 6f;
    public float KIROknockBackGolpeLigero = 3f;
    public float KIROknockBackGolpePesado = 5f;
    public float KIROknockBackGolpeDelantePesado = 5f;
    public float KIROknockBackGolpeDelanteLigero = 5f;
    public float KIROknockBackGolpeAgachatePesado = 6f;
    public float KIROknockBackGolpeSaltoLigero = 3f;



    public bool controlparry;
    public Animator RETROCESO;
     [SerializeField] private UnityEvent DejaDeParry; 

    public float RECUPERACIONPARRY = 0.7f;
    public float RECUPERACIONGolpeLigero = 0.1f;
    public float RECUPERACIONGolpePesado = 0.5f;
    public float RECUPERACIONGolpeDelantePesado = 0.7f;
    public float RECUPERACIONGolpeDelanteLigero = 0.3f;
    public float RECUPERACIONGolpeAgachatePesado= 0.6f;
    public float RECUPERACIONGolpeSaltoLigero = 0.3f;

    public float RECUPERACIONESCUDOROTO = 3f;

    public bool aturdido;


    public Healtbar vida; 
    public ShieldBar escudo; 
    private bool estadoAnterior;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(gameObject.name == "jugador1")
            {
                direccionKnockBack = -1;
            }
        if(gameObject.name == "jugador2")
            {
                direccionKnockBack = 1;
            }
        aturdido = false;
        controlparry = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(escudo.escudoRoto == true)
        {
        if (aturdido) return; 
        ControlAtaques ControlAtaques = gameObject.GetComponentInParent<ControlAtaques>();
        if (ControlAtaques != null)
        {
            ControlAtaques.AtaqueAturdido();
        }
        RETROCESO.SetBool("ATURDIDO", true);
        //StartCoroutine(RECUPERACIONKNOCKBACKESCUDOROTO(RECUPERACIONESCUDOROTO));
        aturdido = true;
        }
        /*
        if((escudo.escudoRoto == false))
        {
            aturdido = false;
            RETROCESO.SetBool("ATURDIDO", false);
        }
        */
    }
    
    private void OnTriggerEnter(Collider golpeLigero)
    {
        // parry
        
        if((golpeLigero.gameObject.CompareTag("parry")))
        {
        escudo.takeDamage(34);
        if (aturdido) return; 
        ControlAtaques ControlAtaques = golpeLigero.GetComponentInParent<ControlAtaques>();
        if (ControlAtaques != null)
        {
            ControlAtaques.AtaqueAturdido();
            Debug.Log("ya no estas atacando");
        }
        aturdido = true;
        RETROCESO.SetBool("ATURDIDO", true);
        StartCoroutine(RECUPERACIONKNOCKBACKPARRY(RECUPERACIONPARRY));
        }
        // parry

        // ataque ligero
        if((golpeLigero.gameObject.CompareTag("golpe ligero")) && (controlparry == false))
        {
        vida.takeDamage(4);
        if (escudo.escudoRoto == false)
        {
        escudo.takeDamage(8);
        }
        if (aturdido) return; 
        ControlAtaques ControlAtaques = golpeLigero.GetComponentInParent<ControlAtaques>();
        if (ControlAtaques != null)
        {
            ControlAtaques.AtaqueAturdido();
        }
        rb.linearVelocity = Vector2.zero;
        aturdido = true;
        Vector3 impulso = new Vector3(direccionKnockBack,0f, 0f).normalized; 
        rb.AddForce(impulso * KIROknockBackGolpeLigero, ForceMode.Impulse);
        RETROCESO.SetBool("ATURDIDO", true);
        StartCoroutine(RECUPERACIONKNOCKBACKGolpeLigero(RECUPERACIONGolpeLigero));
        }
        // ataque ligero

        // ataque pesado
        if((golpeLigero.gameObject.CompareTag("golpe pesado")) && (controlparry == false))
        {
        vida.takeDamage(7);
        if (escudo.escudoRoto == false)
        {
        escudo.takeDamage(14);
        }
        if (aturdido) return; 
        ControlAtaques ControlAtaques = golpeLigero.GetComponentInParent<ControlAtaques>();
        if (ControlAtaques != null)
        {
            ControlAtaques.AtaqueAturdido();
        }
        rb.linearVelocity = Vector2.zero;
        aturdido = true;
        Vector3 impulso = new Vector3(direccionKnockBack,0f, 0f).normalized; 
        rb.AddForce(impulso * KIROknockBackGolpePesado, ForceMode.Impulse);
        RETROCESO.SetBool("ATURDIDO", true);
        StartCoroutine(RECUPERACIONKNOCKBACKGolpePesado(RECUPERACIONGolpePesado));
        }
        // ataque pesado

        // ataque delante pesado
        if((golpeLigero.gameObject.CompareTag("golpe delante pesado")) && (controlparry == false))
        {
        vida.takeDamage(10);
        if (escudo.escudoRoto == false)
        {
        escudo.takeDamage(20);
        } 
        if (aturdido) return; 
        ControlAtaques ControlAtaques = golpeLigero.GetComponentInParent<ControlAtaques>();
        if (ControlAtaques != null)
        {
            ControlAtaques.AtaqueAturdido();
        }
        rb.linearVelocity = Vector2.zero;
        aturdido = true;
        Vector3 impulso = new Vector3(direccionKnockBack,0f, 0f).normalized; 
        rb.AddForce(impulso * KIROknockBackGolpeDelantePesado, ForceMode.Impulse);
        RETROCESO.SetBool("ATURDIDO", true);
        StartCoroutine(RECUPERACIONKNOCKBACKGolpeDelantePesado(RECUPERACIONGolpeDelantePesado));
        }
        // ataque delante pesado

        // ataque delante ligero
        if((golpeLigero.gameObject.CompareTag("golpe delante ligero")) && (controlparry == false))
        {
        vida.takeDamage(5);
        if (escudo.escudoRoto == false)
        {
        escudo.takeDamage(10);
        }  
        if (aturdido) return; 
        ControlAtaques ControlAtaques = golpeLigero.GetComponentInParent<ControlAtaques>();
        if (ControlAtaques != null)
        {
            ControlAtaques.AtaqueAturdido();
        }
        rb.linearVelocity = Vector2.zero;
        aturdido = true;
        Vector3 impulso = new Vector3(direccionKnockBack,direccionKnockBackVertical, 0f).normalized; 
        rb.AddForce(impulso * KIROknockBackGolpeDelanteLigero, ForceMode.Impulse);
        RETROCESO.SetBool("ATURDIDO", true);
        StartCoroutine(RECUPERACIONKNOCKBACKGolpeDelanteLigero(RECUPERACIONGolpeDelanteLigero));
        }
        // ataque delante ligero

        // ataque agachate pesado
        if((golpeLigero.gameObject.CompareTag("golpe agachate pesado")) && (controlparry == false))
        {
        vida.takeDamage(8);
        if (escudo.escudoRoto == false)
        {
        escudo.takeDamage(16);
        }  
        if (aturdido) return; 
        ControlAtaques ControlAtaques = golpeLigero.GetComponentInParent<ControlAtaques>();
        if (ControlAtaques != null)
        {
            ControlAtaques.AtaqueAturdido();
        }
        rb.linearVelocity = Vector2.zero;
        aturdido = true;
        Vector3 impulso = new Vector3(direccionKnockBack,0f, 0f).normalized; 
        rb.AddForce(impulso * KIROknockBackGolpeAgachatePesado, ForceMode.Impulse);
        RETROCESO.SetBool("ATURDIDO", true);
        StartCoroutine(RECUPERACIONKNOCKBACKGolpeAgachatePesado(RECUPERACIONGolpeAgachatePesado));
        }
        // ataque agachate pesado

        // ataque salto ligero
        if((golpeLigero.gameObject.CompareTag("salto golpe ligero")) && (controlparry == false))
        {
        vida.takeDamage(6);
        if (escudo.escudoRoto == false)
        {
        escudo.takeDamage(12);
        } 
        if (aturdido) return; 
        ControlAtaques ControlAtaques = golpeLigero.GetComponentInParent<ControlAtaques>();
        if (ControlAtaques != null)
        {
            ControlAtaques.AtaqueAturdido();
        }
        rb.linearVelocity = Vector2.zero;
        aturdido = true;
        Vector3 impulso = new Vector3(direccionKnockBack,0f, 0f).normalized; 
        rb.AddForce(impulso * KIROknockBackGolpeSaltoLigero, ForceMode.Impulse);
        RETROCESO.SetBool("ATURDIDO", true);
        StartCoroutine(RECUPERACIONKNOCKBACKGolpeSaltoLigero(RECUPERACIONGolpeSaltoLigero));
        aturdido = true;
        }
        // ataque salto ligero
        
        if(controlparry == true){
            controlparry = false;

        }

        
    
    }


   private IEnumerator DELAYknockBackGolpeDelantePesado(float delay)
    {
        yield return new WaitForSeconds(delay);
        Vector3 impulso = new Vector3(direccionKnockBack,0f, 0f).normalized; 
        rb.AddForce(impulso * KIROknockBackGolpeDelantePesado, ForceMode.Impulse);
        RETROCESO.SetBool("ATURDIDO", true);
        StartCoroutine(RECUPERACIONKNOCKBACKGolpeDelantePesado(RECUPERACIONGolpeDelantePesado));
        
    }

    private IEnumerator DELAYknockBackGolpeDelanteLigero(float delay)
    {
        yield return new WaitForSeconds(delay);
        Vector3 impulso = new Vector3(direccionKnockBack,direccionKnockBackVertical, 0f).normalized; 
        rb.AddForce(impulso * KIROknockBackGolpeDelanteLigero, ForceMode.Impulse);
        RETROCESO.SetBool("ATURDIDO", true);
        StartCoroutine(RECUPERACIONKNOCKBACKGolpeDelanteLigero(RECUPERACIONGolpeDelanteLigero));
    }

    private IEnumerator DELAYknockBackGolpePesado(float delay)
    {
        yield return new WaitForSeconds(delay);
        Vector3 impulso = new Vector3(direccionKnockBack,0f, 0f).normalized; 
        rb.AddForce(impulso * KIROknockBackGolpePesado, ForceMode.Impulse);
        RETROCESO.SetBool("ATURDIDO", true);
        StartCoroutine(RECUPERACIONKNOCKBACKGolpePesado(RECUPERACIONGolpePesado));
    }
    private IEnumerator DELAYknockBackGolpeLigero(float delay)
    {
        yield return new WaitForSeconds(delay);
        Vector3 impulso = new Vector3(direccionKnockBack,0f, 0f).normalized; 
        rb.AddForce(impulso * KIROknockBackGolpeLigero, ForceMode.Impulse);
        RETROCESO.SetBool("ATURDIDO", true);
        StartCoroutine(RECUPERACIONKNOCKBACKGolpeLigero(RECUPERACIONGolpeLigero));
    }
    private IEnumerator DELAYknockBackGolpeAgachatePesado(float delay)
    {
        yield return new WaitForSeconds(delay);
        Vector3 impulso = new Vector3(direccionKnockBack,0f, 0f).normalized; 
        rb.AddForce(impulso * KIROknockBackGolpeAgachatePesado, ForceMode.Impulse);
        RETROCESO.SetBool("ATURDIDO", true);
        StartCoroutine(RECUPERACIONKNOCKBACKGolpeAgachatePesado(RECUPERACIONGolpeAgachatePesado));
    }
    private IEnumerator DELAYknockBackGolpeSaltoLigero(float delay)
    {
        yield return new WaitForSeconds(delay);
        Vector3 impulso = new Vector3(direccionKnockBack,0f, 0f).normalized; 
        rb.AddForce(impulso * KIROknockBackGolpeSaltoLigero, ForceMode.Impulse);
        RETROCESO.SetBool("ATURDIDO", true);
        StartCoroutine(RECUPERACIONKNOCKBACKGolpeSaltoLigero(RECUPERACIONGolpeSaltoLigero));
        
    }

    //PARRY
    private IEnumerator RECUPERACIONKNOCKBACKPARRY(float delay)
    {
        yield return new WaitForSeconds(delay);
        aturdido = false;
        RETROCESO.SetBool("ATURDIDO", false);
    }
    //PARRY
    private IEnumerator RECUPERACIONKNOCKBACKGolpeDelantePesado(float delay)
    {
        yield return new WaitForSeconds(delay);
        aturdido = false;
        RETROCESO.SetBool("ATURDIDO", false);
    }
    private IEnumerator RECUPERACIONKNOCKBACKGolpeDelanteLigero(float delay)
    {
        yield return new WaitForSeconds(delay);
        aturdido = false;
        RETROCESO.SetBool("ATURDIDO", false);
    }
    private IEnumerator RECUPERACIONKNOCKBACKGolpePesado(float delay)
    {
        yield return new WaitForSeconds(delay);
        aturdido = false;
        RETROCESO.SetBool("ATURDIDO", false);
    }
    private IEnumerator RECUPERACIONKNOCKBACKGolpeLigero(float delay)
    {
        yield return new WaitForSeconds(delay);
        aturdido = false;
        RETROCESO.SetBool("ATURDIDO", false);
    }
    private IEnumerator RECUPERACIONKNOCKBACKGolpeAgachatePesado(float delay)
    {
        yield return new WaitForSeconds(delay);
        aturdido = false;
        RETROCESO.SetBool("ATURDIDO", false);
    }
    private IEnumerator RECUPERACIONKNOCKBACKGolpeSaltoLigero(float delay)
    {
        yield return new WaitForSeconds(delay);
        aturdido = false;
        RETROCESO.SetBool("ATURDIDO", false);
    }
    
    private void RECUPERACIONKNOCKBACKESCUDOROTO()
    {
    
        aturdido = false;
        RETROCESO.SetBool("ATURDIDO", false);
    }
    

}
