using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [Header("基本属性")]
    public float maxblood;

    public float currentblood;

    [Header("受伤无敌")]
    //无敌的时间
    public float invulnerableDuration;

    //计时器
    private float invulnerableCounter;

    public bool invulnerable;

    public UnityEvent<Transform> OnTakeDamage;

    public UnityEvent OnDie; 

    private void Start()
    {
        currentblood = maxblood;
    }

    private void Update()
    {
        if (invulnerable)
        {
            invulnerableCounter -= Time.deltaTime;
            if(invulnerableCounter <= 0)
            {
                invulnerable = false;
            }
        }
    }

    //一旦触发受到伤害，如果可受到伤害，就减一次血，再触发触发器，后面将不会再受到伤害，伤害被return掉了，再把计时器持续不断的减去时间的修正
    public void TakeDamage(Attack attacker)
    {
        //Debug.Log(attacker.damage);
        if (invulnerable)
            return;
        if(currentblood - attacker.damage > 0)
        {
            //触发受伤无敌
            currentblood -= attacker.damage;
            TriggerInvulnerable();
            //执行受伤动作
            OnTakeDamage?.Invoke(attacker.transform);
        }
        else
        {
            currentblood = 0;
            //触发死亡动作
            OnDie?.Invoke();
        }
    }

    private void TriggerInvulnerable()
    {
        if (!invulnerable)
        {
            invulnerable = true;
            invulnerableCounter = invulnerableDuration;
        }
    }

    public void TakeDamage1( DementorAttack Dattacker,int damage,float attackrange,float attackrate)
    {
        //Debug.Log(attacker.damage);
        if (invulnerable)
            return;
        if (currentblood - Dattacker.damage > 0)
        {
            //触发受伤无敌
            currentblood -= Dattacker.damage;
            TriggerInvulnerable();
            //执行受伤动作
            OnTakeDamage?.Invoke(Dattacker.transform);
        }
        else
        {
            currentblood = 0;
            //触发死亡动作
            OnDie?.Invoke();
        }
    }

    // 增加玩家血量的方法
    public void AddBlood(int amount)
    {
        currentblood += amount; // 增加玩家血量
        if (currentblood > maxblood)
        {
            currentblood = maxblood; // 确保血量不超过最大值
        }
    }

    // 减少玩家血量的方法
    public void ReduceBlood(int amount)
    {
        currentblood -= amount; // 减少玩家血量
        if (currentblood < 0)
        {
            currentblood = 0; // 确保血量不低于0
        }
    }
}
