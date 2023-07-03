using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Zona : MonoBehaviour
{
    [SerializeField] private GameObject mesaV;
    private void Start()
    {
        Instantiate(mesaV);
    }
    public int numeroScena;
    private void OnTriggerEnter(Collider other)
    {
        
        if ( other.tag=="Voto") {
            Debug.Log("colision");
            SceneManager.LoadScene(numeroScena);
        }
    }
}
