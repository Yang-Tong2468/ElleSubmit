using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class DementorController : MonoBehaviour
{
    [Header("������Ϣ")]
    public float DementorPositionX;

    public float height;

    public DementorController()
    {
        // ��ȡ������Ϸ����
        GameObject PlayerObject = GameObject.Find("Player");

        // ��ȡ������Ϸ�����Transform���
        Transform PlayerObjectTransform = PlayerObject.transform;

        // ��ȡ������Ϸ����ĺ���������Ϣ
        float xPosition = PlayerObjectTransform.position.x;

        DementorPositionX = xPosition - 10;

        for (int i = 0; i < 20; i++)
        {
            DementorPositionX = xPosition + 1;
        }
    }

    

    public void Start()
    {
        // �������ֵ�λ��
        transform.position = new Vector2(DementorPositionX,height);
    }

}
