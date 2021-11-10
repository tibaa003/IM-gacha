using UnityEngine;

public class Countdown : MonoBehaviour
{
	private Bar _timeBar;
	private float _maxTime = 60;
	private float _curTime;
	public bool running;
	public float multiplier = 1;
	public float maxTime
	{
		get
		{
			return _maxTime;
		}
		set
		{
			_maxTime = value;
			_curTime = maxTime;
			_timeBar.maxValue = _maxTime;
		}
	}
	public float curTime
	{
		get
		{
			return _curTime;
		}
		set
		{
			_curTime = value;
			_timeBar.value = _curTime;
		}
	}
	void Start()
	{
		_timeBar = gameObject.GetComponent<Bar>();
		_curTime = _maxTime;
		_timeBar.maxValue = maxTime;
	}

	void Update()
	{
		if (running)
		{
			curTime -= multiplier * Time.deltaTime;
		}
	}
}
