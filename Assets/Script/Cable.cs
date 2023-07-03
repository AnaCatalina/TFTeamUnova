using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Cable : MonoBehaviour
{
    [SerializeField]
    private int nivel;
    [SerializeField]
    private float posX;
    [SerializeField]
    private float posY;
    [SerializeField] 
    private float posZ;
    // Start is called before the first frame update
    [SerializeField]
    private float angulo;

    private void Start()
    {
        posY = 0.5f;
        switch (nivel)
        {
            case 1:
                posX = -63.5f;
                posZ = 87f;
                angulo = 180f;
                break;
            case 2:
                posX = 110f;
                posZ = 60f;
                angulo = 180f;
                break;
            case 3:
                posX = 195f;
                posZ = -80f;
                angulo = 270f;
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        //MovJugador jugador = GameObject.Find("Dog_D_Casual_A").GetComponent<MovJugador>();
        if (other.gameObject.CompareTag("Jugador"))
        {
            
            //other.transform.position = new Vector3(63, 0.5f, 89);
            other.transform.position = new Vector3(posX, posY , posZ);//Devuelve al personaje al principio
            other.transform.localRotation = Quaternion.Euler(0, angulo, 0);

        }
    }
}
