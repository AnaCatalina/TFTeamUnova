using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Zona : MonoBehaviour
{
    [SerializeField] private Transform posicion;
    [SerializeField] private GameObject mesaV;
     [SerializeField] private int numeroScena;
    private void Start()
    {
        Instantiate(mesaV, transform.position, transform.rotation);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        
        if ( other.tag=="Voto") {
            Debug.Log("colision");
            SceneManager.LoadScene(numeroScena);
        }
    }
}
