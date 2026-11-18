using UnityEngine;
using UnityEngine.Events; 
using System.Collections;   
public class NEWenemigo : MonoBehaviour
{
    public float direccionKnockBack = -1f;
    private float direccionKnockBackVertical = 10f;
    private Rigidbody rb;
    public float DELAYknockback = 0.2f;
    public float knockBackPARRY = 0.3f;
    public float KIROknockBackGolpeLigero = 0.1f;
    public float KIROknockBackGolpePesado = 0.2f;
    public float KIROknockBackGolpeDelantePesado = 0.2f;
    public float KIROknockBackGolpeDelanteLigero = 0.2f;
    public float KIROknockBackGolpeAgachatePesado = 0.3f;
    public float KIROknockBackGolpeSaltoLigero = 0.1f;



    public bool controlparry;
    public Animator RETROCESO;
     [SerializeField] private UnityEvent DejaDeParry; 

    public float RECUPERACIONPARRY = 0.7f;
    public float RECUPERACIONGolpeLigero = 0.05f;
    public float RECUPERACIONGolpePesado = 0.25f;
    public float RECUPERACIONGolpeDelantePesado = 0.35f;
    public float RECUPERACIONGolpeDelanteLigero = 0.15f;
    public float RECUPERACIONGolpeAgachatePesado= 0.3f;
    public float RECUPERACIONGolpeSaltoLigero = 0.15f;

    public float RECUPERACIONESCUDOROTO = 3f;
    public bool aturdido;



    public int danoParry = 34;
    public int danoGolpeLigero = 8;
    public int danoGolpePesado = 16;
    public int danoGolpeDelantePesado = 20;
    public int danoGolpeDelanteLigero = 12;
    public int danoGolpeAgachatePesado= 20;
    public int daanoGolpeSaltoLigero = 12;


    public Healtbar vida; 
    public ShieldBar escudo; 
    public ParryCharges parry; 
    public GameObject ganaste1;
    public GameObject ganaste2;
    public GameObject jugador;
    public static float golpesRecibido;
    private float relantizacionDeTiempo = 0.2f;



