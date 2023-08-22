using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    //хотелось сделать все красиво и математикой, но Webgl решил, что математика это сложно
    //У каждого препятствия есть анимация Вверх и Вниз
    Animator an;
    //ниже мы обращаемся к анимаци и при спавне препятствия начинаем со случайного отрезка времени анимации для разнообразия препятствий
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

    //слева стоит триггер для уничтожения пройденных препятствий, когда препятствие пересекает его, то уничтожается
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Destroyer") Destroy(transform.parent.gameObject);
    }
}
