using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AddBlood : MonoBehaviour
{
    [Header("血量变化")]
    public int Addblood;// 玩家增加的血量

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            // 给玩家增加血量
            Character character = collider.GetComponent<Character>();
            if (character != null)
            {
                character.AddBlood(Addblood);
            }

            // 销毁对象
            Destroy(gameObject);
        }
    }
}
