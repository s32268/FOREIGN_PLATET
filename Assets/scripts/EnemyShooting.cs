using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        //shooting range dla przeciwnika
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        //shooting range i wykrywanie gracza
        float distance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log(distance); //zeby znac dystans

        if(distance < 10)
        {
             timer += Time.deltaTime;

            //timer strzałów
            if(timer > 2)
            {
                timer = 0;
                shoot();
            }
        }


    
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
