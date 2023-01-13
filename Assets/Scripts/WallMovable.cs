using System.Collections;
using UnityEngine;

public class WallMovable : MonoBehaviour
{
	[SerializeField] private bool _isRandom = true;
	[SerializeField] private float _speed = 2f;

	private bool _isDown = false;
	private float _height;
	private float _posYDown;
	private bool _isWaiting = false;
	private bool _canChange = true;

	void Awake()
    {
		_height = transform.localScale.y;
		if (_isDown)
		{
			_posYDown = transform.position.y;
		}
		else
		{
			_posYDown = transform.position.y - _height;
		}
	}

    void Update()
    {
		if (_isDown)
		{
			if (transform.position.y < _posYDown + _height)
			{
				transform.position += Vector3.up * Time.deltaTime * _speed;
			}
			else if (!_isWaiting)
            {
				StartCoroutine(WaitToChange(1f));
			}
		}
		else
		{
			if (!_canChange)
			{
				return;
			}
			if (transform.position.y > _posYDown)
			{
				transform.position -= Vector3.up * Time.deltaTime * _speed;
			}
			else if (!_isWaiting)
            {
				StartCoroutine(WaitToChange(1f));
			}
		}
	}

	IEnumerator WaitToChange(float time)
	{
		_isWaiting = true;
		yield return new WaitForSeconds(time);
		_isWaiting = false;
		_isDown = !_isDown;

		if (_isRandom && !_isDown)
		{
			int num = Random.Range(0, 2);
			if (num == 1)
            {
				StartCoroutine(Retry(1.5f));
			}
		}
	}

	IEnumerator Retry(float time)
	{
		_canChange = false;
		yield return new WaitForSeconds(time);
		int num = Random.Range(0, 2);
		if (num == 1)
        {
			StartCoroutine(Retry(1.25f));
		}
		else
        {
			_canChange = true;
		}
	}
}
