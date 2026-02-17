using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiberarDullahan : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Sistema_de_Transformacoes sis = collision.GetComponent<Sistema_de_Transformacoes>();

            sis.EscolhendoTransformacao(1);

            Debug.Log("Transformação Dullahan liberada");

            Destroy(gameObject);
        }    
    }
}
