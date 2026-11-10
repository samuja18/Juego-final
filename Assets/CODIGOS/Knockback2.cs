using UnityEngine;
using UnityEngine.Events; 
using System.Collections;   

public class Knockback2 : MonoBehaviour
{
    public float direccionKnockBack2 = 1f;
    private float direccionKnockBackVertical = 10f;
    private Rigidbody rb;
    public float DELAYknockback = 0.2f;
    public float KIROknockBackGolpeLigero = 3f;
    public float KIROknockBackGolpePesado = 5f;
    public float KIROknockBackGolpeDelantePesado = 5f;
    public float KIROknockBackGolpeDelanteLigero = 5f;
    public float KIROknockBackGolpeAgachatePesado = 6f;
    public float KIROknockBackGolpeSaltoLigero = 3f;
    public bool controlparry;
    public Animator RETROCESO;
     [SerializeField] private UnityEvent DejaDeParry; 

    public float RECUPERACIONGolpeLigero = 0.1f;
    public float RECUPERACIONGolpePesado = 0.5f;
    public float RECUPERACIONGolpeDelantePesado = 0.7f;
    public float RECUPERACIONGolpeDelanteLigero = 0.3f;
    public float RECUPERACIONGolpeAgachatePesado= 0.6f;
    public float RECUPERACIONGolpeSaltoLigero = 0.3f;
    
    public bool aturdido;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aturdido = false;
        controlparry = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider golpeLigero)
    {
        
        if((golpeLigero.gameObject.CompareTag("golpe ligero")) && (controlparry == false))
        {
        if (aturdido) return; 
        rb.linearVelocity = Vector2.zero;
        aturdido = true;
        Vector3 impulso = new Vector3(direccionKnockBack2,0f, 0f).normalized; 
        rb.AddForce(impulso * KIROknockBackGolpeLigero, ForceMode.Impulse);
        RETROCESO.SetBool("ATURDIDO", true);
        StartCoroutine(RECUPERACIONKNOCKBACKGolpeLigero(RECUPERACIONGolpeLigero));
        }
        if((golpeLigero.gameObject.CompareTag("golpe pesado")) && (controlparry == false))
        {
        if (aturdido) return; 
        rb.linearVelocity = Vector2.zero;
        aturdido = true;
        Vector3 impulso = new Vector3(direccionKnockBack2,0f, 0f).normalized; 
        rb.AddForce(impulso * KIROknockBackGolpePesado, ForceMode.Impulse);
        RETROCESO.SetBool("ATURDIDO", true);
        StartCoroutine(RECUPERACIONKNOCKBACKGolpePesado(RECUPERACIONGolpePesado));
        }
        if((golpeLigero.gameObject.CompareTag("golpe delante pesado")) && (controlparry == false))
        {
        if (aturdido) return; 
        rb.linearVelocity = Vector2.zero;
        aturdido = true;
        Vector3 impulso = new Vector3(direccionKnockBack2,0f, 0f).normalized; 
        rb.AddForce(impulso * KIROknockBackGolpeDelantePesado, ForceMode.Impulse);
        RETROCESO.SetBool("ATURDIDO", true);
        StartCoroutine(RECUPERACIONKNOCKBACKGolpeDelantePesado(RECUPERACIONGolpeDelantePesado));
        }
        if((golpeLigero.gameObject.CompareTag("golpe delante ligero")) && (controlparry == false))
        {
        if (aturdido) return; 
        rb.linearVelocity = Vector2.zero;
        aturdido = true;
        Vector3 impulso = new Vector3(direccionKnockBack2,direccionKnockBackVertical, 0f).normalized; 
        rb.AddForce(impulso * KIROknockBackGolpeDelanteLigero, ForceMode.Impulse);
        RETROCESO.SetBool("ATURDIDO", true);
        StartCoroutine(RECUPERACIONKNOCKBACKGolpeDelanteLigero(RECUPERACIONGolpeDelanteLigero));
        }
        if((golpeLigero.gameObject.CompareTag("golpe agachate pesado")) && (controlparry == false))
        {
        if (aturdido) return; 
        rb.linearVelocity = Vector2.zero;
        aturdido = true;
        Vector3 impulso = new Vector3(direccionKnockBack2,0f, 0f).normalized; 
        rb.AddForce(impulso * KIROknockBackGolpeAgachatePesado, ForceMode.Impulse);
        RETROCESO.SetBool("ATURDIDO", true);
        StartCoroutine(RECUPERACIONKNOCKBACKGolpeAgachatePesado(RECUPERACIONGolpeAgachatePesado));
        }
        if((golpeLigero.gameObject.CompareTag("salto golpe ligero")) && (controlparry == false))
        {
        if (aturdido) return; 
        rb.linearVelocity = Vector2.zero;
        aturdido = true;
        Vector3 impulso = new Vector3(direccionKnockBack2,0f, 0f).normalized; 
        rb.AddForce(impulso * KIROknockBackGolpeSaltoLigero, ForceMode.Impulse);
        RETROCESO.SetBool("ATURDIDO", true);
        StartCoroutine(RECUPERACIONKNOCKBACKGolpeSaltoLigero(RECUPERACIONGolpeSaltoLigero));
        aturdido = true;
        }
        
        if(controlparry == true){
            controlparry = false;

        }
    
    }


    private IEnumerator DELAYknockBackGolpeSaltoLigero(float delay)
    {
        yield return new WaitForSeconds(delay);
        Vector3 impulso = new Vector3(direccionKnockBack2,0f, 0f).normalized; 
        rb.AddForce(impulso * KIROknockBackGolpeSaltoLigero, ForceMode.Impulse);
        RETROCESO.SetBool("ATURDIDO", true);
        StartCoroutine(RECUPERACIONKNOCKBACKGolpeSaltoLigero(RECUPERACIONGolpeSaltoLigero));
        aturdido = true;
    }



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


}
