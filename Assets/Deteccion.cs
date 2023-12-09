using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deteccion : MonoBehaviour
{
    private bool AlMenosUno = false;
    [Header("Unidad Elegida")]
    [SerializeField] private Unidad UnidadSeleccionada;
    private void Update()
    {
        if(!AlMenosUno)
        {
            UnidadSeleccionada.Atacando = false;
        }
        AlMenosUno = false;
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemigo") || other.CompareTag("Aliado"))
        {
            if (!other.CompareTag(UnidadSeleccionada.tag))
            {
                UnidadSeleccionada.Atacando = true;
                AlMenosUno = true;
            }
        }
    }
}
