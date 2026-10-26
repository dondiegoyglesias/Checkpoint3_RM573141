using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("Move Settigns")]
    [SerializeField] float speed;
    private Vector2 direction;


    Animator animator;
    Rigidbody2D rigidbody2D;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        rigidbody2D.gravityScale = 0.0f;
        rigidbody2D.freezeRotation = true;
    }


    void Update()
    {
        Move();
        AnimatorManager();
    }

    void FixedUpdate()
    {
        OnMove();
    }

    void Move()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (direction.x > 0)
        {
            transform.localScale = new Vector2(direction.x, 1);
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector2(direction.x, 1);
        }
    }

    void OnMove()
    {
        rigidbody2D.linearVelocity = direction.normalized * speed;
    }

    void AnimatorManager()
    {
        animator.SetInteger("pMove", (int)(Mathf.Abs(direction.x) + Mathf.Abs(direction.y)));
    }
}
