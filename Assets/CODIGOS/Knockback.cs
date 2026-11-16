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



    private int danoParry = 34;
    private int danoGolpeLigero = 4;
    private int danoGolpePesado = 12;
    private int danoGolpeDelantePesado = 18;
    private int danoGolpeDelanteLigero = 8;
    private int danoGolpeAgachatePesado= 16;
    private int daanoGolpeSaltoLigero = 8;


    public Healtbar vida; 
    public ShieldBar escudo; 
    public ParryCharges parry; 

    public static float golpesRecibido;

    private float relantizacionDeTiempo = 0.2f;


    private float fixedDeltaTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.fixedDeltaTime = Time.fixedDeltaTime;

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
        golpesRecibido = 0;
        if(golpesRecibido == 0)
        {
            //parry.currentCharges = 0;
            vida.gameObject.SetActive(false);
            escudo.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("dano golpe ligero" + danoGolpeLigero);
        Debug.Log("golpes recibidos" + golpesRecibido);
        if(golpesRecibido > 0)
        {
            danoGolpeLigero = 4;
            danoGolpePesado = 12;
            danoGolpeDelantePesado = 18;
            danoGolpeDelanteLigero = 8;
            danoGolpeAgachatePesado= 16;
            daanoGolpeSaltoLigero = 8;
            golpesRecibido = golpesRecibido;
            escudo.gameObject.SetActive(true);
            vida.gameObject.SetActive(true);
            parry.currentCharges = parry.maxCharges;
            parry.UpdateUI();
        }

        if(escudo.escudoRoto == true)
        {
        if (aturdido) return; 
        ControlAtaques ControlAtaques = gameObject.GetComponentInParent<ControlAtaques>();
        ControlAtaques.AtaqueAturdido();
        
        RETROCESO.SetBool("ATURDIDO", true);
        //StartCoroutine(RECUPERACIONKNOCKBACKESCUDOROTO(RECUPERACIONESCUDOROTO));
        aturdido = true;
        }
        
        if((escudo.escudoRoto == false) && escudo.shield == 100)
        {
        aturdido = false;
        RETROCESO.SetBool("ATURDIDO", false);
        }
        
    }
    
    private void OnTriggerEnter(Collider golpeLigero)
    {
        // parry
        Debug.Log("ill fuck your butt in smash bros" + golpeLigero.gameObject.name);
        if((golpeLigero.gameObject.CompareTag("parry")))
        {
        ControlAtaques ControlAtaques = GetComponentInParent<ControlAtaques>();
        if (ControlAtaques != null)
        {
            ControlAtaques.AtaqueAturdido();
        }
        escudo.takeDamage(danoParry);
        if (aturdido) return; 
        aturdido = true;
        RETROCESO.SetBool("ATURDIDO", true);
        
        StartCoroutine(RECUPERACIONKNOCKBACKPARRY(RECUPERACIONPARRY));
        }
        // parry

        // ataque ligero
        if((golpeLigero.gameObject.CompareTag("golpe ligero")) && (controlparry == false))
        {
        if ((golpesRecibido == 0) && (Time.timeScale == 1.0f))
        {
            danoGolpeLigero = danoGolpeLigero * 3;
            Time.timeScale = relantizacionDeTiempo;
        }
        vida.takeDamage(danoGolpeLigero / 4);
        if (escudo.escudoRoto == false)
        {
        escudo.takeDamage(danoGolpeLigero);
        }
        if (aturdido) return; 
        ControlAtaques ControlAtaques = GetComponentInParent<ControlAtaques>();
        if (ControlAtaques != null)
        {
            ControlAtaques.FinalAtaqueBasico();
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
        if ((golpesRecibido == 0) && (Time.timeScale == 1.0f))
        {
            danoGolpePesado = danoGolpePesado * 3;
            Time.timeScale = relantizacionDeTiempo;
        }
        vida.takeDamage(danoGolpePesado / 4);
        if (escudo.escudoRoto == false)
        {
        escudo.takeDamage(danoGolpePesado);
        }
        if (aturdido) return; 
        ControlAtaques ControlAtaques = GetComponentInParent<ControlAtaques>();
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
        if ((golpesRecibido == 0) && (Time.timeScale == 1.0f))
        {
            danoGolpeDelantePesado = danoGolpeDelantePesado * 3;
            Time.timeScale = relantizacionDeTiempo;
        }
        vida.takeDamage(danoGolpeDelantePesado / 4);
        if (escudo.escudoRoto == false)
        {
        escudo.takeDamage(danoGolpeDelantePesado);
        } 
        if (aturdido) return; 
        ControlAtaques ControlAtaques = GetComponentInParent<ControlAtaques>();
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
        if ((golpesRecibido == 0) && (Time.timeScale == 1.0f))
        {
            danoGolpeDelanteLigero = danoGolpeDelanteLigero * 3;
            Time.timeScale = relantizacionDeTiempo;
        }
        vida.takeDamage(danoGolpeDelanteLigero / 4);
        if (escudo.escudoRoto == false)
        {
        escudo.takeDamage(danoGolpeDelanteLigero);
        }  
        if (aturdido) return; 
        ControlAtaques ControlAtaques = GetComponentInParent<ControlAtaques>();
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
        if ((golpesRecibido == 0) && (Time.timeScale == 1.0f))
        {
            danoGolpeAgachatePesado = danoGolpeAgachatePesado * 3;
            Time.timeScale = relantizacionDeTiempo;
        }
        vida.takeDamage(danoGolpeAgachatePesado / 4);
        if (escudo.escudoRoto == false)
        {
        escudo.takeDamage(danoGolpeAgachatePesado);
        }  
        if (aturdido) return; 
        ControlAtaques ControlAtaques = GetComponentInParent<ControlAtaques>();
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
        if ((golpesRecibido == 0) && (Time.timeScale == 1.0f))
        {
            daanoGolpeSaltoLigero = daanoGolpeSaltoLigero * 3;
            Time.timeScale = relantizacionDeTiempo;
        }
        vida.takeDamage(daanoGolpeSaltoLigero / 4);
        if (escudo.escudoRoto == false)
        {
        escudo.takeDamage(daanoGolpeSaltoLigero);
        } 
        if (aturdido) return; 
        ControlAtaques ControlAtaques = GetComponentInParent<ControlAtaques>();
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
        REAPARECEINTERFAZ();
        if((Time.timeScale == relantizacionDeTiempo))
        {
            Debug.Log("descpngela tiempo");
            Time.timeScale = 1.0f; 
        }
        aturdido = false;
        RETROCESO.SetBool("ATURDIDO", false);
        
    }
    private IEnumerator RECUPERACIONKNOCKBACKGolpeDelanteLigero(float delay)
    {
        yield return new WaitForSeconds(delay);
        REAPARECEINTERFAZ();
        if((Time.timeScale == relantizacionDeTiempo))
        {
            Debug.Log("descpngela tiempo");
            Time.timeScale = 1.0f; 
        }
        aturdido = false;
        RETROCESO.SetBool("ATURDIDO", false);
    }
    private IEnumerator RECUPERACIONKNOCKBACKGolpePesado(float delay)
    {
        yield return new WaitForSeconds(delay);
        REAPARECEINTERFAZ();
        if((Time.timeScale == relantizacionDeTiempo))
        {
            Debug.Log("descpngela tiempo");
            Time.timeScale = 1.0f; 
        }
        aturdido = false;
        RETROCESO.SetBool("ATURDIDO", false);
    }
    private IEnumerator RECUPERACIONKNOCKBACKGolpeLigero(float delay)
    {
        yield return new WaitForSeconds(delay);
        REAPARECEINTERFAZ();
        if((Time.timeScale == relantizacionDeTiempo))
        {
            Debug.Log("descpngela tiempo");
            Time.timeScale = 1.0f; 
        }
        aturdido = false;
        RETROCESO.SetBool("ATURDIDO", false);
    }
    private IEnumerator RECUPERACIONKNOCKBACKGolpeAgachatePesado(float delay)
    {
        yield return new WaitForSeconds(delay);
        REAPARECEINTERFAZ();
        if((Time.timeScale == relantizacionDeTiempo))
        {
            Debug.Log("descpngela tiempo");
            Time.timeScale = 1.0f; 
        }
        aturdido = false;
        RETROCESO.SetBool("ATURDIDO", false);
    }
    private IEnumerator RECUPERACIONKNOCKBACKGolpeSaltoLigero(float delay)
    {
        yield return new WaitForSeconds(delay);
        REAPARECEINTERFAZ();
        if((Time.timeScale == relantizacionDeTiempo))
        {
            Debug.Log("descpngela tiempo");
            Time.timeScale = 1.0f; 
        }
        aturdido = false;
        RETROCESO.SetBool("ATURDIDO", false);
    }
    
    private void RECUPERACIONKNOCKBACKESCUDOROTO()
    {
    
        aturdido = false;
        RETROCESO.SetBool("ATURDIDO", false);
    }
    
    private void REAPARECEINTERFAZ()
    {
        golpesRecibido += 1;
        golpesRecibido = golpesRecibido;
        escudo.gameObject.SetActive(true);
        vida.gameObject.SetActive(true);
    }

}
