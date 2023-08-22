using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    //�������� ������� ��� ������� � �����������, �� Webgl �����, ��� ���������� ��� ������
    //� ������� ����������� ���� �������� ����� � ����
    Animator an;
    //���� �� ���������� � ������� � ��� ������ ����������� �������� �� ���������� ������� ������� �������� ��� ������������ �����������
    void Start()
    {
        an = GetComponent<Animator>();
        AnimatorClipInfo[] clips = an.GetCurrentAnimatorClipInfo(0);
        an.Play(clips[0].clip.name, 0, Random.RandomRange(0f, 3f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //����� ����� ������� ��� ����������� ���������� �����������, ����� ����������� ���������� ���, �� ������������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Destroyer") Destroy(transform.parent.gameObject);
    }
}
