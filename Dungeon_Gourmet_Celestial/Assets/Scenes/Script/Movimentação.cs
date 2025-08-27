using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentação : MonoBehaviour
{
    public float Velocidade;
    private Rigidbody2D rb;
    private Vector2 direction;

    public float dashPower = 9;
    public float dashDuration = 0.9f;
    private bool isDashing = false;
    public bool candash = true;
    private float dashCooldown = 1f;
    [SerializeField] private TrailRenderer tr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), 
            Input.GetAxisRaw("Vertical")).normalized;

        rb.velocity = direction * Velocidade;

        if(direction.x != 0 && direction.y != 0) direction = direction.normalized;


        if (Input.GetKeyDown(KeyCode.LeftShift) && candash && direction != Vector2.zero)
        {
            Debug.Log("Dash iniciado na direção: " + direction);
            StartCoroutine(Dash());
        }

        if(isDashing)
        {
            Debug.DrawRay(transform.position, rb.velocity, Color.red);
        }
    }

    private void FixedUpdate()
    {
        if(isDashing)
        {
            return;
        }

        rb.velocity = direction * Velocidade;
    }

    private IEnumerator Dash()
    {
        candash = false;
        isDashing = true;

        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        rb.velocity = direction * dashPower;
        tr.emitting = true;

        Debug.Log("Velocidade durante dash: " + rb.velocity);

        yield return new WaitForSeconds(dashDuration);

        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;

        Debug.Log("Dash finalizado. Iniciando cooldown");

        yield return new WaitForSeconds(dashCooldown);
        candash = true;
        Debug.Log("Dash disponível novamente!");
    }
}
