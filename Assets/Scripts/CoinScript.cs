using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    bool ISeeAPlayer = false; //����������, ����������, ����� �� ������� ������
    Transform Player; //��� ������� ������
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Player = GameObject.Find("Player").transform; //������� ������ �� ����� �� ����� � �������� ��� ����������
        //���� ������� ������ ��������� � ������� (2) �� �������, �� ������� ����� ������
        if (Mathf.Abs(Player.position.x - transform.position.x) < 2 && Mathf.Abs(Player.position.y - transform.position.y) < 2) ISeeAPlayer = true;
        else ISeeAPlayer = false;
        //���� ������� ����� ������, �� ������ ������������ � ���� (��������, ��� ����� "����� ������"
        if (ISeeAPlayer)
        {
            rb.MovePosition(transform.position + new Vector3((Player.position.x - transform.position.x) / 80 - 0.07f, (Player.position.y - transform.position.y) / 80, 0f));
        }
        //���� �� �����, �� ������ ���������� �������� �����
        else rb.MovePosition(transform.position + new Vector3(-0.07f, 0, 0));
    }

    //���� ������� ������������ � ��������� ��� ����������� �����, �� ���������� ��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Destroyer") Destroy(gameObject);
    }
}
