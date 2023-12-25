using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Invocación : MonoBehaviour
{
    [Header("Datos Principales")]
    [SerializeField] private DatosJuego Informacion;
    [SerializeField] private GameObject UnidadColocada;
    [SerializeField] public bool Usado = false;
    private void OnMouseDown()
    {
        if (Informacion.UnidadSeleccionada != 0 && !Usado)
        {
            int indice = Informacion.UnidadSeleccionada - 1;
            if (Informacion.PagarCosto(indice))
            {
                Vector3 arriba = transform.position;
                arriba.y += 0.5f;
                arriba.z += 3f;
                UnidadColocada = Instantiate(Informacion.Unidades[indice], arriba, transform.rotation);
                Usado = true;
                print("Invocando");
            }
        }
    }
    private void Update()
    {
        if (UnidadColocada == null || UnidadColocada.IsDestroyed())
        {
            Usado = false;
        }
    }
}