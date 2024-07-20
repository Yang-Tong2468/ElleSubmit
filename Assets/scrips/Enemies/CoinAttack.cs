using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinAttack : MonoBehaviour
{
    [Header("血量变化")]
    public int Subtractblood;// 玩家减少的血量

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            // 给玩家减少血量
            Character character = collider.GetComponent<Character>();
            if (character != null)
            {
                character.ReduceBlood(Subtractblood);
            }

            // 销毁金币对象
            Destroy(gameObject);
        }
    }
}
