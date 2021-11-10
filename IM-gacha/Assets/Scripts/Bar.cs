using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
	private Slider _slider;

	public float maxValue
	{
		get
		{
			return _slider.maxValue;
		}
		set
		{
			_slider.maxValue = value;
			_slider.value = value;
		}
	}
	public float value
	{
		get
		{
			return _slider.value;
		}
		set
		{
			_slider.value = value;
		}
	}

	void OnEnable()
	{
		_slider = gameObject.GetComponent<Slider>();
	}
}
