using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovAutos : MonoBehaviour
{
    [SerializeField]
    private float velocidad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        velocidad = Random.Range(40, 90);
        transform.Translate(0, 0, velocidad * Time.deltaTime);        
    }
}
