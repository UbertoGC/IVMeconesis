using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarVida : MonoBehaviour
{
    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            other.GetComponent<Enemigo>().DestinoAlcanzado();
        }
    }
}
