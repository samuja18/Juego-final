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
    public float velocidadRotacion = 720f;
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
    [Header("Controles del Jugador")]
    public KeyCode teclaDerecha = KeyCode.Keypad6;
    public KeyCode teclaIzquierda = KeyCode.Keypad4;
    public KeyCode teclaAgacharse = KeyCode.Keypad5;
    public KeyCode teclaSalto = KeyCode.Keypad8;
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

        if (Input.GetKey(teclaDerecha))
        {
            y = -1;
        }    
        else if (Input.GetKey(teclaIzquierda))
        {
            y = 1;
        }    
    if (Input.GetKeyUp(teclaDerecha))
        {
            if (Input.GetKeyDown(teclaIzquierda))
            {
            y = 1;
            }   
            else{
            y = 0;
            }     
        }    
    if (Input.GetKeyUp(teclaIzquierda))
        {
            if (Input.GetKeyDown(teclaDerecha))
            {
            y = -1;
            }  
            else{
            y = 0;
            } 
        }  
    if (puedeMoverse && (aturdido.aturdido == false) && (agachado == false))
    {
        float velocidadX = y * -velocidad;
        rb.linearVelocity = new Vector3(velocidadX, rb.linearVelocity.y, rb.linearVelocity.z);
    }
    Quaternion rotacionDeseada = Quaternion.Euler(0f, rotatejugador, 0f);
    transform.rotation = Quaternion.RotateTowards(
        transform.rotation, 
        rotacionDeseada, 
        velocidadRotacion * Time.deltaTime
    );
    if(AtaqueaAire == false)
    {
    agachado = Keyboard.current.numpad5Key.isPressed; 
    }

        if (Input.GetKeyDown(teclaSalto) && puedoSaltar && puedeMoverse && (aturdido.aturdido == false))
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
 

    
      


    persoanim.SetFloat("VelY", -y, 0.1f, Time.deltaTime);
    persoanim.SetFloat("Velx", x, 0.1f, Time.deltaTime);


    if ((agachado) )
        {
            persoanim.SetBool("SiguesAgachado", true);
            Debug.Log("Agachate");
        }

            

    
    if (Input.GetKeyDown(teclaAgacharse) && (controlataque.atacando == false) && (AtaqueaAire == false))
    {
        puedeMoverse = false;
        persoanim.SetTrigger("agacharse");
    }
    if (Input.GetKeyUp(teclaAgacharse))
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

