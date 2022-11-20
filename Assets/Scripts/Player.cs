using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour

{
    Vector2 inputVec;
    public float speed;

    Rigidbody2D rigid;
    void Awake()//�����Ҷ� �ѹ��� ȣ��
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    
    

    void FixedUpdate() //�������� �����Ӹ��� ȣ��
    {
        //1.���� �ش�
        //rigid.AddForce(inputVec);

        //2. �ӵ� ����
        //rigid.velocity = inputVec;

        //3. ��ġ �̵�
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;//���Ͱ��� ũ�Ⱑ 1�� �ǵ��� ���� * fixedDeltaTime�� ���������� �ϳ��� �Һ��� �ð�
        rigid.MovePosition(rigid.position + nextVec); //������ġ�� �����־�� ��

    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>(); //������ Ÿ�� ��������


    }

}
