using Unity.VisualScripting;
using UnityEngine;

public class Enemigo : Unidad
{
    private Animator Animador;
    private AudioSource AudioRecurso;
    [Header("Disparo")]
    [SerializeField] private GameObject Munición;
    [SerializeField] private Transform ControladorDisparo;
    [SerializeField] private float VelocidadDeDisparo;
    [SerializeField] public DatosJuego Información;
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
    new public void RecibirDaño(float Daño)
    {
        Vida -= Daño;
        if (Vida <= 0)
        {
            Muerte();
        }
    }
    private void Disparar()
    {
        AudioRecurso.Play();
        Instantiate(Munición, ControladorDisparo.position, ControladorDisparo.rotation);
    }
    public void DestinoAlcanzado()
    {
        Información.PerderVida(Valor);
        Información.EnemigosRestantes--;
        Destroy(gameObject);
    }
    new public void Muerte()
    {
        Instantiate(AnimaciónDeMuerte, transform.position, transform.rotation);
        Información.GanarDinero(Valor-2);
        Información.EnemigosRestantes--;
        Destroy(gameObject);
    }
}
