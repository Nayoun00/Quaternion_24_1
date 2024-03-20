using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;        // 플레이어를 이동시키기 위한 RigidBody
    public int moveSpeed = 10;       // 플레이어의 이동속도


    void Start()
    {
        rb = GetComponent<Rigidbody>();     // rb에 오브젝트 안에 있는 rigidBody를 넣어줌
    }

    void Update()
    {
        /*PlayerMove01();*/
        PlayerMove02();
    }

    public void PlayerMove01()      // 플레이어의 위치를 바꾸어 이동시키게 만드는 함수( RigidBody 없어도 사용가능 )
    {    
        Vector3 moveInput = Vector3.zero;       // new Vecter3(0.0.0) 과 동일
        //Vector3 moveInput = new Vector3(0,0,0);   

        moveInput.x = Input.GetAxisRaw("Horizontal");       // 좌우 이동 입력을 받아옴  Raw 사용시 -1, 0, 1 만 사용 (가속도를 받지 않음)
        moveInput.y = Input.GetAxisRaw("Vertical");       // 상하 이동 입력을 받아옴    Raw 제거시 가속도를 받도록 설정 가능

        moveInput.Normalize();      // 대각선 가속 방지
        transform.position += moveInput * moveSpeed * Time.deltaTime;        // 플레이어의 오브젝트를 이동
    }

    public void PlayerMove02()      //오브젝트에 RigidBody 를 사용하는 코드
    {
        Vector3 moveInput = Vector3.zero;

        moveInput.x = Input.GetAxisRaw("Horizontal");      
        moveInput.y = Input.GetAxisRaw("Vertical");     

        moveInput.Normalize();      
        rb.velocity = moveInput * moveSpeed;
    }
}
