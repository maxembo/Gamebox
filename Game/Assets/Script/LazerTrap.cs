using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerTrap : MonoBehaviour
{
    [SerializeField] private Health damage;

    private Vector3 current_position;
    private float direction = 1.0f;
    float speed = 1.5f;
    float heightlimit = 2f;
    float timecount = 0.0f;
    float timelimit = 1f;

    void Start()
    {
        current_position = this.transform.position;
    }

    void Update()
    {

        transform.Translate(0, direction * speed * Time.deltaTime, 0);


        if (transform.position.y > current_position.y + heightlimit)
        {
            direction = -1;
        }
        if (transform.position.y < current_position.y)
        {
            direction = 0;
            timecount = timecount + Time.deltaTime;

            if (timecount > timelimit)
            {
                direction = 1;
                timecount = 0;
            }
        }
    }

       
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Laser")
        {
            damage.health.fillAmount -= 0.001f;
        }
    }
}
      

