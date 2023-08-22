using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //по задумке игрок стоит на месте по оси X и двигается только вверх и вниз силами 
    //отрицательной и положительной гравитации (переключается управлением)
    //этот способ оказался более оптимизированным и не нагружает Webgl
   
    Rigidbody2D rb;

    public GameObject Tail; //сюда поместить элемент хвоста
    
    public int Score = 0;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //играем с притяжением игрока при нажимании и отпускании пробела или ЛКМ
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) rb.gravityScale = -2;
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Mouse0)) rb.gravityScale = 2;

       

       


    }
    private void FixedUpdate()
    {
        //раз в N времени спавним самостоятельный элемент хвоста
        Instantiate(Tail, transform.position, Quaternion.identity); 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //если пересекаемся с монеткой, то уничтожаем ее и собираем очки
        if (collision.tag == "Coin")
        {
            Score++;
            Destroy(collision.gameObject);
        }
        //если пересекаемся с препятствием - перезапускаем уровень заново
        if (collision.tag == "Obstacle" || collision.tag == "Border")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

}


