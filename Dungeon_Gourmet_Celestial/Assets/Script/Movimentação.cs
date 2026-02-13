using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentação : MonoBehaviour
{
    [Header("Movimentação")]
    public float Velocidade;
    private Rigidbody2D rb;
    private Vector2 direction;

    [Header("Dash")]
    public float dashPower = 9;
    public float dashDuration = 0.9f;
    private bool isDashing = false;
    public bool candash = true;
    private float dashCooldown = 1f;

    [SerializeField] private TrailRenderer tr;

    [Header("Flip")]
    private bool isFacingRight = true;
    //private bool isFacingUp = true;

    [Header("Configurações de ataque")]
    public Transform Attackpoint;
    public float offsetAttaque = 0.5f;

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

        if(direction != Vector2.zero)
        {
            Vector2 posicaoDesejada = direction * offsetAttaque;

            if(transform.localScale.x < 0)
            {
                posicaoDesejada.x *= -1;
            }

            Attackpoint.localPosition = posicaoDesejada;
        }

        if(direction.x > 0 && isFacingRight)
        {
            Flip();
        }
        else if(direction.x < 0 && !isFacingRight)
        {
            Flip();
        }


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

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    //private void FlipY()
    //{
    //    isFacingUp = !isFacingUp;
    //    Vector3 scaler = transform.localScale;
    //    scaler.y *= -1;
    //    transform.localScale = scaler;
    //}
}
