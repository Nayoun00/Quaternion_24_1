using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;        // �÷��̾ �̵���Ű�� ���� RigidBody
    public StatData player;
    public GameObject bullet;

    void Start()
    {
        rb = GetComponent<Rigidbody>();     // rb�� ������Ʈ �ȿ� �ִ� rigidBody�� �־���
        player = Managers.Data.Setting(true, 5, 5, 1, 1, 5);
    }

    void Update()
    {
        /*PlayerMove01();*/
        PlayerMove02();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireProjectile();
        }
    }
    public void FireProjectile()
    {
        GameObject temp = Managers.Pool.Pop(bullet);
        BulletController bc =temp.GetComponent<BulletController>();

        temp.transform.position = this.gameObject.transform.position;
        bc.direction = Vector3.forward;
        bc.damage = player.bulletDMG;
        bc.moveSpeed = player.bulletLevel;

    }


    public void PlayerMove01()      // �÷��̾��� ��ġ�� �ٲپ� �̵���Ű�� ����� �Լ�( RigidBody ��� ��밡�� )
    {    
        Vector3 moveInput = Vector3.zero;       // new Vecter3(0.0.0) �� ����
        //Vector3 moveInput = new Vector3(0,0,0);   

        moveInput.x = Input.GetAxisRaw("Horizontal");       // �¿� �̵� �Է��� �޾ƿ�  Raw ���� -1, 0, 1 �� ��� (���ӵ��� ���� ����)
        moveInput.z = Input.GetAxisRaw("Vertical");       // ���� �̵� �Է��� �޾ƿ�    Raw ���Ž� ���ӵ��� �޵��� ���� ����

        moveInput.Normalize();      // �밢�� ���� ����
        transform.position += moveInput * player.moveSpeed * Time.deltaTime;        // �÷��̾��� ������Ʈ�� �̵�
    }

    public void PlayerMove02()      //������Ʈ�� RigidBody �� ����ϴ� �ڵ�
    {
        Vector3 moveInput = Vector3.zero;

        moveInput.x = Input.GetAxisRaw("Horizontal");      
        moveInput.z = Input.GetAxisRaw("Vertical");     

        moveInput.Normalize();      
        rb.velocity = moveInput * player.moveSpeed;
    }
}
