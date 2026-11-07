using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int Score;
    public Stopwatch stopWatch = new Stopwatch();
    public string timeString;
    public bool TimerActive = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        stopWatch.Start();
    }

    private void Update()
    {
        Timer();
    }

    public void ScoreAchieved()
    {
        Score += 1;
        EventManager.Instance.ScoreChanged();
    }

    public void Timer()
    {
        timeString = $"{stopWatch.Elapsed.Minutes:D2}:{stopWatch.Elapsed.Seconds:D2}";
        EventManager.Instance.SecondPassed();
    }
}
