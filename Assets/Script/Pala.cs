using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pala : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float velRotacion;

    private float radio;
    [SerializeField]
    private bool funcionando;
    public bool Funcionando { get => funcionando; set => funcionando = value; }
    public float Radio { get => radio; set => radio = value; }
    // Start is called before the first frame update
    void Start()
    {
        radio = 10;
        velRotacion = 100f;
        funcionando = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Time.deltaTime * velRotacion, 0);
    }
}
