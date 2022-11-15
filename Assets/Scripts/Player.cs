using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    Vector2 inputVec;
    public float speed;

    Rigidbody2D rigid;
    void Awake()//�����Ҷ� �ѹ��� ȣ��
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() //�������� �����Ӹ��� ȣ��
    {
        //1.���� �ش�
        //rigid.AddForce(inputVec);

        //2. �ӵ� ����
        //rigid.velocity = inputVec;

        //3. ��ġ �̵�
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;//���Ͱ��� ũ�Ⱑ 1�� �ǵ��� ���� * fixedDeltaTime�� ���������� �ϳ��� �Һ��� �ð�
        rigid.MovePosition(rigid.position + nextVec); //������ġ�� �����־�� ��

    }

}
