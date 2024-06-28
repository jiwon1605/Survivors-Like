using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 inputVec; //키 이동 변수
    Rigidbody2D rigid; //물리 이동 변수
    public float speed; //속도

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>(); //유니티 엔진 상 Rigidbody2D가 rigid라는 변수로 들어가게 됨
    }

    // Update is called once per frame
    void Update()
    {

        //GetAxis는 값을 보정해줘 입력값이 부드러워짐(미끄러지듯 보임)
        inputVec.x = Input.GetAxisRaw("Horizontal"); 
        inputVec.y = Input.GetAxisRaw("Vertical"); 
    }

    private void FixedUpdate()
    {
        //1.힘을 준다
        //rigid.AddForce(inputVec);

        //2.속도 제어
        //rigid.velocity = inputVec;

        //벡터 값의 크기가 1이 되도록 좌표가 수정된 값(피타고라스에 의한 대각선 길이가 1이 아님을 보완해줌)
        //DeltaTime은 Update()함수 내에서 사용
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime; 
        //3.위치 이동(순간이동 혹은 체스 말 위치 변경하는 느낌)
        rigid.MovePosition(rigid.position + nextVec); //현재 rigid의 위치에 inputVec(이동 값)을 더함

    }
}
