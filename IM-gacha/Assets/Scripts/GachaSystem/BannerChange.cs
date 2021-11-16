using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerChange : MonoBehaviour
{
    public GameObject banner1;
    public GameObject banner2;
    public GameObject banner3;


    public void changeBanner(GameObject banner) {
        banner1.SetActive(false);
        banner2.SetActive(false);
        banner3.SetActive(false);
        banner.SetActive(true);
    }
}
