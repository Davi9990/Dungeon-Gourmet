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
    private bool dashOn = true;
    public bool Nodash;
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
            Input.GetAxisRaw("Vertical"));

        rb.velocity = direction * Velocidade;

        if(direction.x != 0 && direction.y != 0) direction = direction.normalized;


        if (Input.GetKeyDown(KeyCode.LeftShift) && Nodash)
        {
            StartCoroutine(Dash());
        }
    }

    private void FixedUpdate()
    {
        if(dashOn)
        {
            return;
        }
    }

    //private void Dash()
    //{
    //    rb.AddForce(direction * dashPower, ForceMode2D.Impulse);
    //}

    private IEnumerator Dash()
    {
        dashOn = false;
        Nodash = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashPower, transform.localScale.y * dashPower);
        tr.emitting = true;
        yield return new WaitForSeconds(dashDuration);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        Nodash = false;
        yield return new WaitForSeconds(dashCooldown);
        dashOn = false;
    }
}
