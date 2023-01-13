using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _timeTextObj;
    [SerializeField] private GameObject _tipTextObj;
    [SerializeField] private GameObject _resultsSVObj;
    [SerializeField] private GameObject _tryAgainObj;
    [SerializeField] private Transform _resultsSVContent;

    [SerializeField] private StartButton _startButton;
    [SerializeField] private FinishButton _finishButton;

    [SerializeField] private GameObject _resultPrefab;

    private void OnEnable()
    {
        _startButton.inRange += () =>
        {
            Show(_tipTextObj);
        };
        _startButton.outOfRange += () =>
        {
            Hide(_tipTextObj);
        };
        _startButton.pressed += () =>
        {
            Hide(_tipTextObj);
            Show(_timeTextObj);
        };
        _finishButton.inRange += () =>
        {
            Show(_tipTextObj);
        };
        _finishButton.outOfRange += () =>
        {
            Hide(_tipTextObj);
        };
        _finishButton.pressed += () =>
        {
            Hide(_tipTextObj);
            Hide(_timeTextObj);
            Show(_resultsSVObj);
            Show(_tryAgainObj);
            ClearResultsContent();
            FillResultsContent();
        };
    }

    private void OnDisable()
    {
        _startButton.inRange -= () =>
        {
            Show(_tipTextObj);
        };
        _startButton.outOfRange -= () =>
        {
            Hide(_tipTextObj);
        };
        _startButton.pressed -= () =>
        {
            Hide(_tipTextObj);
            Show(_timeTextObj);
        };
        _finishButton.inRange -= () =>
        {
            Show(_tipTextObj);
        };
        _finishButton.outOfRange -= () =>
        {
            Hide(_tipTextObj);
        };
        _finishButton.pressed -= () =>
        {
            Hide(_tipTextObj);
            Hide(_timeTextObj);
            Show(_resultsSVObj);
            ClearResultsContent();
            FillResultsContent();
        };
    }

    private void FillResultsContent()
    {
        ResultList.SetLastTime(GameManager.Instance.TimeInRun);
        ResultList.Results.Add(GameManager.Instance.TimeInRun);
        ResultList.Results.Sort();
        foreach (float resultTime in ResultList.Results)
        {
            ResultPanel result = Instantiate(_resultPrefab, _resultsSVContent).GetComponent<ResultPanel>();
            result.SetText(resultTime.ToString("0.00"));
            if (resultTime == ResultList.LastTime)
            {
                result.SetAsLast();
            }
        }
    }

    private void ClearResultsContent()
    {
        foreach (Transform child in _resultsSVContent)
        {
            Destroy(child.gameObject);
        }
    }

    private void Show(GameObject obj)
    {
        obj.SetActive(true);
    }

    private void Hide(GameObject obj)
    {
        obj.SetActive(false);
    }
}
