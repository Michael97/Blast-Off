using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdvertController : MonoBehaviour
{
    public string gameId;
    public string placementId;
    public bool testMode = true;

    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
        StartCoroutine(ShowBannerWhenReady());
    }

    public void ShowAd()
    {
        Advertisement.Show();
    }

    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(placementId))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(placementId);
    }
}