    public GameObject AURA;
    public bool AtaqueCargado = false;
    public KeyCode CARGADO;
    private float fixedDeltaTime;
    public AudioSource audioSource;
    public AudioClip golpeSONIDO;
    public AudioClip parrySONIDO;
    public AudioClip cancionFONDO;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource.clip = cancionFONDO;
        audioSource.Play();
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        danoGolpeLigero = 4;
        danoGolpePesado = 12;
        danoGolpeDelantePesado = 18;
        danoGolpeDelanteLigero = 8;
        danoGolpeAgachatePesado= 16;
        daanoGolpeSaltoLigero = 8;
        AtaqueCargado = false;
        AURA.SetActive(false);
        ganaste1.SetActive(false);
        ganaste2.SetActive(false);
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
        vida.gameObject.SetActive(false);
        escudo.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(parry.currentCharges >  0)
        {
            AtaqueCargado = Input.GetKey(CARGADO);
            if(AtaqueCargado == false)
                {
            danoGolpeLigero = 4;
            danoGolpePesado = 12;
            danoGolpeDelantePesado = 18;
            danoGolpeDelanteLigero = 8;
            danoGolpeAgachatePesado= 16;
            daanoGolpeSaltoLigero = 8;
            AURA.SetActive(false);
                }
            if(AtaqueCargado == true)
                {
            danoGolpeLigero =  40;
            danoGolpePesado = 40;
            danoGolpeDelantePesado = 40;
            danoGolpeDelanteLigero = 40;
            danoGolpeAgachatePesado= 40;
            daanoGolpeSaltoLigero = 40;
            Debug.Log("tu dano es de" + danoGolpeLigero);
            AURA.SetActive(true);
                }

        }
        if(parry.currentCharges == 0)
                {
            AtaqueCargado = false;
            danoGolpeLigero = 4;
            AURA.SetActive(false);
                }
        if(golpesRecibido == 1)
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
            parry.currentCharges = 3;
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
        if((golpeLigero.gameObject.CompareTag("parry") && (AtaqueCargado == false)))
        {
        audioSource.clip = parrySONIDO;
        audioSource.Play();
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
        audioSource.clip = golpeSONIDO;
        audioSource.Play();
        NEWenemigo atacante = golpeLigero.GetComponentInParent<NEWenemigo>();
        float danoFinal = (atacante != null) ? atacante.danoGolpeLigero : danoGolpeLigero;

        if (((golpesRecibido == 0) && (Time.timeScale == 1.0f)))
        {
            danoFinal = danoFinal * 5 ;
            Time.timeScale = relantizacionDeTiempo;
        }
        Debug.Log("=== IMPACTO DETECTADO ===");
        Debug.Log("Objeto que golpeó (hitbox): " + golpeLigero.gameObject.name + " | Raíz: " + golpeLigero.transform.root.name);
        Debug.Log("Atacante encontrado: " + (atacante != null ? atacante.gameObject.name : "NINGUNO (NULL)"));
        Debug.Log("Daño del atacante: " + (atacante != null ? atacante.danoGolpeLigero.ToString() : "N/A"));
        Debug.Log("Daño local (defensor): " + danoGolpeLigero);
        vida.takeDamage(danoFinal / 2);
        if (escudo.escudoRoto == false)
        {
        escudo.takeDamage(danoFinal);
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
        rb.AddForce(impulso * KIROknockBackGolpeLigero / 3, ForceMode.VelocityChange);
        RETROCESO.SetBool("ATURDIDO", true);
        StartCoroutine(RECUPERACIONKNOCKBACKGolpeLigero(RECUPERACIONGolpeLigero / 2));
        golpesRecibido += 1;
        }
        // ataque ligero

        // ataque pesado
        if((golpeLigero.gameObject.CompareTag("golpe pesado")) && (controlparry == false))
        {
        audioSource.clip = golpeSONIDO;
        audioSource.Play();
        NEWenemigo atacante = golpeLigero.GetComponentInParent<NEWenemigo>();
        float danoFinal = (atacante != null) ? atacante.danoGolpePesado : danoGolpePesado;
        if ((golpesRecibido == 0) && (Time.timeScale == 1.0f))
        {
            danoFinal = danoFinal * 5;
            Time.timeScale = relantizacionDeTiempo;
        }
        vida.takeDamage(danoFinal / 2);
        if (escudo.escudoRoto == false)
        {
        escudo.takeDamage(danoFinal);
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
        rb.AddForce(impulso * KIROknockBackGolpePesado / 3, ForceMode.VelocityChange);
        RETROCESO.SetBool("ATURDIDO", true);
        StartCoroutine(RECUPERACIONKNOCKBACKGolpePesado(RECUPERACIONGolpePesado / 2));
        golpesRecibido += 1;
        }
        // ataque pesado

        // ataque delante pesado
        if((golpeLigero.gameObject.CompareTag("golpe delante pesado")) && (controlparry == false))
        {
        audioSource.clip = golpeSONIDO;
        audioSource.Play();
        NEWenemigo atacante = golpeLigero.GetComponentInParent<NEWenemigo>();
        float danoFinal = (atacante != null) ? atacante.danoGolpeDelantePesado : danoGolpeDelantePesado;
        if ((golpesRecibido == 0) && (Time.timeScale == 1.0f))
        {
            danoFinal = danoFinal * 3;
            Time.timeScale = relantizacionDeTiempo;
        }
        vida.takeDamage(danoFinal / 2);
        if (escudo.escudoRoto == false)
        {
        escudo.takeDamage(danoFinal);
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
        rb.AddForce(impulso * KIROknockBackGolpeDelantePesado / 3, ForceMode.VelocityChange);
        RETROCESO.SetBool("ATURDIDO", true);
        StartCoroutine(RECUPERACIONKNOCKBACKGolpeDelantePesado(RECUPERACIONGolpeDelantePesado / 2));
        golpesRecibido += 1;
        }
        // ataque delante pesado

        // ataque delante ligero
        if((golpeLigero.gameObject.CompareTag("golpe delante ligero")) && (controlparry == false))
        {
        audioSource.clip = golpeSONIDO;
        audioSource.Play();
        NEWenemigo atacante = golpeLigero.GetComponentInParent<NEWenemigo>();
        float danoFinal = (atacante != null) ? atacante.danoGolpeDelanteLigero : danoGolpeDelanteLigero;
        if ((golpesRecibido == 0) && (Time.timeScale == 1.0f))
        {
            danoFinal = danoFinal * 3;
            Time.timeScale = relantizacionDeTiempo;
        }
        vida.takeDamage(danoFinal / 2);
        if (escudo.escudoRoto == false)
        {
        escudo.takeDamage(danoFinal);
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
        rb.AddForce(impulso * KIROknockBackGolpeDelanteLigero / 3, ForceMode.VelocityChange);
        RETROCESO.SetBool("ATURDIDO", true);
        StartCoroutine(RECUPERACIONKNOCKBACKGolpeDelanteLigero(RECUPERACIONGolpeDelanteLigero / 2));
        golpesRecibido += 1;
        }
        // ataque delante ligero

        // ataque agachate pesado
        if((golpeLigero.gameObject.CompareTag("golpe agachate pesado")) && (controlparry == false))
        {
        audioSource.clip = golpeSONIDO;
        audioSource.Play();
        NEWenemigo atacante = golpeLigero.GetComponentInParent<NEWenemigo>();
        float danoFinal = (atacante != null) ? atacante.danoGolpeAgachatePesado : danoGolpeAgachatePesado;
        if ((golpesRecibido == 0) && (Time.timeScale == 1.0f))
        {
            danoFinal = danoFinal * 3;
            Time.timeScale = relantizacionDeTiempo;
        }
        vida.takeDamage(danoFinal / 2);
        if (escudo.escudoRoto == false)
        {
        escudo.takeDamage(danoFinal);
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
        rb.AddForce(impulso * KIROknockBackGolpeAgachatePesado / 3, ForceMode.VelocityChange);
        RETROCESO.SetBool("ATURDIDO", true);
        StartCoroutine(RECUPERACIONKNOCKBACKGolpeAgachatePesado(RECUPERACIONGolpeAgachatePesado / 2));
        golpesRecibido += 1;
        }
        // ataque agachate pesado

        // ataque salto ligero
        if((golpeLigero.gameObject.CompareTag("salto golpe ligero")) && (controlparry == false))
        {
        audioSource.clip = golpeSONIDO;
        audioSource.Play();
        NEWenemigo atacante = golpeLigero.GetComponentInParent<NEWenemigo>();
        float danoFinal = (atacante != null) ? atacante.daanoGolpeSaltoLigero : daanoGolpeSaltoLigero;
        if ((golpesRecibido == 0) && (Time.timeScale == 1.0f))
        {
            danoFinal = danoFinal * 3;
            Time.timeScale = relantizacionDeTiempo;
        }
        vida.takeDamage(danoFinal / 2);
        if (escudo.escudoRoto == false)
        {
        escudo.takeDamage(danoFinal);
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
        rb.AddForce(impulso * KIROknockBackGolpeSaltoLigero / 3, ForceMode.VelocityChange);
        RETROCESO.SetBool("ATURDIDO", true);
        StartCoroutine(RECUPERACIONKNOCKBACKGolpeSaltoLigero(RECUPERACIONGolpeSaltoLigero / 2));
        aturdido = true;
        golpesRecibido += 1;
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
        StartCoroutine(RECUPERACIONKNOCKBACKGolpeDelanteLigero(RECUPERACIONGolpeDelanteLigero ));
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
        parry.currentCharges = 3;
    }
    
    public void FINAL()
        {
        Debug.Log("termino");
        vida.gameObject.SetActive(false);
        escudo.gameObject.SetActive(false);
        }
    
    
}
