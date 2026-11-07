using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }
    public event Action OnScoreChanged;
    public event Action OnSecondPassed;

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
    public void ScoreChanged() => OnScoreChanged?.Invoke();
    public void SecondPassed() => OnSecondPassed?.Invoke();

    //public void ScoreChanged()          <-- samma grej som ovan ofc
    //{
    //  OnScoreChanged?.Invoke();
    //}
}
