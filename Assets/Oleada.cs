using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oleada : MonoBehaviour
{
    [Header("Informacion")]
    [SerializeField] public int NumeroDeInvocaciones;
    [SerializeField] public InvocacionEnemiga[] Zonas = new InvocacionEnemiga[4];
    [SerializeField] public GameObject[] TipoEnemigos = new GameObject[4];
    [SerializeField] public int[] ClaseEnemigos;
    [SerializeField] public float[] TiempoAparicion;
    [SerializeField] public int[] ZonaAparicion;
    public bool[] ValidarInvocacion;
    private void Start()
    {
        ValidarInvocacion = new bool[TiempoAparicion.Length];
        for (int i = 0; i < TiempoAparicion.Length; i++)
        {
            ValidarInvocacion[i] = true;
        }
    }
    private void Update()
    {
        bool SinNadaQueInvocar = true;
        for (int i = 0; i< TiempoAparicion.Length; i++)
        {
            if (ValidarInvocacion[i])
            {
                if(TiempoAparicion[i] <= 0)
                {
                    Zonas[ZonaAparicion[i]].Invocar(TipoEnemigos[ClaseEnemigos[i]]);
                    ValidarInvocacion[i] = false;
                }
                else
                {
                    TiempoAparicion[i] -= Time.deltaTime;
                }
                SinNadaQueInvocar = false;
            }
        }
        if (SinNadaQueInvocar)
        {
            Destroy(gameObject);
        }
    }
}
