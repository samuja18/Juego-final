using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections;
using UnityEngine.InputSystem;
using TMPro;

public class controladelanteatras : MonoBehaviour
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
    public float rotatejugador = 90f;
    public bool puedeMoverse;
    public bool puedoSaltar;
    public bool moviendoseIzquierda;
    public bool moviendoseDerecha;
    public bool estatico;
    public bool agachado;
    public bool AtaqueaAire;
    public ControlAtaques controlataque;
    public personajeatras alrevez;
    public NEWenemigo aturdido;
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
    
    void Update()
    {
    transform.rotation = Quaternion.Euler(0f, rotatejugador, 0f);  
    agachado = Keyboard.current.numpad5Key.isPressed; 
    
        if (Input.GetKeyDown(KeyCode.Keypad8) && puedoSaltar && puedeMoverse && (aturdido.aturdido == false))
        {
            
            persoanim.SetTrigger("salto");
            puedoSaltar = false;
            Debug.Log("SALTO");
            rb.AddForce(Vector3.up * salto, ForceMode.Impulse);
            persoanim.SetBool("AIRE", true);
            AtaqueaAire = true;
        }
    if((y < 0) && (alrevez.inputalrevez == false))
    {
        moviendoseIzquierda = false;
        moviendoseDerecha = true;  
        estatico = false;  
    }
    if((y > 0) && (alrevez.inputalrevez == false))
    {
        moviendoseDerecha = false;    
        moviendoseIzquierda = true;
        estatico = false;
    }
    if((y < 0) && (alrevez.inputalrevez == true))
    {
        moviendoseDerecha = false;    
        moviendoseIzquierda = true;
        estatico = false;
    }
    if((y > 0) && (alrevez.inputalrevez == true))
    {
        moviendoseIzquierda = false;
        moviendoseDerecha = true;  
        estatico = false;  
    }
    if(y == 0)
    {
        estatico = true;
        moviendoseIzquierda = false;
        moviendoseDerecha = false;
    }
    if (puedeMoverse && (aturdido.aturdido == false) && (agachado == false))
    {
        float velocidadX = y * -velocidad;
        rb.linearVelocity = new Vector3(velocidadX, rb.linearVelocity.y, rb.linearVelocity.z);
    }

    
      

    if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            y = -1;
        }    
    if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            y = 1;
        }    
    if (Input.GetKeyUp(KeyCode.Keypad6))
        {
            y = 0;
        }    
    if (Input.GetKeyUp(KeyCode.Keypad4))
        {
            y = 0;
        }    
    persoanim.SetFloat("VelY", -y, 0.1f, Time.deltaTime);
    persoanim.SetFloat("Velx", x, 0.1f, Time.deltaTime);


    if ((agachado) )
        {
            persoanim.SetBool("SiguesAgachado", true);
            Debug.Log("Agachate");
        }

            

    
    if (Input.GetKeyDown(KeyCode.Keypad5) && (controlataque.atacando == false))
    {
        puedeMoverse = false;
        persoanim.SetTrigger("agacharse");
    }
    if (Input.GetKeyUp(KeyCode.Keypad5))
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

