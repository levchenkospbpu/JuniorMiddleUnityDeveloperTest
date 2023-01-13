using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public Action timeChanged;

    public float TimeInRun { get; private set; }
    public bool Running { get; private set; }

    [SerializeField] private StartButton _startButton;
    [SerializeField] private FinishButton _finishButton;

    private void OnEnable()
    {
        _startButton.pressed += StartRun;
        _finishButton.pressed += FinishRun;
    }

    private void OnDisable()
    {
        _startButton.pressed -= StartRun;
        _finishButton.pressed -= FinishRun;
    }

    private void Update()
    {
        if (Running)
        {
            TimeInRun += Time.deltaTime;
            timeChanged?.Invoke();
        }
    }

    private void StartRun()
    {
        TimeInRun = 0;
        Running = true;
    }

    private void FinishRun()
    {
        Running = false;
    }

    public void Reload()
    {
        SceneManager.LoadScene(0);
    }
}
