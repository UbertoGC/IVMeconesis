using Unity.VisualScripting;
using UnityEngine;

public class Enemigo : Unidad
{
    private Animator Animador;
    private AudioSource AudioRecurso;
    [Header("Disparo")]
    [SerializeField] private GameObject Munici�n;
    [SerializeField] private Transform ControladorDisparo;
    [SerializeField] private float VelocidadDeDisparo;
    [SerializeField] public DatosJuego Informaci�n;
    private float TiempoDeEspera = 0f;
    void Start()
    {
        Girar();
        AudioRecurso = GetComponent<AudioSource>();
        Animador = GetComponent<Animator>();
    }
    void Update()
    {
        if(Atacando)
        {
            transform.Translate(Vector3.zero);
            Animador.SetBool("EnMovimiento", false);
            if (TiempoDeEspera <= 0f)
            {
                Disparar();
                TiempoDeEspera = VelocidadDeDisparo;
            }
            else
            {
                TiempoDeEspera -= Time.deltaTime;
            }
        }
        else
        {
            Animador.SetBool("EnMovimiento", true);
            transform.Translate(Vector3.right * VelocidadDeMovimiento * Time.deltaTime);
        }
    }
    private void Girar()
    {
        MirandoDerecha = !MirandoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
    }
    new public void RecibirDa�o(float Da�o)
    {
        Vida -= Da�o;
        if (Vida <= 0)
        {
            Muerte();
        }
    }
    private void Disparar()
    {
        AudioRecurso.Play();
        Instantiate(Munici�n, ControladorDisparo.position, ControladorDisparo.rotation);
    }
    public void DestinoAlcanzado()
    {
        Informaci�n.PerderVida(Valor);
        Informaci�n.EnemigosRestantes--;
        Destroy(gameObject);
    }
    new public void Muerte()
    {
        Instantiate(Animaci�nDeMuerte, transform.position, transform.rotation);
        Informaci�n.GanarDinero(Valor-2);
        Informaci�n.EnemigosRestantes--;
        Destroy(gameObject);
    }
}
