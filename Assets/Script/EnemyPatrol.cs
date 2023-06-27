using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform[] pointPatrol;
    public float speed = 1.0f;
    private Transform targetPoint;
    public GameObject player;
    public bool persuit = true;
    public float distanceVision;

    public bool readyToPersuit = true;

    private Transform temporal;
    void Start()
    {
        targetPoint = pointPatrol[Random.Range(0,pointPatrol.Length)];
        
        temporal = targetPoint;
        persuit = true;
        distanceVision = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, step);
       
        transform.LookAt(targetPoint.position);
       
        if (transform.position == targetPoint.position) {
            targetPoint = pointPatrol[Random.Range(0,pointPatrol.Length)];         
        }

        var dist = Vector3.Distance(player.transform.position, transform.position);
        
        //Debug.Log("la distancia al enemigo es:" + dist.ToString());
       
        if (dist < distanceVision && readyToPersuit)
        {
            temporal = targetPoint;

            targetPoint = player.transform;
            readyToPersuit = false;
        }

        if (dist >distanceVision && readyToPersuit == false) {
            targetPoint = temporal;
            readyToPersuit = true;
        }
       
    }
}
