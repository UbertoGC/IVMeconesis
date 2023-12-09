using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    
    [Header("Estadísticas")]
    [SerializeField] private float velocidad;
    [SerializeField] private float daño;
    [SerializeField] private string TagDisparador;
    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.right * velocidad * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo") || other.CompareTag("Aliado"))
        {
            if (!other.CompareTag(TagDisparador))
            {
                if(other.CompareTag("Enemigo"))
                    other.GetComponent<Enemigo>().RecibirDaño(daño);
                else
                    other.GetComponent<Unidad>().RecibirDaño(daño);
                Destroy(gameObject);
            }
        }
    }
}
