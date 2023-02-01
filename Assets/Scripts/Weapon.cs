using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;
    public int prefabId;
    public float damage;
    public int count;
    public float speed;

    void Start()
    {
        Init();
    }
    void Update()
    {
        switch (id)
        {
            case 0:
                transform.Rotate(Vector3.back * speed * Time.deltaTime);
                break;
            default:
                break;
        }
        //test
        if (Input.GetButtonDown("Jump"))
        {
            LevelUp(20, 5);
        }

    }

    public void LevelUp(float damage, int count)
    {
        this.damage = damage;
        this.count += count;

        if(id == 0)       
            Batch();
        
    }

    public void Init()
    {
        switch(id)
        {
            case 0:
                speed = 150;
                Batch();

                break;
            default:
                break;
        }
    }
    //생성된 무기 배치하는 함수생성 및 호출
    void Batch()
    {
        for(int index=0; index < count; index++)
        {
            //오브젝트 가져와서 지역변수로 저장
            //기존 오브젝트를 먼저 활용하고 모자란 것은 풀에서 가져오기
            Transform bullet;
            if(index < transform.childCount)
            {
                bullet = transform.GetChild(index);
            }
            else
            {
                bullet = GameManager.instance.pool.Get(prefabId).transform;
                bullet.parent = transform;
            }               
            

            bullet.localPosition = Vector3.zero;
            //회전값 초기값설정
            bullet.localRotation = Quaternion.identity;

            Vector3 rotVec = Vector3.forward * 360 * index / count;
            bullet.Rotate(rotVec);
            bullet.Translate(bullet.up * 1.5f, Space.World);

            bullet.GetComponent<Bullet>().Init(damage, -1); // -1 is Infinity Per.
        }
    }
}
