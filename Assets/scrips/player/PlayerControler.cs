using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class playercontroler : MonoBehaviour
{
    public PlayerInputControl inputcontrol;

    public Vector2 inputDirection;

    public Rigidbody2D rb;

    public PhysicsCheck physicscheck;

    [Header("��������")]
    public float speed;

    private float runspeed;

    private float walkspeed => speed / 2.5f;

    public float jumpForce;

    public bool IsCrouch;

    private CapsuleCollider2D cc2;

    private Vector2 OriginalOffset;

    private Vector2 OriginalSize;

    public float hurtForce;

    public bool IsHurt;

    public bool IsDead;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        physicscheck = GetComponent<PhysicsCheck>();
        cc2 = GetComponent<CapsuleCollider2D>();
        OriginalOffset = cc2.offset;
        OriginalSize = cc2.size;
        inputcontrol = new PlayerInputControl();
        inputcontrol.GamePlay.Jump.started += Jump;

# region ǿ����·
        runspeed = speed;
        inputcontrol.GamePlay.WalkButton.performed += ctx => {
            if (physicscheck.IsGround){
                speed = walkspeed;
            }
        };

        inputcontrol.GamePlay.WalkButton.canceled += ctx => {
            if (physicscheck.IsGround){
                speed = runspeed;
            }
        };
        #endregion
    }

    private void OnEnable()
    {
        inputcontrol.Enable();
    }

    private void OnDisable()
    {
        inputcontrol.Disable();
    }

    private void Update()
    {
        inputDirection = inputcontrol.GamePlay.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        if(!IsHurt)
        Move();
    }


    //����
    private void OnTriggerStay2D(Collider2D collision)
    { 
        //Debug.Log(collision.name);
    }


    public void Move()
    {
        //�����ƶ�
        if(!IsCrouch)
        rb.velocity = new Vector2(inputDirection.x * speed * Time.deltaTime,rb.velocity.y);

        int faceDirection = (int)transform.localScale.x;

        if(inputDirection.x > 0)
        {
            faceDirection = -1;
        }
        if (inputDirection.x < 0)
        {
            faceDirection = 1;
        }
        //���﷭ת
        transform.localScale = new Vector3(faceDirection, 1, 1);

        //�¶�
        IsCrouch = inputDirection.y < -0.5f && physicscheck.IsGround;
        if (IsCrouch)
        {
            //�޸���ײ�彺�ҵĴ�С
            cc2.offset = new Vector2(-0.05f, 0.8f);
            cc2.size = new Vector2(0.66f, 1.7f);
        }
        else
        {
            //��ԭ��С
            cc2.offset = OriginalOffset;
            cc2.size = OriginalSize;
        }
    }


    private void Jump(InputAction.CallbackContext context)
    {
        //Debug.Log("JUMP");

        if (physicscheck.IsGround)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
        

    }

    public void GetHurt(Transform attacker)
    {
        IsHurt = true;
        rb.velocity = Vector2.zero;
        Vector2 dir = new Vector2((transform.position.x - attacker.position.x), 0).normalized;
        rb.AddForce(dir * hurtForce, ForceMode2D.Impulse);
    }

    public void PlayDead()
    {
        IsDead = true;
        inputcontrol.GamePlay.Disable();
    }
}
