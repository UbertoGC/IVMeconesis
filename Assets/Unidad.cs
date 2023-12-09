using UnityEngine;

public class Unidad : MonoBehaviour
{
    [Header("Estadísticas")]
    
    [SerializeField] protected float Vida;
    [SerializeField] protected GameObject AnimaciónDeMuerte;
    [SerializeField] protected float VelocidadDeMovimiento;
    [SerializeField] protected float SuavizadoDeMovimiento;
    [SerializeField] public int Valor;
    protected Vector3 Velocidad = Vector3.zero;
    protected bool MirandoDerecha = true;
    public bool Atacando = false;
    public void RecibirDaño(float Daño)
    {
        Vida -= Daño;
        if(Vida <= 0)
        {
            Muerte();
        }
    }
    protected void Muerte()
    {
        Instantiate(AnimaciónDeMuerte, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
