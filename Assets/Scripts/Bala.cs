using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    
    [Header("Estad�sticas")]
    [SerializeField] private float velocidad;
    [SerializeField] private float da�o;
    [SerializeField] private string TagDisparador;
    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.right * velocidad * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo") || other.CompareTag("Aliado"))
        {
            Debug.Log("Hola");
            if (!other.CompareTag(TagDisparador))
            {
                if(other.CompareTag("Enemigo"))
                    other.GetComponent<Enemigo>().RecibirDa�o(da�o);
                else
                    other.GetComponent<Unidad>().RecibirDa�o(da�o);
                Destroy(gameObject);
            }
        }
    }
}
