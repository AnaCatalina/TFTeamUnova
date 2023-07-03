using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Militantes : MonoBehaviour

{
    [SerializeField]
    private GameObject jugador;
    private GameObject palaActiva;
    [SerializeField]
    private float distancia;
    [SerializeField]
    private float distanciaPala;
    [SerializeField]
    private Transform objetivo;
    [SerializeField]
    private float velRotacion;
    [SerializeField]
    private string estado;
    [SerializeField]
    private float radioDeteccion;
    [SerializeField]
    private float radioPala;
    [SerializeField]
    private float radioAtaque;
    [SerializeField]
    private int nivel;
    [SerializeField]
    private NavMeshAgent agente;
    private Animator anim;
    private int rutina;
    private float cronometro;
    private Quaternion angulo;
    private float grados;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        radioPala = 10;
        estado = "normal";
        velRotacion = 10;
        agente = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        palaActiva = GameObject.FindWithTag("Pala");
        distancia = Vector3.Distance(jugador.transform.position, transform.position);
        if (palaActiva != null)
        {
            Pala pala = GameObject.Find("Clean_shovel_Prefab").GetComponent<Pala>();
            distanciaPala = Vector3.Distance(pala.transform.position, transform.position);
            if ((distanciaPala < radioPala) && (pala.Funcionando))
            {
                radioDeteccion = 6;
                radioAtaque = 5;
            }
            if ((distanciaPala > radioPala) || (!pala.Funcionando))
            {
                radioDeteccion = 16;
                radioAtaque = 14;
            }
        }

        if (palaActiva == null)
        {
            radioDeteccion = 16;
            radioAtaque = 14;
        }


        if (distancia > radioDeteccion)
        {
            estado = "normal";

        }
        if (distancia < radioDeteccion && distancia > radioAtaque)
        {

            estado = "alert";
        }
        if (distancia < radioAtaque)
        {

            estado = "attack";
        }
        switch (estado)
        {
            case "normal":
                anim.SetBool("Perseguir", false);
                EnemyChronometer();
                print(estado);
                break;
            case "alert":

                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(jugador.transform.position - transform.position), velRotacion * Time.deltaTime);
                anim.SetBool("Caminar", false);
                agente.speed = 0;
                print(estado);
                break;
            case "attack":
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(jugador.transform.position - transform.position), velRotacion * Time.deltaTime);
                switch (nivel)
                {
                    case 1:
                        agente.speed = 5f;
                        break;
                    case 2:
                        agente.speed = 7f;
                        break;
                    case 3:
                        agente.speed = 9f;
                        break;
                }
                
                agente.acceleration = 10f;
                agente.destination = objetivo.position;
                anim.SetBool("Perseguir", true);
                print(estado);
                break;
        }
    }

    public void EnemyChronometer()
    {
        cronometro += 1 * Time.deltaTime;
        if (cronometro >= 4)
        {
            rutina = Random.Range(0, 2);
            cronometro = 0;
        }
        switch (rutina)
        {
            case 0:
                anim.SetBool("Caminar", false);
                break;
            case 1:
                grados = Random.Range(0, 360);
                angulo = Quaternion.Euler(0, grados, 0);
                rutina++;
                break;
            case 2:
                transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                transform.Translate(Vector3.forward * 1 * Time.deltaTime);

                anim.SetBool("Caminar", true);
                break;
        }
    }
}
