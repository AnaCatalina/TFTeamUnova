using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;


public class Menu : MonoBehaviour
{
    [Header("Opciones")]
    public Slider FXvol;
    public Slider vol;
    public Toggle mute;
    public AudioMixer mixer;
    public AudioClip sonidoClick;
    public AudioSource fxSource;
    [Header("Panels")]
    public GameObject panelBotones;
    public GameObject opciones;
   public GameObject controles;

    [SerializeField] private int numeroScena;




    private void Awake()
    {
        FXvol.onValueChanged.AddListener(CambiarVolFX);
        vol.onValueChanged.AddListener(CambiarVolMaster);
    }



    public void AbrirPanel(GameObject panel) 
    { 
        panelBotones.SetActive(false);
        opciones.SetActive(false);
        controles.SetActive(false);


        panel.SetActive(true);
        SonidoBoton();
    }
    public void CambiarVolMaster(float v) {
        mixer.SetFloat("VolMaster",v); 
    } 
    public void CambiarVolFX(float v) {
        mixer.SetFloat("VolFX",v);
    }
    public void VolverMenu() 
    {
        SceneManager.LoadScene("menu");
    }

    public void EscenaJuego() {
        SceneManager.LoadScene("Nivel_1");
    }
    public void SonidoBoton()
    {

        fxSource.PlayOneShot(sonidoClick);

    }
       public void Salir() { 
           Application.Quit(); 
       }
}
