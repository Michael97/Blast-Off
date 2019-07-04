using System;

namespace UnityEngine.Advertisements
{
    /// <summary>
    /// Unity Ads Asset Store Package
    /// </summary>
    public static class Advertisement
    {
        static bool s_Initialized;
        static bool s_Showing;

        static IPlatform s_Platform;

        static IUnityEngineApplication s_UnityEngineApplication;

        // Duplicated to avoid generating obsolete warnings from using DebugLevel internally
        [Flags]
        enum DebugLevelInternal
        {
            None = 0,
            Error = 1,
            Warning = 2,
            Info = 4,
            Debug = 8
        }

        static internal IPlatform platform
        {
            get { return s_Platform; }
            set { s_Platform = value; }
        }

        static internal IUnityEngineApplication application
        {
            get { return s_UnityEngineApplication; }
            set { s_UnityEngineApplication = value; }
        }

        /// <summary>
        /// Returns whether the advertisement system is initialized successfully.
        /// </summary>
        public static bool isInitialized
        {
            get
            {
                return s_Initialized;
            }
            internal set
            {
                s_Initialized = value;
            }
        }

        /// <summary>
        /// Returns if the current platform is supported by the advertisement system.
        /// </summary>
        public static bool isSupported
        {
            get
            {
                bool supported = application.isEditor ||
                    (application.platform == RuntimePlatform.Android && s_Platform.isSupported) ||
                    (application.platform == RuntimePlatform.IPhonePlayer && s_Platform.isSupported);


                return supported;
            }
        }

        /// <summary>
        /// Controls the amount of logging output from the advertisement system.
        /// </summary>
        public static bool debugMode
        {
            get
            {
                return s_Platform.debugMode;
            }
            set
            {
                s_Platform.debugMode = value;
            }
        }

        /// <summary>
        /// Returns the current Unity Ads version.
        /// </summary>
        public static string version
        {
            get
            {
                return s_Platform.version;
            }
        }

        /// <summary>
        /// Returns if an advertisement is currently showing.
        /// </summary>
        public static bool isShowing
        {
            get
            {
                return s_Showing;
            }
            internal set
            {
                s_Showing = value;
            }
        }

        static Advertisement()
        {
            s_UnityEngineApplication = new UnityEngineApplication();
            s_Platform = Creator.CreatePlatform();
        }

        /// <summary>
        /// Initializes the advertisement system.
        /// </summary>
        /// <param name="gameId">Game identifier.</param>
        public static void Initialize(string gameId)
        {
            Initialize(gameId, false);
        }

        /// <summary>
        /// Initialize the advertisement system with specified gameId and testMode.
        /// </summary>
        /// <param name="gameId">Game identifier.</param>
        /// <param name="testMode">Test mode.</param>
        public static void Initialize(string gameId, bool testMode)
        {
            if (!isInitialized)
            {
                isInitialized = true;

                s_Platform.OnStart += (object sender, StartEventArgs e) =>
                {
                    isShowing = true;
                };
                s_Platform.OnFinish += (object sender, FinishEventArgs e) =>
                {
                    isShowing = false;
                };

                var framework = new MetaData("framework");
                framework.Set("name", "Unity");
                framework.Set("version", application.unityVersion);
                SetMetaData(framework);

                var adapter = new MetaData("adapter");
#if ASSET_STORE
                adapter.Set("name", "AssetStore");
#else
                adapter.Set("name", "Packman");
#endif
                adapter.Set("version", version);
                SetMetaData(adapter);

                s_Platform.Initialize(gameId, testMode);
            }
        }

        /// <summary>
        /// Returns whether an advertisement is ready to be shown for the default placement. Placements are configured per game in the UnityAds admin site, where you can also set your default placement.
        /// </summary>
        public static bool IsReady()
        {
            return IsReady(null);
        }

        /// <summary>
        /// Returns whether an advertisement is ready to be shown for specified placement. Placements are configured per game in the UnityAds admin site.
        /// </summary>
        /// <param name="placementId">Placement identifier.</param>
        public static bool IsReady(string placementId)
        {
            return s_Platform.IsReady(string.IsNullOrEmpty(placementId) ? null : placementId);
        }

        /// <summary>
        /// Returns the state of the default placement.
        /// </summary>
        public static PlacementState GetPlacementState()
        {
            return GetPlacementState(null);
        }

        /// <summary>
        /// Returns the state of specified placement.
        /// </summary>
        /// <param name="placementId">Placement identifier.</param>
        public static PlacementState GetPlacementState(string placementId)
        {
            return s_Platform.GetPlacementState(string.IsNullOrEmpty(placementId) ? null : placementId);
        }

        /// <summary>
        /// Show the default placement if it is ready.
        /// </summary>
        public static void Show()
        {
            Show(null, null);
        }

        /// <summary>
        /// Show the default placement if it is ready and returns the result in name="finishCallback".
        /// </summary>
        /// <param name="showOptions">Various show options, including resultCallback.</param>
        public static void Show(ShowOptions showOptions)
        {
            Show(null, showOptions);
        }

        /// <summary>
        /// Show the specified placement if it is ready.
        /// </summary>
        /// <param name="placementId">Placement identifier.</param>
        public static void Show(string placementId)
        {
            Show(placementId, null);
        }

