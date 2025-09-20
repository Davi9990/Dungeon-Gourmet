using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque_Melle : MonoBehaviour
{
    public float dano = 10;
    public float cooldown = 0.2f;

    public Transform AttackPoint;
    public float AttackCheckRadius = 0.2f;
    public bool podeAtacar;

    [SerializeField]private float proximoAtaque = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Time.time >= proximoAtaque && Input.GetMouseButtonDown(0))
        {
            AttackMele() ;
            proximoAtaque += Time.time + cooldown;
        }

    }

    private void AttackMele()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(AttackPoint.position, AttackCheckRadius);
        //podeAtacar = false;

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Enemy_Life inimigo = collider.GetComponent<Enemy_Life>();   
                if(inimigo != null) 
                {
                    inimigo.currentLife -= dano;
                    Debug.Log($"Ataque inimigo: {collider.name}");
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (AttackPoint == null) return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(AttackPoint.position, AttackCheckRadius);
    }
}
