using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //정적 변수는 즉시 클래스에서 호출 가능
    public static GameManager instance;

    public float gameTime;
    public float maxGameTime = 2 * 10f;
    public PoolManager pool;
    public Player player;

    void Awake()
    {
        instance = this; //자기자신으로 초기화
    }

    void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;           
        }

    }
}
