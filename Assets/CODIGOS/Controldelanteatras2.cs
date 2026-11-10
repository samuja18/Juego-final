using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections;
using UnityEngine.InputSystem;
using TMPro;

public class Controldelanteatras2 : MonoBehaviour

{
    public float velocidad = 10f;
    public float salto = 80f;
    public Rigidbody rb;
    float y;
    public float x;
    public float rotacion;
    public Animator persoanim;
    public Collider colliderAtras;
    public float textTime = 2f;
    public AudioSource audioSource;
    public AudioClip backgroundMusic;
    public float rotatejugador = -90f;
    public bool puedeMoverse;
    public bool puedoSaltar;
    public bool moviendoseIzquierda;
    public bool moviendoseDerecha;
    public bool estatico;
    public bool agachado;
    public bool AtaqueaAire;
    public ControlAtaque2 controlataque;
    public perso alrevez;
    public Knockback2 aturdido;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        persoanim = GetComponent<Animator>();
    }

    void Start()
    {
        estatico = true;
        moviendoseIzquierda = false;
        moviendoseDerecha = false;
        puedeMoverse = true;
        transform.rotation = Quaternion.Euler(new Vector3(0f, rotatejugador, 0f));
        puedeMoverse = true;
        puedoSaltar = true;
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {

    if(controlataque.atacando == false)
    {
        agachado = Keyboard.current.sKey.isPressed; 
    }
    transform.rotation = Quaternion.Euler(0f, rotatejugador, 0f);    

    if((y < 0) && (alrevez.inputalrevez == false))
    {
        moviendoseDerecha = true;
        moviendoseIzquierda = false;
        estatico = false;
    }
    if((y > 0) && (alrevez.inputalrevez == false))
    {
        moviendoseIzquierda = true;
        moviendoseDerecha = false;
        estatico = false;
    }
    if((y < 0) && (alrevez.inputalrevez == true))
    {
        moviendoseIzquierda = true;
        moviendoseDerecha = false;
        estatico = false;
    }
    if((y > 0) && (alrevez.inputalrevez == true))
    {
        moviendoseDerecha = true;
        moviendoseIzquierda = false;
        estatico = false;
    }


    
    
    if(y == 0)
    {
        estatico = true;
        moviendoseIzquierda = false;
        moviendoseDerecha = false;
    }
    if (puedeMoverse && (aturdido.aturdido == false))
    {
        float velocidadX = y * -velocidad;
        rb.linearVelocity = new Vector3(velocidadX, rb.linearVelocity.y, rb.linearVelocity.z);
    }
    if (Input.GetKeyDown(KeyCode.A) )
        {
            y = -1;
        }    
    if (Input.GetKeyDown(KeyCode.D) )
        {
            y = 1;
        }    
    if (Input.GetKeyUp(KeyCode.A) )
        {
            y = 0;
        }    
    if (Input.GetKeyUp(KeyCode.D) )
        {
            y = 0;
        }    
    
    


    persoanim.SetFloat("VelY", -y, 0.1f, Time.deltaTime);
    persoanim.SetFloat("Velx", x, 0.1f, Time.deltaTime);
    if (Input.GetKeyDown(KeyCode.W) && puedoSaltar && puedeMoverse && (aturdido.aturdido == false))
        {
            
            persoanim.SetTrigger("salto");
            puedoSaltar = false;
            Debug.Log("SALTO");
            rb.AddForce(Vector3.up * salto, ForceMode.Impulse);
            persoanim.SetBool("AIRE", true);
            AtaqueaAire = true;
        }

    if ((agachado) )
        {
            persoanim.SetBool("SiguesAgachado", true);
            Debug.Log("Agachate");
        }
    
    if (Input.GetKeyDown(KeyCode.S) && (controlataque.atacando == false) && (aturdido.aturdido == false))
    {
        puedeMoverse = false;
        persoanim.SetTrigger("agacharse");
    }
    if (Input.GetKeyUp(KeyCode.S))
    {
        puedeMoverse = true;
        persoanim.SetBool("SiguesAgachado", false);
    }
    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("piso"))
        {
            persoanim.SetBool("AIRE", false);
            x = 0;
            Debug.Log("puedes saltar");
            puedoSaltar = true;
            AtaqueaAire = false;
        }
    }
    
    
}
