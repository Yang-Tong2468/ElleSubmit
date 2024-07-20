using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;

    private Rigidbody2D rb;

    private PhysicsCheck physicscheck;

    private playercontroler playerControler;

    private void Awake()
    {
        anim = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();

        physicscheck = GetComponent<PhysicsCheck>();

        playerControler = GetComponent<playercontroler>();
    }

    private void Update()
    {
        SetAnimation();
    }

    private void SetAnimation()
    {
        anim.SetFloat("velocityX",Mathf.Abs(rb.velocity.x));
        anim.SetFloat("velocityY", rb.velocity.y);
        anim.SetBool("IsGround", physicscheck.IsGround);
        anim.SetBool("IsCrouch", playerControler.IsCrouch);
        anim.SetBool("IsDead", playerControler.IsDead);
    }

    public void PlayHurt()
    {
        anim.SetTrigger("hurt");
    }
}
