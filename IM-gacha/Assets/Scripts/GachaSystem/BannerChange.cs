using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerChange : MonoBehaviour
{
	public List<GameObject> banners;
	public void changeBanner(GameObject banner) {
		foreach(GameObject ban in banners){
			ban.SetActive(ban == banner);
		}
	}
}
