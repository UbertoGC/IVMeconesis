using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvocacionEnemiga : MonoBehaviour
{
    private void Start()
    {
        
    }
    public void Invocar(GameObject Ser)
    {
        Vector3 arriba = transform.position;
        arriba.y += 0.5f;
        Instantiate(Ser, arriba, transform.rotation);
    }
}
