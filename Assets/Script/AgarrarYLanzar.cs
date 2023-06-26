using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarrarYLanzar : MonoBehaviour
{
    [SerializeField] private GameObject manoPunto;

    private GameObject pickedObject = null; // para saber si tenemos un objeto o no en la mano 

    void Update()
    {
        Pala pala = GameObject.Find("Clean_shovel_Prefab").GetComponent<Pala>();
        if (pickedObject != null)
        {

            if (Input.GetKey("r"))
            {
                pala.Funcionando = true;

                Destroy(pickedObject, 5);

                pickedObject.GetComponent<Rigidbody>().useGravity = true;

                pickedObject.GetComponent<Rigidbody>().isKinematic = false;

                pickedObject.gameObject.transform.SetParent(null);

                pickedObject = null;

                
            }
        }


    }
    private void OnTriggerStay(Collider otro)
    {
        Pala pala = GameObject.Find("Clean_shovel_Prefab").GetComponent<Pala>();
        {
            if (Input.GetKey("e") && pickedObject == null)  //al apretar la tecla "E" podemos agarrar el objeto mientras que no tengamos nada en la mano 
            {
                pala.GetComponent<Rigidbody>().useGravity = false;

                pala.GetComponent<Rigidbody>().isKinematic = true;

                pala.transform.position = manoPunto.transform.position;

                pala.gameObject.transform.SetParent(manoPunto.gameObject.transform);

                pala.Funcionando = false;

                pickedObject = otro.gameObject;

            }
        }
    }


}
