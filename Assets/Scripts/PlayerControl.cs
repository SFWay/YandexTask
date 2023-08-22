using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //�� ������� ����� ����� �� ����� �� ��� X � ��������� ������ ����� � ���� ������ 
    //������������� � ������������� ���������� (������������� �����������)
    //���� ������ �������� ����� ���������������� � �� ��������� Webgl
   
    Rigidbody2D rb;

    public GameObject Tail; //���� ��������� ������� ������
    
    public int Score = 0;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //������ � ����������� ������ ��� ��������� � ���������� ������� ��� ���
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) rb.gravityScale = -2;
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Mouse0)) rb.gravityScale = 2;

       

       


    }
    private void FixedUpdate()
    {
        //��� � N ������� ������� ��������������� ������� ������
        Instantiate(Tail, transform.position, Quaternion.identity); 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //���� ������������ � ��������, �� ���������� �� � �������� ����
        if (collision.tag == "Coin")
        {
            Score++;
            Destroy(collision.gameObject);
        }
        //���� ������������ � ������������ - ������������� ������� ������
        if (collision.tag == "Obstacle" || collision.tag == "Border")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

}


