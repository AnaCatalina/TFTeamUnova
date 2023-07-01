using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pala : MonoBehaviour
{
    [SerializeField]
    private float velRotacion;
    [SerializeField]
    private bool estaRotando;
    public bool EstaRotando { get => estaRotando; set => estaRotando = value; }
    [SerializeField]
    private bool funcionando;
    public bool Funcionando { get => funcionando; set => funcionando = value; }

    [SerializeField]
    private float throwForce = 10;
    public float ThrowForce { get => throwForce; set => throwForce = value; }
    // Start is called before the first frame update
    void Start()
    {
        estaRotando = true;
        velRotacion = 100f;
        funcionando = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (estaRotando)
        {
            transform.Rotate(0, Time.deltaTime * velRotacion, 0);
        }

    }
}
