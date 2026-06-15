//errors, nie da sie odpalic gry i bullet znima z assetów ale da sie ją wyszukać ???

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody2D rb;
    public float force;
    private float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = Player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    // Update is called once per frame
    void Update()
    {               //znikanie strzałów
        timer += Time.deltaTime;

        if(timer > 10) //numer do zmiany
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) //przy kolizji z graczem zniszczenie
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<CharacterRespawn>().Damage(1);//do odjęcia punktu życia, tylko że jest ref to float health i idk jak to sie u mnie nazywa nie mogę tego znalezc
            Destroy(gameObject);
        }
    }
}
