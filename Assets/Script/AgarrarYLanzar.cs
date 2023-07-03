using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgarrarYLanzar : MonoBehaviour
{
    [SerializeField]
    private GameObject manoPoint;
    private GameObject objetoAgarrado = null; // para saber si tenemos un objeto o no en la mano 
    //[SerializeField]
    //private float chronometer = 0;
    private void Start()
    {

    }

    void Update()
    {

        Pala pala = GameObject.Find("Clean_shovel_Prefab").GetComponent<Pala>();
        if (objetoAgarrado != null)
        {

            if (Input.GetKey("r"))
            {
                objetoAgarrado.GetComponent<Rigidbody>().AddForce(pala.transform.forward * pala.ThrowForce);

                pala.Funcionando = true;

                //Destroy(objetoAgarrado, 5);

                objetoAgarrado.gameObject.transform.SetParent(null);

                objetoAgarrado.GetComponent<Rigidbody>().isKinematic = false;

                objetoAgarrado.GetComponent<Rigidbody>().AddForce(transform.forward * pala.ThrowForce, ForceMode.Impulse);

                objetoAgarrado = null;
            }
        }


    }
    private void OnTriggerStay(Collider other)
    {
        Pala pala = GameObject.Find("Clean_shovel_Prefab").GetComponent<Pala>();
        if (other.gameObject.CompareTag("Pala"))  // comparamos el tag del objecto
        {
            if (Input.GetKey("e") && objetoAgarrado == null)  //al apretar la tecla "E" podemos agarrar el objeto mientras que no tengamos nada en la mano 
            {

                other.gameObject.transform.SetParent(manoPoint.gameObject.transform);

                other.transform.position = manoPoint.transform.position;

                other.transform.rotation = manoPoint.transform.rotation;
                other.GetComponent<Rigidbody>().useGravity = true;

                other.GetComponent<Rigidbody>().isKinematic = true;

                pala.EstaRotando = false;

                pala.Funcionando = false;

                objetoAgarrado = other.gameObject;

            }
        }
    }

}
