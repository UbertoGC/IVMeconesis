using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionarUnidad : MonoBehaviour
{
    [SerializeField] private DatosJuego Informacion;
    [Header("Tipo de Unidad")]
    [SerializeField] private int TipoUnidad;
    private void OnMouseDown()
    {
        Informacion.UnidadSeleccionada = TipoUnidad;
    }
}
