using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_Dano : MonoBehaviour
{
    public float dano;
    //public Vida_Player player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Vida_Player vida = collision.gameObject.GetComponent<Vida_Player>();

            if (vida != null)
            {
                vida.currentLife -= dano;
            }
        }
    }
}
