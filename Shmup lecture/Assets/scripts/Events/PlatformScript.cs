using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public bool Used = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !Used)
        {
            GameManager.Instance.ScoreAchieved();
            Used = true;
        }
    }
}
