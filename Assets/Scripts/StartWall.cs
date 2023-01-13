using UnityEngine;

public class StartWall : MonoBehaviour
{
    [SerializeField] private StartButton _startButton;

    private void OnEnable()
    {
        _startButton.pressed += () =>
        {
            GetComponent<WallMovable>().enabled = true;
        };
    }

    private void OnDisable()
    {
        _startButton.pressed -= () =>
        {
            GetComponent<WallMovable>().enabled = true;
        };
    }
}
