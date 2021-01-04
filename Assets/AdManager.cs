﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string gameId;

#if UNITY_ANDROID
        gameId = "3959517";
#elif UNITY_IOS
             gameId = "3959516";
#endif

        if (Advertisement.isSupported && !Advertisement.isInitialized)
        {
            Advertisement.Initialize(gameId, false);
        }
    }

}
