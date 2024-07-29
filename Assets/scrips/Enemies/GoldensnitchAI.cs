using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class GoldensnitchAI : MonoBehaviour
{
    public float speed = 5f; // 旋转速度
    public float radius = 2f; // 旋转半径
    private Vector3 center; // 旋转中心点

    void Start()
    {
        // 设置旋转中心点为物体当前位置
        center = transform.position;
    }

    void Update()
    {
        for(var i=0;i<20;i++){
        // 计算物体的新位置
        float angle = Time.time * speed;
        float x = center.x + Mathf.Cos(angle + i) * radius;
        float y = center.y + Mathf.Sin(angle - i) * radius;
        float z = center.z;
        // 更新物体的位置
        transform.position = new Vector3(x, y, z);
        }
    }
}


