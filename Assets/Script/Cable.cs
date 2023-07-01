using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Cable : MonoBehaviour
{
    //[SerializeField]
    //private GameObject player;
    // Start is called before the first frame update
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
            other.transform.position = new Vector3(63, 0.5f, 89);//Devolver al principio
            other.transform.localRotation = Quaternion.Euler(0, 180, 0);
            //luego
            //Restar vida

        }
    }
}
