using UnityEngine;

public class GUIScript : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI timeText;

    private void OnEnable()
    {
        EventManager.Instance.OnScoreChanged += UpdateScore;
        EventManager.Instance.OnSecondPassed += UpdateTime;
    }
    private void OnDisable()
    {
        EventManager.Instance.OnScoreChanged -= UpdateScore;
        EventManager.Instance.OnSecondPassed -= UpdateTime;
    }

    private void UpdateScore()
    {
        scoreText.text = $"Score: {GameManager.Instance.Score}";
    }

    private void UpdateTime()
    {
        timeText.text = GameManager.Instance.timeString;
    }
}
