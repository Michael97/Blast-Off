using System;

namespace UnityEngine.Advertisements
{
    /// <summary>
    /// Collection of options that can be passed to [[Advertisements.Banner.Show]] to be notified of events within the banner.
    /// </summary>
    public class BannerOptions
    {
        public delegate void BannerCallback();

        /// <summary>
        /// Callback that is fired when when the banner is visible to the gamer.
        /// </summary>
        public BannerCallback showCallback { get; set; }

        /// <summary>
        /// Callback that is fired when the banner is hidden to the gamer.
        /// </summary>
        public BannerCallback hideCallback { get; set; }
    }

    /// <summary>
    /// Options that can be passed to [[[]]]
    /// </summary>
    public class BannerLoadOptions
    {
        public delegate void LoadCallback();
        public delegate void ErrorCallback(string message);

        /// <summary>
        /// Callback that is fired when when the banner is loaded and available to show.
        /// </summary>
        public LoadCallback loadCallback { get; set; }

        /// <summary>
        /// Callback that is fired when an error occurs during banner loading.
        /// If this callback is invoked, one should assume that the banner is not loaded and one may call Load again
        /// at a later point in time.
        /// </summary>
        public ErrorCallback errorCallback { get; set; }
    }
}
