using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptTwo : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float health;
    public GameObject reward;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        


        if (transform.position.x - target.position.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }


        if(health <= 0)
        {
            Destroy(gameObject);
            Instantiate(reward, gameObject.transform.position , reward.transform.rotation);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    
}
