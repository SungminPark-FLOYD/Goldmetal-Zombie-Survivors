using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //정적 변수는 즉시 클래서에서 호출 가능
    public static GameManager instance;
    public PoolManager pool;
    public Player player;

    void Awake()
    {
        instance = this; //자기자신으로 초기화
    }

}
