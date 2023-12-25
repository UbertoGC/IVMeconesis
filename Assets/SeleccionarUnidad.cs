using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeleccionarUnidad : MonoBehaviour
{
    [Header("Tipo de Unidad")]
    [SerializeField] private Image[] DemasOpciones;
    private void OnMouseDown()
    {
        for (int i = 0; i < DemasOpciones.Length; i++)
        {
            DemasOpciones[i].color = Color.white;
        }
        GetComponent<Image>().color = Color.cyan;
    }
}
