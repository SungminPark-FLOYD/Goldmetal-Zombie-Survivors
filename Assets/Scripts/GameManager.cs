using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //���� ������ ��� Ŭ�������� ȣ�� ����
    public static GameManager instance;
    public PoolManager pool;
    public Player player;

    void Awake()
    {
        instance = this; //�ڱ��ڽ����� �ʱ�ȭ
    }

}
