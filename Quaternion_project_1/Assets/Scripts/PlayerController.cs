using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;        // �÷��̾ �̵���Ű�� ���� RigidBody
    public int moveSpeed = 10;       // �÷��̾��� �̵��ӵ�


    void Start()
    {
        rb = GetComponent<Rigidbody>();     // rb�� ������Ʈ �ȿ� �ִ� rigidBody�� �־���
    }

    void Update()
    {
        /*PlayerMove01();*/
        PlayerMove02();
    }

    public void PlayerMove01()      // �÷��̾��� ��ġ�� �ٲپ� �̵���Ű�� ����� �Լ�( RigidBody ��� ��밡�� )
    {    
        Vector3 moveInput = Vector3.zero;       // new Vecter3(0.0.0) �� ����
        //Vector3 moveInput = new Vector3(0,0,0);   

        moveInput.x = Input.GetAxisRaw("Horizontal");       // �¿� �̵� �Է��� �޾ƿ�  Raw ���� -1, 0, 1 �� ��� (���ӵ��� ���� ����)
        moveInput.y = Input.GetAxisRaw("Vertical");       // ���� �̵� �Է��� �޾ƿ�    Raw ���Ž� ���ӵ��� �޵��� ���� ����

        moveInput.Normalize();      // �밢�� ���� ����
        transform.position += moveInput * moveSpeed * Time.deltaTime;        // �÷��̾��� ������Ʈ�� �̵�
    }

    public void PlayerMove02()      //������Ʈ�� RigidBody �� ����ϴ� �ڵ�
    {
        Vector3 moveInput = Vector3.zero;

        moveInput.x = Input.GetAxisRaw("Horizontal");      
        moveInput.y = Input.GetAxisRaw("Vertical");     

        moveInput.Normalize();      
        rb.velocity = moveInput * moveSpeed;
    }
}
