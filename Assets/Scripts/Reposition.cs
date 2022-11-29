using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;

        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;
        float diffX = Mathf.Abs( playerPos.x - myPos.x); //플레이어와 타일맵 위치 계산
        float diffY = Mathf.Abs(playerPos.y - myPos.y);

        // nomalize사용 했을때
        Vector3 playerDir = GameManager.instance.player.inputVec;
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;
        

        switch (transform.tag)
        {
            case "Ground":
                if(diffX > diffY)
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

                break;
        }
    }
    
}
