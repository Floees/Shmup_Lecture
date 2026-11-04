using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public bool Wave;
    public Transform PointA;
    public Transform PointB;

    public float Speed = 2f;
    public float Amplitude = 1f;
    public float Frequency = 1f;
    private Rigidbody2D RB;
    private float elapsed;
    private float distance;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        elapsed = 0f;
        distance = Vector2.Distance(PointA.position, PointB.position);
    }

    private void FixedUpdate()
    {
        elapsed += Time.fixedDeltaTime;
        Move();

    }

    private void Move()
    {
        if (distance == 0)
            return;

        float t = Mathf.PingPong(elapsed * Speed / distance, 1f);

        Vector2 position = Vector2.Lerp(PointA.position, PointB.position, t);

        if (Wave)
            position.x += Mathf.Sin(elapsed * Frequency) * Amplitude;
        
        RB.MovePosition(position);
    
    }
}
