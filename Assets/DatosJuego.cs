using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DatosJuego : MonoBehaviour
{
    [Header("Controlador de Dialogos")]
    [SerializeField] public AdministrarPantallas ControladorPantallas;
    [Header("Cargar Unidades")]
    [SerializeField] public GameObject[] Unidades = new GameObject[4];
    [Header("Enemigos")]
    [SerializeField] private GameObject[] Enemigos = new GameObject[4];
    [Header("Oleadas")]
    [SerializeField] private GameObject OlaDeEnemigos;
    [SerializeField] private InvocacionEnemiga[] ZonasEnemigas = new InvocacionEnemiga[4];
    [SerializeField] private float TiempoRecargaOleada= 15f;
    [SerializeField] private float TiempoParaPrimeraOleada = 5f;
    [Header("Estadisticas")]
    [SerializeField] private Text ContadorDeDinero;
    [SerializeField] private Text ContadorDeVida;
    [SerializeField] private float RecargaDeGananciaDeDinero = 5f;
    [SerializeField] private int DineroPorTiempo = 2;
    [SerializeField] private int DineroInicial = 10;
    [SerializeField] private int VidaInicial = 10;
    [SerializeField] public int EnemigosRestantes;

    public int Dinero;
    public int Vida;
    private float TiempoParaMasDinero;
    public int UnidadSeleccionada;

    /*Informacion Sobre Oleadas*/
    Oleada Oleadas;
    private int NúmerodeEnemigos = 14;
    private int NúmeroOleadas = 4;
    private int[] EnemigosPorOleada = new int[4];
    private int[][] ClaseEnemigosInvocados = new int[4][];
    private float[][] TiempoAparicion = new float[4][];
    private int[][] ZonaAparicion = new int[4][];
    private int OleadasRestantes = 0;
    private bool Derrotado = false;
    private bool PartidaFinalizada = false;
    private float TiempoParaIrse = 3.0f;
    private float PreparacionParaOleada;

    private void Start()
    {
        /*Estadisticas*/
        
        Oleadas = OlaDeEnemigos.GetComponent<Oleada>();
        PreparacionParaOleada = TiempoParaPrimeraOleada;
        Dinero = DineroInicial;
        Vida = VidaInicial;
        ContadorDeDinero.text = Dinero.ToString();
        ContadorDeVida.text = Vida.ToString();
        UnidadSeleccionada = 0;
        TiempoParaMasDinero = RecargaDeGananciaDeDinero;
        for (int i = 0; i < 4; i++)
        {
            if (Enemigos[i]!= null)
            {
                Enemigos[i].GetComponent<Enemigo>().Información = this;
            }
        }

        /*DeterminarOleadas*/
        Oleadas.Zonas = ZonasEnemigas;
        Oleadas.TipoEnemigos = Enemigos;
        EnemigosRestantes = NúmerodeEnemigos;

        /*Oleada 1----------------------------------*/
        EnemigosPorOleada[0] = 2;
        ClaseEnemigosInvocados[0] = new int[EnemigosPorOleada[0]];
        TiempoAparicion[0] = new float[EnemigosPorOleada[0]];
        ZonaAparicion[0] = new int[EnemigosPorOleada[0]];
        /*Unidad 1*/
        ClaseEnemigosInvocados[0][0] = 0;
        TiempoAparicion[0][0] = 0f;
        ZonaAparicion[0][0] = 0;
        /*Unidad 2*/
        ClaseEnemigosInvocados[0][1] = 0;
        TiempoAparicion[0][1] = 2f;
        ZonaAparicion[0][1] = 1;
        /*Oleada 2----------------------------------*/
        EnemigosPorOleada[1] = 3;
        ClaseEnemigosInvocados[1] = new int[EnemigosPorOleada[1]];
        TiempoAparicion[1] = new float[EnemigosPorOleada[1]];
        ZonaAparicion[1] = new int[EnemigosPorOleada[1]];
        /*Unidad 1*/
        ClaseEnemigosInvocados[1][0] = 0;
        TiempoAparicion[1][0] = 0f;
        ZonaAparicion[1][0] = 0;
        /*Unidad 2*/
        ClaseEnemigosInvocados[1][1] = 0;
        TiempoAparicion[1][1] = 2f;
        ZonaAparicion[1][1] = 2;
        /*Unidad 3*/
        ClaseEnemigosInvocados[1][2] = 1;
        TiempoAparicion[1][2] = 4f;
        ZonaAparicion[1][2] = 1;
        /*Oleada 3----------------------------------*/
        EnemigosPorOleada[2] = 3;
        ClaseEnemigosInvocados[2] = new int[EnemigosPorOleada[2]];
        TiempoAparicion[2] = new float[EnemigosPorOleada[2]];
        ZonaAparicion[2] = new int[EnemigosPorOleada[2]];
        /*Unidad 1*/
        ClaseEnemigosInvocados[2][0] = 1;
        TiempoAparicion[2][0] = 0f;
        ZonaAparicion[2][0] = 3;
        /*Unidad 2*/
        ClaseEnemigosInvocados[2][1] = 1;
        TiempoAparicion[2][1] = 2f;
        ZonaAparicion[2][1] = 2;
        /*Unidad 3*/
        ClaseEnemigosInvocados[2][2] = 1;
        TiempoAparicion[2][2] = 4f;
        ZonaAparicion[2][2] = 3;
        /*Oleada 4----------------------------------*/
        EnemigosPorOleada[3] = 6;
        ClaseEnemigosInvocados[3] = new int[EnemigosPorOleada[3]];
        TiempoAparicion[3] = new float[EnemigosPorOleada[3]];
        ZonaAparicion[3] = new int[EnemigosPorOleada[3]];
        /*Unidad 1*/
        ClaseEnemigosInvocados[3][0] = 1;
        TiempoAparicion[3][0] = 0f;
        ZonaAparicion[3][0] = 0;
        /*Unidad 2*/
        ClaseEnemigosInvocados[3][1] = 1;
        TiempoAparicion[3][1] = 0f;
        ZonaAparicion[3][1] = 2;
        /*Unidad 3*/
        ClaseEnemigosInvocados[3][2] = 1;
        TiempoAparicion[3][2] = 1f;
        ZonaAparicion[3][2] = 1;
        /*Unidad 4*/
        ClaseEnemigosInvocados[3][3] = 1;
        TiempoAparicion[3][3] = 1f;
        ZonaAparicion[3][3] = 3;
        /*Unidad 5*/
        ClaseEnemigosInvocados[3][4] = 1;
        TiempoAparicion[3][4] = 2f;
        ZonaAparicion[3][4] = 2;
        /*Unidad 6*/
        ClaseEnemigosInvocados[3][5] = 1;
        TiempoAparicion[3][5] = 2f;
        ZonaAparicion[3][5] = 3;
    }
    private void Update()
    {
        if (!PartidaFinalizada)
        {
            if (Derrotado)
            {
                if (TiempoParaIrse <= 0)
                {
                    PartidaFinalizada = true;
                    Derrota();
                }
                else
                    TiempoParaIrse -= Time.deltaTime;
            }
            else if (EnemigosRestantes == 0)
            {

                if (TiempoParaIrse <= 0)
                {
                    PartidaFinalizada = true;
                    Victoria();
                }
                else
                    TiempoParaIrse -= Time.deltaTime;
            }
            else
            {
                if (TiempoParaMasDinero <= 0f)
                {
                    TiempoParaMasDinero = RecargaDeGananciaDeDinero;
                    GanarDinero(DineroPorTiempo);
                }
                else
                {
                    TiempoParaMasDinero -= Time.deltaTime;
                }
                if (OleadasRestantes < NúmeroOleadas)
                {
                    if (PreparacionParaOleada <= 0)
                    {
                        MandarOleada();
                        OleadasRestantes++;
                        PreparacionParaOleada = TiempoRecargaOleada;
                    }
                    else
                    {
                        PreparacionParaOleada -= Time.deltaTime;
                    }
                }
            }
        }
        
    }
    private void Derrota()
    {
        ControladorPantallas.Derrota(Vida, Dinero);
    }
    private void Victoria()
    {
        ControladorPantallas.VictoriaCinematica(Vida, Dinero);
    }
    private void MandarOleada()
    {
        
        Oleadas.NumeroDeInvocaciones = EnemigosPorOleada[OleadasRestantes];
        Oleadas.ClaseEnemigos = ClaseEnemigosInvocados[OleadasRestantes];
        Oleadas.TiempoAparicion = TiempoAparicion[OleadasRestantes];
        Oleadas.ZonaAparicion = ZonaAparicion[OleadasRestantes];
        Instantiate(OlaDeEnemigos, Vector3.zero, transform.rotation);
    }
    public bool PagarCosto(int Indice)
    {
        int Valor = Unidades[Indice].GetComponent<Aliado>().Valor;
        if (Valor > Dinero)
        {
            return false;
        }
        else
        {
            Dinero -= Valor;
            ContadorDeDinero.text = Dinero.ToString();
            return true;
        }
    }
    public void GanarDinero(int Valor)
    {
        Dinero += Valor;
        ContadorDeDinero.text = Dinero.ToString();
    }
    public void PerderVida(int Valor)
    {
        
        Vida -= Valor;
        ContadorDeVida.text = Vida.ToString();
        if (Vida <= 0)
        {
            Vida = 0;
            ContadorDeVida.text = Vida.ToString();
            Derrotado = true;
        }
    }
    public void Deseleccionar()
    {
        UnidadSeleccionada = 0;
    }
    public void ElegirUnidad(int TipoUnidad)
    {
        UnidadSeleccionada = TipoUnidad;
    }
}
