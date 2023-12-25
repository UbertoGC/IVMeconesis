using UnityEngine;

public class Aliado : Unidad
{
    private AudioSource AudioRecurso;
    [Header("Disparo")]
    [SerializeField] private GameObject Munición;
    [SerializeField] private Transform ControladorDisparo;
    [SerializeField] private float VelocidadDeDisparo;

    private float TiempoDeEspera = 0f;
    void Start()
    {
        AudioRecurso = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Atacando)
        {
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
    }
    protected void Disparar()
    {
        AudioRecurso.Play();
        Instantiate(Munición, ControladorDisparo.position, ControladorDisparo.rotation);
    }
}
