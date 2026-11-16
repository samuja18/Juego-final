using UnityEngine;

public class ControlAtaques : MonoBehaviour

{
    public bool atacando;
    public Rigidbody rbataque;
    public controladelanteatras controlarmovimiento;
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
    [Header("Controles Ataques")]
    public KeyCode parry = KeyCode.C;
    public KeyCode ataqueLigero = KeyCode.Z;
    public KeyCode ataquePesado = KeyCode.X;
    public ParryCharges parryCargas;

    void Start()
    {

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
    void Update()
    {

        if (Input.GetKeyDown(parry) && (controlarmovimiento.estatico) && (controlarmovimiento.agachado == false) && (parryCargas.currentCharges > 0))
        {
            parryCargas.UseCharge();
            aataquesanim.SetTrigger("parry");
        }

        if (Input.GetKeyDown(ataqueLigero) && (controlarmovimiento.AtaqueaAire == false) && (controlarmovimiento.estatico) && (controlarmovimiento.agachado == false))
        {
            atacando = true;
            controlarmovimiento.puedeMoverse = false;
            aataquesanim.SetTrigger("Golpe 1");
        }
        if (Input.GetKeyDown(ataqueLigero)  && (controlarmovimiento.AtaqueaAire) && (controlarmovimiento.agachado == false))
        {
            atacando = true;
            Debug.Log("ataque SALTO");
            controlarmovimiento.puedeMoverse = false;
            aataquesanim.SetTrigger("salto golpe ligero");
        }
        if ((Input.GetKeyDown(ataqueLigero)) && (controlarmovimiento.AtaqueaAire == false) && (controlarmovimiento.moviendoseDerecha) && (controlarmovimiento.agachado == false))
        {
            atacando = true;
            Debug.Log("ataque adelante ligero");
            controlarmovimiento.puedeMoverse = false;
            aataquesanim.SetTrigger("Adelante golpe ligero");   
        }

        if (Input.GetKeyDown(ataquePesado) && (controlarmovimiento.AtaqueaAire == false) && (controlarmovimiento.estatico) && (controlarmovimiento.agachado == false))
        {
            atacando = true;
            controlarmovimiento.puedeMoverse = false;
            aataquesanim.SetTrigger("Golpe pesado 1");   
        }
        if ((Input.GetKeyDown(ataquePesado)) && (controlarmovimiento.AtaqueaAire == false) && (controlarmovimiento.moviendoseDerecha) && (controlarmovimiento.agachado == false) )
        {
            atacando = true;
            controlarmovimiento.puedeMoverse = false;
            aataquesanim.SetTrigger("Adelante golpe pesado");   
        }
        if ((Input.GetKeyDown(ataquePesado)) && (controlarmovimiento.AtaqueaAire == false) && (controlarmovimiento.agachado) && (controlarmovimiento.agachado == true))
        {
            atacando = true;
            controlarmovimiento.puedeMoverse = false;
            aataquesanim.SetTrigger("Agachate golpe pesado");   
        }
        

    }

    void InicioAtaqueBasico()
    {
        
        ataqueVisible.enabled = true;
        ataquebasico.enabled = true;
    }

    public void FinalAtaqueBasico()
    {
        Debug.Log("JUEGPUTADSADASDASDDDDD");
        atacando = false;
        controlarmovimiento.puedeMoverse = true;
        ataqueVisible.enabled = false;
        ataquebasico.enabled = false;
    }

    void InicioAtaquePesado()
    {
        
        ataquepesadoVisible.enabled = true;
        ataquepesado.enabled = true;
    }

    public void FinalAtaquePesado()
    {
        atacando = false;
        controlarmovimiento.puedeMoverse = true;
        ataquepesadoVisible.enabled = false;
        ataquepesado.enabled = false;
    }

    void InicioAtaqueDelantePesado()
    {
        
        ataqueAdelantepesadoVisible.enabled = true;
        ataqueAdelantepesado.enabled = true;
    }

    public void FinalAtaqueDelantePesado()
    {
        atacando = false;
        controlarmovimiento.puedeMoverse = true;
        ataqueAdelantepesadoVisible.enabled = false;
        ataqueAdelantepesado.enabled = false;
    }

    void InicioAtaqueAgachatePesado()
    {
        
        ataqueAagachatepesadoVisible.enabled = true;
        ataqueAgachatepesado.enabled = true;
    }

    public void FinalAtaqueAgachatePesado()
    {
        atacando = false;
        controlarmovimiento.puedeMoverse = true;
        ataqueAagachatepesadoVisible.enabled = false;
        ataqueAgachatepesado.enabled = false;
    }

    void InicioAtaqueAdelanteLigero()
    {
        
        ataqueDelanteLigeroVisible.enabled = true;
        ataqueDelanteLigero.enabled = true;
    }

    public void FinalAtaqueAdelanteLigero()
    {
        atacando = false;
        controlarmovimiento.puedeMoverse = true;
        ataqueDelanteLigeroVisible.enabled = false;
        ataqueDelanteLigero.enabled = false;
    }

    void InicioAtaqueSaltoLigero()
    {
        
        ataqueSaltoLigeroVisible.enabled = true;
        ataqueSaltoLigero.enabled = true;
    }

    public void FinalAtaqueSaltoLigero()
    {
        atacando = false;
        controlarmovimiento.puedeMoverse = true;
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
        atacando = false;
        Debug.Log("TERMINA PARRY");
        parrycollider.enabled = false;
        parrycollidervisble.enabled = false;
    }

    public void AtaqueAturdido()
    {
        Debug.Log("SACATE LAS WEASSSSSS");
        FinalAtaqueBasico();
        FinalAtaquePesado();
        FinalAtaqueDelantePesado();
        FinalDelParry();
        FinalAtaqueSaltoLigero();
        FinalAtaqueAdelanteLigero();
        FinalAtaqueAgachatePesado();
    }
    
}
