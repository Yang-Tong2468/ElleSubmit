using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    private CapsuleCollider2D coll;
    [Header("检测参数")]
    public bool manual;
    public Vector2 bottomOffset;

    public Vector2 leftOffset;

    public Vector2 rightOffset;

    public float CheckRaduis;

    public LayerMask GroundLayer;

    [Header("状态")]
    public bool IsGround;

    public bool touchLeftWall;

    public bool touchRightWall;

    private void Awake()
    {
        coll = GetComponent<CapsuleCollider2D>();

        if (!manual)
        {
            rightOffset = new Vector2((coll.bounds.size.x + coll.offset.x) / 2, coll.bounds.size.y / 2);
            leftOffset = new Vector2(-rightOffset.x, rightOffset.y);
        }
    }
    private void Update()
    {
        Check();
    }

    private void Check()
    {
        //检测地面
        IsGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, CheckRaduis, GroundLayer);

        //墙体判断
        touchLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, CheckRaduis, GroundLayer);

        touchRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, CheckRaduis, GroundLayer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, CheckRaduis);

        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, CheckRaduis);

        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, CheckRaduis);
    }
}
