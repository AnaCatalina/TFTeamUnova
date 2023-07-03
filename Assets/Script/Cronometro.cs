using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour
{

    [SerializeField]
    private float cronometro;
    [SerializeField]
    private int nivel;
    private int textCrono;
    public Text textComponent;
    // Start is called before the first frame update
    void Start()
    {
        switch (nivel)
        {
            case 1:
                cronometro = 120;
                break;
            case 2:
                cronometro = 240;

                break;
            case 3:
                cronometro = 420;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {        
        cronometro -= 1 * Time.deltaTime;
        textCrono = (int)cronometro;
        textComponent.text = "Tiempo: " + textCrono.ToString();
        if (cronometro == 0)
        {
            SceneManager.LoadScene(5);
        }

    }
}
