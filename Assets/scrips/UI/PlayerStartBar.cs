using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStartBar : MonoBehaviour
{
    public Image bloodImage;

    public Image bloodDelayImage;

    Vector2 spawnPoint;

    public void OnBloodChange(float persentage)
    {
        bloodImage.fillAmount = persentage;
    }

    public void Chase(Vector2 point)
    {
        var self = GetComponent<Rigidbody2D>();
        self.velocity = new Vector2(point.x - 20f, self.velocityY) - new Vector2(point.x, self.velocityY);
    }
}
