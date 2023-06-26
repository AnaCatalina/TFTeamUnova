using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayer: MonoBehaviour
{
    public float velMovimiento = 5f;
    public float velRotacion = 200f;
    private Animator anim;
    public float x, y;
    public bool enTierra;
    public Rigidbody rb;
    public float fuerzaSalto;
    public bool puedoSaltar;
    public LayerMask Mask;
    // Start is called before the first frame update
    void Start()
    {
        puedoSaltar = false;
        anim=GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * velRotacion, 0);
        transform.Translate(0,0,y*Time.deltaTime * velMovimiento);

        anim.SetFloat("velX",x);
        anim.SetFloat("velY", y);

        CheckTierra();

        if (Input.GetKeyDown(KeyCode.LeftControl) && enTierra) // condicion para apretar la tecla Ctrl y verificar si estamos en tierra
        {
            anim.Play("jump"); // llamamos a la animacion de salto del Jugador
            Jump(); // llamamos el metodo salto
        }
       
    }
    private void CheckTierra()
    {
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.6f, Mask)) // condicion para analizar la posicion del personaje, su vector de caida, el radio de su sphere colider y el layer con el que colisiona para analizar si saltar o no

        {
            enTierra = true;
        }
        else
        {
            enTierra = false;
        }
    }
    //Metodo que permite saltar
    public void Jump()
    {

        rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
    }

}
