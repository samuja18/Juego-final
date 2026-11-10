using UnityEngine;

public class ControlAtaque2 : MonoBehaviour
{
    public bool atacando;
    public Rigidbody rbataque;
    public Controldelanteatras2 controlarmovimiento2;
    public Animator aataquesanim;
    public Collider parrycollider;
    public MeshRenderer parrycollidervisble;
    public Collider ataquebasico;
    public Collider ataquepesado;
    public MeshRenderer ataqueVisible;
    public MeshRenderer ataquepesadoVisible;
    public Collider ataqueAdelantepesado;
    public MeshRenderer ataqueAdelantepesadoVisible;
    public Collider ataqueAgachatepesado;
    public MeshRenderer ataqueAagachatepesadoVisible;
    public Collider ataqueDelanteLigero;
    public MeshRenderer ataqueDelanteLigeroVisible;
    public Collider ataqueSaltoLigero;
    public MeshRenderer ataqueSaltoLigeroVisible;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        atacando = false;
        aataquesanim = GetComponent<Animator>();
        parrycollider.enabled = false;
        parrycollidervisble.enabled = false;
        ataqueVisible.enabled = false;
        ataquebasico.enabled = false;
        ataquepesadoVisible.enabled = false;
        ataquepesado.enabled = false;
        ataqueAdelantepesadoVisible.enabled = false;
        ataqueAdelantepesado.enabled = false;
        ataqueAagachatepesadoVisible.enabled = false;
        ataqueAgachatepesado.enabled = false;
        ataqueDelanteLigeroVisible.enabled = false;
        ataqueDelanteLigero.enabled = false;
        ataqueSaltoLigeroVisible.enabled = false;
        ataqueSaltoLigero.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            aataquesanim.SetTrigger("parry");
        }

    
        if (Input.GetKeyDown(KeyCode.G) && (controlarmovimiento2.AtaqueaAire == false) && (controlarmovimiento2.estatico) && (controlarmovimiento2.agachado == false))
        {
            atacando = true;
            Debug.Log("ATAQUESITO SIMPLESITO");
            controlarmovimiento2.puedeMoverse = false;
            aataquesanim.SetTrigger("Golpe 1");
        }
        if (Input.GetKeyDown(KeyCode.G)  && (controlarmovimiento2.AtaqueaAire) && (controlarmovimiento2.agachado == false))
        {
            atacando = true;
            Debug.Log("ataque SALTO");
            controlarmovimiento2.puedeMoverse = false;
            aataquesanim.SetTrigger("salto golpe ligero");
        }
        if ((Input.GetKeyDown(KeyCode.G)) && (controlarmovimiento2.AtaqueaAire == false) && (controlarmovimiento2.moviendoseIzquierda) && (controlarmovimiento2.agachado == false))
        {
            atacando = true;
            Debug.Log("ataque adelante ligero");
            controlarmovimiento2.puedeMoverse = false;
            aataquesanim.SetTrigger("Adelante golpe ligero");   
        }

        if (Input.GetKeyDown(KeyCode.H) && (controlarmovimiento2.AtaqueaAire == false) && (controlarmovimiento2.estatico) && (controlarmovimiento2.agachado == false))
        {
            atacando = true;
            controlarmovimiento2.puedeMoverse = false;
            aataquesanim.SetTrigger("Golpe pesado 1");   
        }
        if ((Input.GetKeyDown(KeyCode.H)) && (controlarmovimiento2.AtaqueaAire == false) && (controlarmovimiento2.moviendoseIzquierda) && (controlarmovimiento2.agachado == false) )
        {
            atacando = true;
            controlarmovimiento2.puedeMoverse = false;
            aataquesanim.SetTrigger("Adelante golpe pesado");   
        }
        if ((Input.GetKeyDown(KeyCode.H)) && (controlarmovimiento2.AtaqueaAire == false) && (controlarmovimiento2.agachado == true))
        {
            atacando = true;
            controlarmovimiento2.puedeMoverse = false;
            aataquesanim.SetTrigger("Agachate golpe pesado");   
        }
        
    }
    void InicioAtaqueBasico()
    {
        
        ataqueVisible.enabled = true;
        ataquebasico.enabled = true;
    }

    void FinalAtaqueBasico()
    {
        atacando = false;
        controlarmovimiento2.puedeMoverse = true;
        ataqueVisible.enabled = false;
        ataquebasico.enabled = false;
    }

    void InicioAtaquePesado()
    {
        
        ataquepesadoVisible.enabled = true;
        ataquepesado.enabled = true;
    }

    void FinalAtaquePesado()
    {
        atacando = false;
        controlarmovimiento2.puedeMoverse = true;
        ataquepesadoVisible.enabled = false;
        ataquepesado.enabled = false;
    }

    void InicioAtaqueDelantePesado()
    {
        
        ataqueAdelantepesadoVisible.enabled = true;
        ataqueAdelantepesado.enabled = true;
    }

    void FinalAtaqueDelantePesado()
    {
        atacando = false;
        controlarmovimiento2.puedeMoverse = true;
        ataqueAdelantepesadoVisible.enabled = false;
        ataqueAdelantepesado.enabled = false;
    }

    void InicioAtaqueAgachatePesado()
    {
        
        ataqueAagachatepesadoVisible.enabled = true;
        ataqueAgachatepesado.enabled = true;
    }

    void FinalAtaqueAgachatePesado()
    {
        atacando = false;
        controlarmovimiento2.puedeMoverse = true;
        ataqueAagachatepesadoVisible.enabled = false;
        ataqueAgachatepesado.enabled = false;
    }

    void InicioAtaqueAdelanteLigero()
    {
        
        ataqueDelanteLigeroVisible.enabled = true;
        ataqueDelanteLigero.enabled = true;
    }

    void FinalAtaqueAdelanteLigero()
    {
        atacando = false;
        controlarmovimiento2.puedeMoverse = true;
        ataqueDelanteLigeroVisible.enabled = false;
        ataqueDelanteLigero.enabled = false;
    }

    void InicioAtaqueSaltoLigero()
    {
        
        ataqueSaltoLigeroVisible.enabled = true;
        ataqueSaltoLigero.enabled = true;
    }

    void FinalAtaqueSaltoLigero()
    {
        atacando = false;
        controlarmovimiento2.puedeMoverse = true;
        ataqueSaltoLigeroVisible.enabled = false;
        ataqueSaltoLigero.enabled = false;
    }

    
    void InicioDelParry()
    {
        parrycollider.enabled = true;
        parrycollidervisble.enabled = true;
    }

    void FinalDelParry()
    {
        
        Debug.Log("TERMINA PARRY");
        parrycollider.enabled = false;
        parrycollidervisble.enabled = false;
    }
}
