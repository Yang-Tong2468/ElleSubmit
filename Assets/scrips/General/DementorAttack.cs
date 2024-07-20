using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DementorAttack : MonoBehaviour
{
    public int damage;

    public float attackrange;

    public float attackrate;

    private void OnTriggerStay2D(Collider2D other)
    {
        other.GetComponent<Character>()?.TakeDamage1(this,damage,attackrange,attackrate);
    }
}
