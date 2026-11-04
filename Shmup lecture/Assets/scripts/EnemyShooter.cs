using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform PewPew;
    public float BulletInterval = 1.5f;
    public float Speed = 5f;
    private float timer;

    private void OnEnable()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= BulletInterval)
        {
            Shoot();
            timer = 0;
        }
    }

    private void Shoot()
    {
        GameObject b = Instantiate(BulletPrefab, PewPew.position , Quaternion.identity);

        b.GetComponent<Rigidbody2D>().linearVelocity = Vector2.down * Speed;
        Destroy( b, 5f );
    }
}
