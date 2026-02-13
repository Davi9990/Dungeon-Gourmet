using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dullahan : MonoBehaviour
{
    public float dano = 20;
    public float danoFogo = 6;
    public float resistencia = 5;

    public Transform AttackPoint;
    public float raiodeAtaque = 0.15f;
    public bool podeAtacar;
    private GameObject player;
    public float cooldown = 0.3f;
    private Sistema_de_Transformacoes sis;

    [SerializeField] private float proximoAtaque = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sis = player.GetComponent<Sistema_de_Transformacoes>(); 
    }


    void Update()
    {
        if (Time.time >= proximoAtaque && Input.GetMouseButtonDown(0))
        {
            AttackFogo();
            proximoAtaque = Time.time + cooldown;
        }

        if (enabled)
        {
            player.tag = "Dullahan";
        }
        else
        {
            player.tag = "Player";
        }
    }

    private void AttackFogo()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(AttackPoint.position, raiodeAtaque);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Enemy_Life inimigo = collider.GetComponent<Enemy_Life>();
                if (inimigo != null)
                {
                    inimigo.currentLife -= dano;

                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (AttackPoint == null) return;

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(AttackPoint.position, raiodeAtaque);
    }
}
