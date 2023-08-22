using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerScript : MonoBehaviour
{
    public Text ScoreText, StartText; //сюда поместить текст для подсчета очков игроком и начальная надпись
    public int Score, TimeForObstacle = 0, TimeForCoin = 0, CountOfObstacle = 1;//переменные для: Очков, времени спавна препятствий, времени спавна монеток и количества препятствий
    public GameObject Obstacle, Coin; //сюда помещаем префабы препятствия и монетки

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0; //в начале игра стоит на паузе, стартанет после нажатия пробел или ЛКМ
        StartText.text = "press SPACEBAR to start";
    }

    // Update is called once per frame
    void Update()
    {
        //если текст не пустой и мы нажали пробел или ЛКМ, то запускаем время и стартуем игру
        if (StartText.text != "" && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))) 
        {
            StartText.text = "";
            Time.timeScale = 1;
        }
    }

    private void FixedUpdate()
    {
        
        Score = GameObject.Find("Player").GetComponent<PlayerControl>().Score; //забираем у игрока, сколько очков он собрал
        ScoreText.text = string.Format("Score: {0}", Score);//выводим на текст количество очков
        // считаем время, когда переменная для времени превышает 300, спавним X препятствий в зависмости от количества очков рандомно в области
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
        //тоже самое что и выше, но для монетки и чуть реже
        TimeForCoin++;
        if (TimeForCoin == 400)
        {
            Instantiate(Coin, new Vector3(transform.position.x + 3, Random.Range(transform.position.y - 2f, transform.position.y + 2f), 0f), Quaternion.identity);
            TimeForCoin = 0;
        }
    }

}