        /// <summary>
        /// Show the specified placement if it is ready and returns the result in name="finishCallback".
        /// </summary>
        /// <param name="placementId">Placement identifier.</param>
        /// <param name="showOptions">Various show options, including resultCallback.</param>
        public static void Show(string placementId, ShowOptions showOptions)
        {
            if (isShowing)
            {
                return;
            }

            if (showOptions != null)
            {
#pragma warning disable 618
                if (showOptions.resultCallback != null)
                {
                    EventHandler<FinishEventArgs> finishHandler = null;
                    finishHandler = (object sender, FinishEventArgs e) =>
                    {
                        showOptions.resultCallback(e.showResult);
#pragma warning restore 618
                        s_Platform.OnFinish -= finishHandler;
                    };
                    s_Platform.OnFinish += finishHandler;
                }
                if (!string.IsNullOrEmpty(showOptions.gamerSid))
                {
                    var player = new MetaData("player");
                    player.Set("server_id", showOptions.gamerSid);
                    SetMetaData(player);
                }
            }
            s_Platform.Show(string.IsNullOrEmpty(placementId) ? null : placementId);
        }

        /// <summary>
        /// Sets various metadata for the advertisement system.
        /// </summary>
        /// <param name="metaData">Metadata container</param>
        public static void SetMetaData(MetaData metaData)
        {
            s_Platform.SetMetaData(metaData);
        }

        public static void AddListener(IUnityAdsListener listener)
        {
            s_Platform.AddListener(listener);
        }

        public static void RemoveListener(IUnityAdsListener listener)
        {
            s_Platform.RemoveListener(listener);
        }
        
        /// <summary>
        /// Unity Ads Banner
        /// </summary>
        public static class Banner
        {
            private static EventHandler<StartEventArgs> s_StartHandler;
            private static EventHandler<HideEventArgs> s_HideHandler;
            private static EventHandler<EventArgs> s_UnloadHandler;

            public static void Load()
            {
                Load(null, null);
            }

            public static void Load(BannerLoadOptions options)
            {
                Load(null, options);
            }

            public static void Load(string placementId)
            {
                Load(placementId, null);
            }

            public static void Load(string placementId, BannerLoadOptions options)
            {
                if (options != null)
                {
                    if (options.loadCallback != null)
                    {
                        EventHandler<EventArgs> handler = null;
                        handler = (object sender, EventArgs args) => {
                            s_Platform.Banner.OnLoad -= handler;
                            options.loadCallback();
                        };
                        s_Platform.Banner.OnLoad += handler;
                    }
                    if (options.errorCallback != null)
                    {
                        EventHandler<ErrorEventArgs> handler = null;
                        handler = (object sender, ErrorEventArgs args) => {
                            s_Platform.Banner.OnError -= handler;
                            options.errorCallback(args.message);
                        };
                        s_Platform.Banner.OnError += handler;
                    }
                }
                s_Platform.Banner.Load(placementId);
            }

            /// <summary>
            /// Shows the banner with the default placement ID and no callbacks.
            /// </summary>
            public static void Show()
            {
                Show(null, null);
            }

            /// <summary>
            /// Shows the banner with the default placement ID and will fire the callback name="showCallback" on show,
            /// and name="hideCallback" on hide.
            /// </summary>
            public static void Show(BannerOptions options)
            {
                Show(null, options);
            }

            /// <summary>
            /// Shows the banner with the givden placement ID and no callbacks.
            /// and name="hideCallback" on hide.
            /// </summary>
            public static void Show(string placementId)
            {
                Show(placementId, null);
            }

            public static void Show(string placementId, BannerOptions options)
            {
                if (s_UnloadHandler == null)
                {
                    s_UnloadHandler = (object sender, EventArgs args) => {
                        if (s_StartHandler != null)
                        {
                            s_Platform.Banner.OnShow -= s_StartHandler;
                            s_StartHandler = null;
                        }
                        if (s_HideHandler != null)
                        {
                            s_Platform.Banner.OnHide -= s_HideHandler;
                            s_HideHandler = null;
                        }
                        s_Platform.Banner.OnUnload -= s_UnloadHandler;
                    };
                    s_Platform.Banner.OnUnload += s_UnloadHandler;
                }

                if (options != null)
                {
                    if (options.showCallback != null && s_StartHandler == null)
                    {
                        s_StartHandler = (object sender, StartEventArgs args) => {
                            options.showCallback();
                        };
                        s_Platform.Banner.OnShow += s_StartHandler;
                    }
                    if (options.hideCallback != null && s_HideHandler == null)
                    {
                        s_HideHandler = (object sender, HideEventArgs args) => {
                            options.hideCallback();
                        };
                        s_Platform.Banner.OnHide += s_HideHandler;
                    }
                }

                s_Platform.Banner.Show(string.IsNullOrEmpty(placementId) ? null : placementId);
            }

            public static void Hide(bool destroy = false)
            {
                s_Platform.Banner.Hide(destroy);
            }

            public static void SetPosition(BannerPosition position)
            {
                s_Platform.Banner.SetPosition(position);
            }

            public static bool isLoaded => s_Platform.Banner.isLoaded;
        }
    }
}
