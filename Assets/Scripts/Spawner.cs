using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public SpawnData[] spawnData;

    int level;
    float timer;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }
    void Update()
    {
        if (!GameManager.instance.isLive) return;

        timer += Time.deltaTime;
        //FloorToInt : 소수점 아래는 버리고 Int형으로 바꾸는 함수
        level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / 10f), spawnData.Length - 1);

        if (timer > spawnData[level].spawnTime)
        {           
            timer = 0;
            Spawn();
        }
        
    }
    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(0);
        //자식 오브젝트에서만 생성되도록 1부터 시작
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        enemy.GetComponent<Enemy>().Init(spawnData[level]);
    }
}
//직렬화
[System.Serializable]
public class SpawnData
{
    public float spawnTime;
    public int spriteType;   
    public int health;
    public float speed;
}
