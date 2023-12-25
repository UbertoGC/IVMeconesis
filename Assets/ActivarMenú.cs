using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarMenú : MonoBehaviour
{
    public bool EstadoMenúInvocacion = false;
    [Header("Menú para controlar")]
    [SerializeField] private GameObject Menú;
    [SerializeField] private SpriteRenderer[] MenúOpcionesAInvocar;
    [SerializeField] private GameObject ZonaInvocación;
    [SerializeField] private DatosJuego Informacion;
    private void OnMouseDown()
    {
        EstadoMenúInvocacion = !EstadoMenúInvocacion;
        Menú.SetActive(EstadoMenúInvocacion);
        ZonaInvocación.SetActive(EstadoMenúInvocacion);
        if (!EstadoMenúInvocacion)
        {
            Informacion.UnidadSeleccionada = 0;
            for(int i = 0; i <= MenúOpcionesAInvocar.Length; i++)
            {
                MenúOpcionesAInvocar[i].color = Color.white;
            }
        }
    }
}
