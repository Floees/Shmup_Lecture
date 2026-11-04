using UnityEngine;

public class EnemyMovement2 : MonoBehaviour
{
    public float Width = 3f;
    public float Height = 2f;
    public float Speed = 1f;
    private Vector3 center;
    private float phase;

    private void Start()
    {
        center = transform.position;
    }
    private void Update()
    {
        phase += Time.deltaTime * Speed;

        float x = Mathf.Sin(phase * 1.5f) * Width; //0
        float y = Mathf.Sin(phase * 2) * Height;

        transform.position = center + new Vector3(x, y, 0f);
    }

}
