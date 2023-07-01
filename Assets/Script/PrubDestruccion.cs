using System.Collections;
using System.Collections.Generic;
using UnityEngine.Scripting;
using UnityEngine;


public class PrubDestruccion : MonoBehaviour
{
     public GameObject Voto3;
    public GameObject Voto2;
     private bool ApareceVoto3 = true;
    
    

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MitadVoto1") )
        { 
            Destroy(gameObject);
            Destroy(other.gameObject);
            Debug.Log("crear voto");
            CrearVoto();
        }
    }
    public void CrearVoto()
    {
        if (ApareceVoto3)
        {
            Instantiate(Voto3, transform.position, transform.rotation);
            ApareceVoto3 = false;

        }

    }
}
