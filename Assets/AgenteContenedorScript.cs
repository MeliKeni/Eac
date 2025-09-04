using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgenteContenedorScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Animator anim;
    [SerializeField] Transform targetTR;
    [SerializeField] Transform target2TR;
    [SerializeField] bool yendo;
    [SerializeField] bool isMinion;


    void Awake()
    {
        agent = GetComponent<NavMeshAgent>(); //me ahorra tener que arrestrar el componente al campo
        anim =  GetComponentInChildren<Animator>(); //tengo q agregqarle el in children porque el animtaor esta en el model, osea el hijo del contenedor
    }

    // Update is called once per frame
    void Update()
    {
        //si el agente llega a un traget va al otro
        if (!agent.pathPending && agent.remainingDistance < .2 ) //si el caminoi no esta definidio te va a tirar error porque no sabe la distancia, no estamos esperando un path
        {
           cambiarDestino();

        }

        anim.SetFloat("Speed", agent.velocity.magnitude); //el magnitude es para convertir un vector a vector
    }

   void cambiarDestino()
    {
        if (yendo)
        {
            agent.destination = target2TR.position;
            yendo = false;
        }
        else
        {
            agent.destination = targetTR.position;
            yendo = true;
        }
    }
}
