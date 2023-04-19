using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    Collider2D coll;

    void Awake()
    {
        coll = GetComponent<Collider2D>();
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;

        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;
        
        

        switch (transform.tag)
        {
            case "Ground":
                float diffX = playerPos.x - myPos.x; //플레이어와 타일맵 위치 계산
                float diffY = playerPos.y - myPos.y;           
                // nomalize사용 했을때
                //Vector3 playerDir = GameManager.instance.player.inputVec;
                float dirX = diffX < 0 ? -1 : 1;
                float dirY = diffY < 0 ? -1 : 1;
                diffX = Mathf.Abs(diffX);
                diffY = Mathf.Abs(diffY);

                if (diffX > diffY)
                {
                    //translate 지정된 값 만큼 현재 위치에서 이동
                    transform.Translate(Vector3.right * dirX * 40);
                }
                if (diffX < diffY)
                {
                    //translate 지정된 값 만큼 현재 위치에서 이동
                    transform.Translate(Vector3.up * dirY * 40);
                }
                break;
            case "Enemy":
                //콜라이더가 활성화 되있을때
                if(coll.enabled)
                {
                    Vector3 dist = playerPos - myPos;
                    Vector3 ran = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0);
                    transform.Translate(ran + dist * 2);
                }
                break;
        }
    }
    
}
