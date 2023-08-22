using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailScript : MonoBehaviour
{
    float TailLenght = 0.02f; //изменить для разной длины хвоста
    SpriteRenderer SR;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        gameObject.transform.parent = null; //избавляемся от "головы" чтобы хвост был самостоятельным

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + new Vector3(-0.07f, 0, 0)); //двигаем хвост влево
        SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, SR.color.a - 0.001f); //чем дальше элемент хвоста, тем меньше его прозрачность
        transform.localScale = new Vector3(transform.lossyScale.x - (TailLenght / 3f), transform.lossyScale.y - (TailLenght / 3f), transform.localScale.z); //чем дальше элемент хвоста, тем меньше его размер
        if (transform.localScale.x < 0f) Destroy(gameObject); //если размер элемента хвоста оказался отрицательным - удаляем его
    }
}
