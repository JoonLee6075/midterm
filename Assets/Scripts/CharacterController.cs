using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CharacterController : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;
    public int damage;
    public GameManager gm;
   
    public bool isHorizontalMove;
    bool isVerticalMove;
    public SpriteRenderer sr;
    public Animator anim;
    Vector2 movement;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(movement.x < 0)
        {
            sr.flipX = true;
            attackPoint.position = transform.position - new Vector3(0.7f, 0, 0);
        }
        if(movement.x > 0)
        {
            sr.flipX = false;
            attackPoint.position = transform.position + new Vector3(0.7f, 0, 0);
        }


        if (Input.GetKeyDown(KeyCode.J))
        {
            anim.SetTrigger("isAttack"); 

        }
       
    }
    void FixedUpdate()
    {

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        if(Mathf.Abs(movement.x) > 0 || Mathf.Abs(movement.y) > 0)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }

    public void Attack()
    {
        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange , enemyLayers); 

        foreach(Collider2D enemy in hitEnemies)
        {
            
            enemy.GetComponent<EnemyScript>().TakeDamage(damage);
            enemy.GetComponent<EnemyScriptTwo>().TakeDamage(damage);

        }
    }
}
