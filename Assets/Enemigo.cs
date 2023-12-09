using Unity.VisualScripting;
using UnityEngine;

public class Enemigo : Unidad
{
    private Animator Animador;

    [Header("Disparo")]
    [SerializeField] private GameObject Munici�n;
    [SerializeField] private Transform ControladorDisparo;
    [SerializeField] private float VelocidadDeDisparo;
    [SerializeField] public DatosJuego Informaci�n;
    private float TiempoDeEspera = 0f;
    private bool Pagar = false;
    private void Start()
    {
        Girar();
        Animador = GetComponent<Animator>();
    }
    private void Update()
    {
        if(Atacando)
        {
            Animador.SetBool("EnMovimiento", false);
            transform.Translate(Vector3.zero);
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
            Moverse();
        }
    }
    private void Moverse() {
        Animador.SetBool("EnMovimiento", true);
        transform.Translate(Vector3.right * VelocidadDeMovimiento * Time.deltaTime);
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
        Instantiate(Munici�n, ControladorDisparo.position, ControladorDisparo.rotation);
    }
    public void DestinoAlcanzado()
    {
        Informaci�n.PerderVida(Valor);
        Destroy(gameObject);
    }
    new public void Muerte()
    {
        Instantiate(Animaci�nDeMuerte, transform.position, transform.rotation);
        Informaci�n.GanarDinero(Valor);
        Informaci�n.EnemigosRestantes--;
        Destroy(gameObject);
    }
}
