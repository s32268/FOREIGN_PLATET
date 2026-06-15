using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public GameObject player;
    private float distance = 1000;
    
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        //shooting range i wykrywanie gracza
        distance = Vector2.Distance(transform.position, player.transform.position);
        

        if(distance < 70) //co zrobić żeby preciwnik z góry nie strzelali
        { 
            
             timer += Time.deltaTime;

            //timer strzałów
            if(timer > 3)
            {
                Debug.Log(timer);
                timer = 0;
                shoot();
            }
        }


    
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

     void OnDrawGizmos()
    {
        if(distance < 100)
        {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, player.transform.position);
        }
    }
}
