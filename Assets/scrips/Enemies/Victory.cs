using UnityEngine;

public class Victory : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            // 销毁对象
            Destroy(gameObject);
        }
    }
}
