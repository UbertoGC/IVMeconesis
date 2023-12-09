using UnityEngine;

public class Aliado : Unidad
{
    [Header("Disparo")]
    [SerializeField] private GameObject Munici�n;
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
        Instantiate(Munici�n, ControladorDisparo.position, ControladorDisparo.rotation);
    }
}
