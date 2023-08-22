using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerScript : MonoBehaviour
{
    public Text ScoreText, StartText; //���� ��������� ����� ��� �������� ����� ������� � ��������� �������
    public int Score, TimeForObstacle = 0, TimeForCoin = 0, CountOfObstacle = 1;//���������� ���: �����, ������� ������ �����������, ������� ������ ������� � ���������� �����������
    public GameObject Obstacle, Coin; //���� �������� ������� ����������� � �������

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0; //� ������ ���� ����� �� �����, ��������� ����� ������� ������ ��� ���
        StartText.text = "press SPACEBAR to start";
    }

    // Update is called once per frame
    void Update()
    {
        //���� ����� �� ������ � �� ������ ������ ��� ���, �� ��������� ����� � �������� ����
        if (StartText.text != "" && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))) 
        {
            StartText.text = "";
            Time.timeScale = 1;
        }
    }

    private void FixedUpdate()
    {
        
        Score = GameObject.Find("Player").GetComponent<PlayerControl>().Score; //�������� � ������, ������� ����� �� ������
        ScoreText.text = string.Format("Score: {0}", Score);//������� �� ����� ���������� �����
        // ������� �����, ����� ���������� ��� ������� ��������� 300, ������� X ����������� � ���������� �� ���������� ����� �������� � �������
        TimeForObstacle++;
        if (TimeForObstacle > 300)
        {
            
            CountOfObstacle = (Score + 1) / 2 + 1;
            for (int i = 0; i < CountOfObstacle; i++)
            {
                Instantiate(Obstacle, new Vector3(Random.Range(transform.position.x - 2, transform.position.x + 2), Random.Range(transform.position.y - 3.5f, transform.position.y + 3.5f), 0f), Quaternion.identity); ;
            }
            TimeForObstacle = 0;
            

        }
        //���� ����� ��� � ����, �� ��� ������� � ���� ����
        TimeForCoin++;
        if (TimeForCoin == 400)
        {
            Instantiate(Coin, new Vector3(transform.position.x + 3, Random.Range(transform.position.y - 2f, transform.position.y + 2f), 0f), Quaternion.identity);
            TimeForCoin = 0;
        }
    }

}
