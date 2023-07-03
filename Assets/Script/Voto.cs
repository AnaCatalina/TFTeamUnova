using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Voto : MonoBehaviour
{
    [SerializeField] private GameObject [] voto;
    [SerializeField] private Transform posicion;
   
    // Update is called once per frame
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(voto[0], transform.position,transform.rotation);
       
    }

 
}
