using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour

{
    Vector2 inputVec;
    public float speed;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;
    void Awake()//시작할때 한번만 호출
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate() //물리연산 프레임마다 호출
    {
        //1.힘을 준다
        //rigid.AddForce(inputVec);

        //2. 속도 제어
        //rigid.velocity = inputVec;

        //3. 위치 이동
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;//벡터값의 크기가 1이 되도록 수정 * fixedDeltaTime은 물리프레임 하나가 소비한 시간
        rigid.MovePosition(rigid.position + nextVec); //현재위치도 더해주어야 함

    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>(); //설정한 타입 가져오기


    }

    void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude); //벡터의 순수한 크기값 비교

        if(inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0; //x 값이 0보다 크면 false 작으면 true

        }
    }

}
