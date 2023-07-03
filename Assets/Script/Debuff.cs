using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuff : MonoBehaviour
{
    [SerializeField]
    private float cronometro;
    private bool activo;
    private float velRotacion;
    // Start is called before the first frame update
    void Start()
    {
        cronometro = 5;
        velRotacion = 100f;
        activo = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * velRotacion);
        if (activo)
        {
            CronomertroDebuff();
        }        
    }

    private void OnCollisionEnter(Collision collision)
    {
        MovJugador jugador = GameObject.Find("Dog_C_Casual_E").GetComponent<MovJugador>();
        if (collision.gameObject.CompareTag("Jugador"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 10, transform.position.z);
            jugador.VelMovimiento = 2f;
            activo =true;
        }
    }

    public void CronomertroDebuff()
    {
        MovJugador jugador = GameObject.Find("Dog_C_Casual_E").GetComponent<MovJugador>();
        cronometro -= 1 * Time.deltaTime;
        if (cronometro <= 0)
        {
            jugador.VelMovimiento = 5f;
            Destroy(gameObject);
        }
    }

}
