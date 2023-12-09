using UnityEngine;

public class Unidad : MonoBehaviour
{
    [Header("Estad�sticas")]
    
    [SerializeField] protected float Vida;
    [SerializeField] protected GameObject Animaci�nDeMuerte;
    [SerializeField] protected float VelocidadDeMovimiento;
    [SerializeField] protected float SuavizadoDeMovimiento;
    [SerializeField] public int Valor;
    protected Vector3 Velocidad = Vector3.zero;
    protected bool MirandoDerecha = true;
    public bool Atacando = false;
    public void RecibirDa�o(float Da�o)
    {
        Vida -= Da�o;
        if(Vida <= 0)
        {
            Muerte();
        }
    }
    protected void Muerte()
    {
        Instantiate(Animaci�nDeMuerte, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
