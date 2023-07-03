using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Cable : MonoBehaviour
{
    [SerializeField]
    private float posX;
    [SerializeField]
    private float posY;
    [SerializeField] 
    private float posZ;
    // Start is called before the first frame update
    [SerializeField]
    private float angle;

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //PlayerBHVR player = GameObject.Find("Dog_D_Casual_A").GetComponent<PlayerBHVR>();

        if (other.gameObject.CompareTag("Jugador"))
        {
            //other.transform.position = new Vector3(63, 0.5f, 89);
            other.transform.position = new Vector3(posX, posY, posZ);//Devuelve al personaje al principio
            other.transform.localRotation = Quaternion.Euler(0, angle, 0);

        }
    }
}
