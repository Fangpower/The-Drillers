using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private PlayerControl pc;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    public float speedLevel;

    [SerializeField] float speed;
    [SerializeField] float flySpeed;
    [SerializeField] Transform drill;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;



    void Awake()
    {
        pc = new PlayerControl();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void OnEnable(){
        pc.Enable();
    }

    private void OnDisable(){
        pc.Disable();
    }

    void Update()
    {
        speed = 5 + (speedLevel/2);
        flySpeed = 6 + (speedLevel/2);

        float lr = pc.Controls.LR.ReadValue<float>();
        float ws = pc.Controls.UD.ReadValue<float>();
        rb.velocity = new Vector2(lr * speed, ws * flySpeed);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -9.5f, 9.5f), Mathf.Clamp(transform.position.y, -1000, 6));

        anim.SetBool("Walking", lr != 0);

        if(lr != 0){sr.flipX = lr > 0 ? true : false;}

        anim.SetBool("Flying", !(Physics2D.OverlapCircle(groundCheck.position, 0.25f, groundMask)));
    }
}
