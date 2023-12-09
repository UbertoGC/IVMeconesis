using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvocacionEnemiga : MonoBehaviour
{
    private void Start()
    {
        
    }
    public void Invocar(Enemigo Ser)
    {
        Vector3 arriba = transform.position;
        arriba.y += 1f;
        Instantiate(Ser, arriba, transform.rotation);
    }
}
