using UnityEngine;

public class Aliado : Unidad
{
    [Header("Disparo")]
    [SerializeField] private GameObject Munición;
    [SerializeField] private Transform ControladorDisparo;
    [SerializeField] private float VelocidadDeDisparo;

    private float TiempoDeEspera = 0f;
    private void Update()
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
        Instantiate(Munición, ControladorDisparo.position, ControladorDisparo.rotation);
    }
}
