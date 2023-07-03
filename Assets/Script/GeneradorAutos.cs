using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorAutos : MonoBehaviour
{
    [SerializeField]
    private Transform posicion;
    //Le asignamos los objeto que generará
    [SerializeField]
    private GameObject[] autos;
    //Tiempo en que sale la primera plataforma
    [SerializeField]
    private float tiempoInicial;
    //Intervalo en que sale la siguiente plataforma
    [SerializeField]
    private int intervalo;
    [SerializeField]
    private int vehiculo;

    void Start()
    {
        tiempoInicial = Random.Range(0, 2);
        //InvokeRepeating que llama al metodo GenerarPlataforma
        //InvokeRepeating("GenerarPlataforma", tiempoInicial, intervalo);
        Invoke("GenerarPlataforma", tiempoInicial);
    }
    //Metodo que genera las plataformas
    public void GenerarPlataforma()
    {
        vehiculo = Random.Range(0, autos.Length);
        intervalo = Random.Range(2, 4);
        Instantiate(autos[vehiculo], transform.position, transform.rotation);
        Invoke("GenerarPlataforma", intervalo);
    }
}
