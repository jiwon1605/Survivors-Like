using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 inputVec; //Ű �̵� ����
    Rigidbody2D rigid; //���� �̵� ����
    public float speed; //�ӵ�

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>(); //����Ƽ ���� �� Rigidbody2D�� rigid��� ������ ���� ��
    }

    // Update is called once per frame
    void Update()
    {

        //GetAxis�� ���� �������� �Է°��� �ε巯����(�̲������� ����)
        inputVec.x = Input.GetAxisRaw("Horizontal"); 
        inputVec.y = Input.GetAxisRaw("Vertical"); 
    }

    private void FixedUpdate()
    {
        //1.���� �ش�
        //rigid.AddForce(inputVec);

        //2.�ӵ� ����
        //rigid.velocity = inputVec;

        //���� ���� ũ�Ⱑ 1�� �ǵ��� ��ǥ�� ������ ��(��Ÿ��󽺿� ���� �밢�� ���̰� 1�� �ƴ��� ��������)
        //DeltaTime�� Update()�Լ� ������ ���
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime; 
        //3.��ġ �̵�(�����̵� Ȥ�� ü�� �� ��ġ �����ϴ� ����)
        rigid.MovePosition(rigid.position + nextVec); //���� rigid�� ��ġ�� inputVec(�̵� ��)�� ����

    }
}
