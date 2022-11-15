using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    Vector2 inputVec;
    public float speed;

    Rigidbody2D rigid;
    void Awake()//시작할때 한번만 호출
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() //물리연산 프레임마다 호출
    {
        //1.힘을 준다
        //rigid.AddForce(inputVec);

        //2. 속도 제어
        //rigid.velocity = inputVec;

        //3. 위치 이동
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;//벡터값의 크기가 1이 되도록 수정 * fixedDeltaTime은 물리프레임 하나가 소비한 시간
        rigid.MovePosition(rigid.position + nextVec); //현재위치도 더해주어야 함

    }

}
