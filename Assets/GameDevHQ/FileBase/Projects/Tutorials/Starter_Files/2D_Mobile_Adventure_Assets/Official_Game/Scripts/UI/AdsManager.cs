using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    [SerializeField] private int _rewardedAdValue = 100;
    public void ShowRewardedAd()
    {
        // Check if ad is ready
        if (Advertisement.IsReady("Rewarded_Android"))
        {
            var options = new ShowOptions
            {
                resultCallback = HandleShowResult
            };

            Advertisement.Show("Rewarded_Android", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Failed:
                Debug.Log("Ad failed.");
                break;
            case ShowResult.Skipped:
                Debug.Log("Ad was skipped.");
                break;
            case ShowResult.Finished:
                GameManager.Instance.Player.AddDiamonds(_rewardedAdValue);
                break;
            default:
                break;
        }
    }
}
