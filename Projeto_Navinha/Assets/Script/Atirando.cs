using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirando : MonoBehaviour
{
    [Header("Configuração do Projétil")]
    public GameObject projectilePrefab;
    public float projectileSpeed = 15f;
    public float lifeTime = 3f;

    [Header("Spawn")]
    public Transform firePoint;

    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        // Define posição e rotação de disparo
        Vector3 spawnPos = firePoint != null ? firePoint.position : transform.position;
        Quaternion spawnRot = firePoint != null ? firePoint.rotation : transform.rotation;

        // Cria o projétil
        GameObject clone = Instantiate(projectilePrefab, spawnPos, spawnRot);

        // Aplica velocidade se tiver Rigidbody2D
        Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 0; // projétil não cai (deixe >0 se quiser gravidade)
            rb.velocity = (firePoint != null ? firePoint.up : transform.up) * projectileSpeed;
        }

        // Destroi após tempo de vida
        Destroy(clone, lifeTime);
    }
}
