using UnityEngine;

public class BallController : MonoBehaviour
{

    const float InitialSpeed = 3f;

    Vector2 speed = new Vector2(1f, 1f);

    private Rigidbody2D body;
    private CircleCollider2D ballCollider;
    float max;
    float min;

    void Start()
    {
        speed = InitialSpeed * speed;

        body = GetComponent<Rigidbody2D>();
        ballCollider = GetComponent<CircleCollider2D>();

        float ballSize = ballCollider.radius / 2;
        max = Camera.main.transform.position.y + Camera.main.orthographicSize - ballSize;
        min = Camera.main.transform.position.y - Camera.main.orthographicSize + ballSize;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Paddle")
        {
            speed.x *= -1;
        }
    }

    void FixedUpdate()
    {
        if (transform.position.y > max || transform.position.y < min)
        {
            speed.y *= -1;
        }
        body.linearVelocity = speed;
    }

    public void Reset() {
        this.transform.position = Vector2.zero;
    }
}
