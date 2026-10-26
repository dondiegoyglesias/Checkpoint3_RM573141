using System.Collections;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    [Header("Move Settings")]
    [SerializeField] float speed;

    [SerializeField] private GameObject player;
    [SerializeField] private float distanceWakeUp;
    [SerializeField] private float distanceAttack;

    [SerializeField] Vector3 posicaoInicial;
    
    private bool attacking;
    private bool wakeUp;

    Collider2D collision;
    Animator animator;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {

        if (wakeUp == false)
        {
            if (Vector2.Distance(transform.position, player.transform.position) < distanceWakeUp)
            {
                wakeUp = true;
            }

        }

        {
            if (Vector2.Distance(transform.position, player.transform.position) < distanceAttack)
            {
                Attack();
            }
            else if (Vector2.Distance(transform.position, player.transform.position) > distanceWakeUp)
            {
                transform.position = Vector3.MoveTowards(transform.position, posicaoInicial, speed * Time.deltaTime);
            }
            else 
            {
                Move();
            }

            /*if(Vector2.Distance(transform.position,player.transform.position) > distanceWakeUp)
            {
                transform.position = Vector3.MoveTowards(transform.position,posicaoInicial, speed * Time.deltaTime);
            }*/


        }
        Look();
        AnimatorManager();
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position,player.gameObject.transform.position, speed * Time.deltaTime);
    }

    void Look()
    {
        if (player.gameObject.transform.position.x < transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else if (player.gameObject.transform.position.x > transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
    }

    void Attack()
    {
        StartCoroutine(Attacking());

    }

    IEnumerator Attacking()
    {
        attacking = true;
        yield return new WaitForSeconds(0.75f);
        attacking = false;
    }



    void AnimatorManager()
    {
        animator.SetBool("pAttack", attacking);
        animator.SetBool("pWakeUp", wakeUp);
    }
}
