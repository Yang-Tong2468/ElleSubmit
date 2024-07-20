using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class DementorController : MonoBehaviour
{
    [Header("坐标信息")]
    public float DementorPositionX;

    public float height;

    public DementorController()
    {
        // 获取其他游戏对象
        GameObject PlayerObject = GameObject.Find("Player");

        // 获取其他游戏对象的Transform组件
        Transform PlayerObjectTransform = PlayerObject.transform;

        // 获取其他游戏对象的横纵坐标信息
        float xPosition = PlayerObjectTransform.position.x;

        DementorPositionX = xPosition - 10;

        for (int i = 0; i < 20; i++)
        {
            DementorPositionX = xPosition + 1;
        }
    }

    

    public void Start()
    {
        // 设置摄魂怪的位置
        transform.position = new Vector2(DementorPositionX,height);
    }

}
