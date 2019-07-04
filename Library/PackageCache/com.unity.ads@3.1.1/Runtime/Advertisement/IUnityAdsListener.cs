using System;

namespace UnityEngine.Advertisements
{
    public interface IUnityAdsListener
    {
        void OnUnityAdsReady(string placementId);
        void OnUnityAdsDidError(string message);
        void OnUnityAdsDidStart(string placementId);
        void OnUnityAdsDidFinish(string placementId, ShowResult showResult);
    }
}