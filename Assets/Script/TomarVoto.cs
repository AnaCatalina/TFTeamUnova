using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TomarVoto : MonoBehaviour
{
    [SerializeField] private GameObject manoPoint;
    

   [SerializeField] private GameObject pickedObject = null; // para saber si tenemos un objeto o no en la mano 
    
    void Update()
    {
        if (pickedObject != null) 
        {

            if (Input.GetKey("r"))
            {
                
               

                pickedObject.GetComponent<Rigidbody>().isKinematic = false;

                pickedObject.gameObject.transform.SetParent(null);

                pickedObject = null;
            }
        }
       
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("MitadVoto1") || other.gameObject.CompareTag("Voto"))  // comparamos el tag del objecto
        {
            if (Input.GetKey("e") && pickedObject ==null)  //al apretar la tecla "E" podemos agarrar el objeto mientras que no tengamos nada en la mano 
             {
                

                other.GetComponent<Rigidbody>().isKinematic = true;

                other.transform.position = manoPoint.transform.position;

                other.gameObject.transform.SetParent(manoPoint.gameObject.transform);

                pickedObject = other.gameObject;
            
            }
        }

    }
   
    
   
}
