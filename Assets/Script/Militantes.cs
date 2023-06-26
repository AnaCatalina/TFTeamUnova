using UnityEngine;
using UnityEngine.AI;

public class Militantes : MonoBehaviour

{
    [SerializeField]
    private GameObject jugador;
    [SerializeField]
    private float distancia;
    [SerializeField]
    private float distanciaPala;
    [SerializeField]
    private Transform objectivo;
    private NavMeshAgent agente;
    //private float speed;
    [SerializeField]
    private float velRotacion;
    [SerializeField]
    private string estado;
    [SerializeField]
    private float radioDeteccion;
    [SerializeField]
    private float radioPersecusion;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        estado = "normal";
        velRotacion = 10;
        agente = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Pala pala = GameObject.Find("Clean_shovel_Prefab").GetComponent<Pala>();
        distancia = Vector3.Distance(jugador.transform.position, transform.position);
        distanciaPala = Vector3.Distance(pala.transform.position, transform.position);
        if ((distanciaPala < pala.Radio) && (pala.Funcionando))
        {
            radioDeteccion = 4;
            radioPersecusion = 2;
        }
        if ((distanciaPala > pala.Radio) || (!pala.Funcionando))
        {
            radioDeteccion = 10;
            radioPersecusion = 8;
        }

        if (distancia > radioDeteccion)
        {
            estado = "normal";

        }
        if (distancia < radioDeteccion && distancia > radioPersecusion)
        {

            estado = "mirar";
        }
        if (distancia < radioPersecusion)
        {

            estado = "perseguir";
        }
        switch (estado)
        {
            case "normal":
                anim.SetBool("Perseguir", false);
                print(estado);
                break;
            case "mirar":
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(jugador.transform.position - transform.position), velRotacion * Time.deltaTime);

                print(estado);
                break;
            case "perseguir":
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(jugador.transform.position - transform.position), velRotacion * Time.deltaTime);
                agente.destination = objectivo.position;
                anim.SetBool("Perseguir", true);
                print(estado);
                break;
        }
    }

}
