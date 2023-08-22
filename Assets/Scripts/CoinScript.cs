using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    bool ISeeAPlayer = false; //переменна€, передающа€, видит ли монетка игрока
    Transform Player; //тут позици€ игрока
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Player = GameObject.Find("Player").transform; //находим игрока по имени на сцене и передаем его координаты
        //если позици€ игрока находитс€ в радиусе (2) от монетки, то монетка ¬»ƒ»“ игрока
        if (Mathf.Abs(Player.position.x - transform.position.x) < 2 && Mathf.Abs(Player.position.y - transform.position.y) < 2) ISeeAPlayer = true;
        else ISeeAPlayer = false;
        //если монетка видит игрока, то плавно перемещаетс€ к нему (учитыва€, что игрок "летит вперед"
        if (ISeeAPlayer)
        {
            rb.MovePosition(transform.position + new Vector3((Player.position.x - transform.position.x) / 80 - 0.07f, (Player.position.y - transform.position.y) / 80, 0f));
        }
        //если не видит, то просто продолжает движение влево
        else rb.MovePosition(transform.position + new Vector3(-0.07f, 0, 0));
    }

    //≈сли монетка пересекаетс€ с триггером дл€ уничтожени€ слева, то уничтожаем ее
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Destroyer") Destroy(gameObject);
    }
}
