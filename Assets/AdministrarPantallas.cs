using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdministrarPantallas : MonoBehaviour
{

    [Header("Invocaciones")]
    [SerializeField] private GameObject ZonaDeInvocaciones;
    [SerializeField] private GameObject MenúDeInvocaciones;
    [SerializeField] private Image[] Botones;

    [Header("Pantallas")]
    [SerializeField] private GameObject PantallaCinematica;
    [SerializeField] private GameObject PantallaVideojuego;
    [SerializeField] private GameObject PantallaDerrota;
    [SerializeField] private GameObject PantallaVictoria;
    [SerializeField] private GameObject PantallaPausa;

    [Header("Botones")]
    [SerializeField] private GameObject BotónSaltarTutorial;
    [SerializeField] private GameObject BotónReiniciar;
    [SerializeField] private GameObject BotónSalir;
    [SerializeField] private RectTransform PosicionFinalReiniciar;
    [SerializeField] private RectTransform PosicionFinalSalir;

    [Header("Campo Texto")]
    [SerializeField] private Text TextoDerrota;
    [SerializeField] private Text TextoVictoria;

    [Header("Dialogos")]
    [SerializeField] private Text CampoMensaje;
    [SerializeField] private Image Personaj00;
    [SerializeField] private Image Personaj01;
    [SerializeField] private string[] Texto;
    [SerializeField] private Sprite[] Persona00;
    [SerializeField] private Sprite[] Persona01;

    private bool PermitirInvocar;
    private int indice;
    private int fintutorial;
    private int cinematicafinal;
    private int Resultados;
    // Start is called before the first frame update
    void Start()
    {
        PermitirInvocar = false;
        Time.timeScale = 0f;
        indice = 0;
        cinematicafinal = 8;
        fintutorial = 4;
        for (int i = 0; i < Texto.Length; i++)
        {
            Texto[i] = Texto[i].Replace('/', '\n');
        }
        PantallaCinematica.SetActive(true);
        PantallaVideojuego.SetActive(false);
        PantallaDerrota.SetActive(false);
        PantallaVictoria.SetActive(false);
        PantallaPausa.SetActive(false);

        BotónReiniciar.SetActive(false);
        BotónSalir.SetActive(false);

        ImprimirCinematica();
    }
    public void InteracctuarMenúInvocacion()
    {
        PermitirInvocar = !PermitirInvocar;
        ZonaDeInvocaciones.SetActive(PermitirInvocar);
        MenúDeInvocaciones.SetActive(PermitirInvocar);
        if (!PermitirInvocar)
        {
            for (int i = 0; i < Botones.Length; i++)
            {
                Botones[i].color = Color.white;
            }
        }
    }
    public void Pausar()
    {
        Time.timeScale = 0f;

        PantallaCinematica.SetActive(false);
        PantallaVideojuego.SetActive(false);
        PantallaDerrota.SetActive(false);
        PantallaVictoria.SetActive(false);
        PantallaPausa.SetActive(true);

        BotónReiniciar.SetActive(true);
        BotónSalir.SetActive(true);
    }
    public void Despausear()
    {
        PantallaCinematica.SetActive(false);
        PantallaVideojuego.SetActive(true);
        PantallaDerrota.SetActive(false);
        PantallaVictoria.SetActive(false);
        PantallaPausa.SetActive(false);

        BotónReiniciar.SetActive(false);
        BotónSalir.SetActive(false);

        Time.timeScale = 1f;
    }
    public void VictoriaCinematica(int PuntosDeVida, int Oro)
    {
        Time.timeScale = 0f;
        Resultados = PuntosDeVida * 40 + Oro * 30;
        
        PantallaCinematica.SetActive(true);
        PantallaVideojuego.SetActive(false);
        PantallaDerrota.SetActive(false);
        PantallaVictoria.SetActive(false);
        PantallaPausa.SetActive(false);

        ImprimirCinematica();
    }
    private void Victoria()
    {
        TextoVictoria.text = "VICTORIA:\n" + "PUNTAJE: " + Resultados;

        PantallaCinematica.SetActive(false);
        PantallaVideojuego.SetActive(false);
        PantallaDerrota.SetActive(false);
        PantallaVictoria.SetActive(true);
        PantallaPausa.SetActive(false);

        BotónReiniciar.SetActive(true);
        BotónSalir.SetActive(true);

        BotónReiniciar.GetComponent<RectTransform>().position = PosicionFinalReiniciar.position;
        BotónSalir.GetComponent<RectTransform>().position = PosicionFinalSalir.position;
    }
    public void Derrota(int PuntosDeVida, int Oro)
    {
        Time.timeScale = 0f;
        Resultados = PuntosDeVida * 40 + Oro * 30;
        TextoDerrota.text = "DERROTA:\n" + "PUNTAJE: " + Resultados;

        PantallaCinematica.SetActive(false);
        PantallaVideojuego.SetActive(false);
        PantallaDerrota.SetActive(true);
        PantallaVictoria.SetActive(false);
        PantallaPausa.SetActive(false);

        BotónReiniciar.SetActive(true);
        BotónSalir.SetActive(true);

        BotónReiniciar.GetComponent<RectTransform>().position = PosicionFinalReiniciar.position;
        BotónSalir.GetComponent<RectTransform>().position = PosicionFinalSalir.position;

    }
    private void ImprimirCinematica()
    {
        if (Persona00[indice].IsUnityNull())
        {
            Personaj00.enabled = false;
        }
        else
        {
            Personaj00.enabled = true;
            Personaj00.sprite = Persona00[indice];
        }
        if (Persona01[indice].IsUnityNull())
        {
            Personaj01.enabled = false;
        }
        else
        {
            Personaj01.enabled = true;
            Personaj01.sprite = Persona01[indice];
        }
        if(Texto[indice].IsUnityNull())
        {
            CampoMensaje.enabled = false;
        }
        else
        {
            CampoMensaje.enabled = true;
            CampoMensaje.text = Texto[indice];
        }
    }
    // Update is called once per frame
    public void Avanzar()
    {
        indice++;
        if (indice == fintutorial)
        {
            BotónSaltarTutorial.SetActive(false);
        }
        if (indice == cinematicafinal)
        {
            PantallaCinematica.SetActive(false);
            PantallaVideojuego.SetActive(true);
            PantallaDerrota.SetActive(false);
            PantallaVictoria.SetActive(false);
            PantallaPausa.SetActive(false);

            Time.timeScale = 1f;
        }
        else if (indice < Texto.Length)
        {
            ImprimirCinematica();
        }
        else
        {
            Victoria();
        }
    }
    public void SaltarTutorial()
    {
        indice = fintutorial-1;
        Avanzar();
    }
    public void Salir()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
