using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agonie : MonoBehaviour
{
     [SerializeField] AudioClip clip;
    public bool playSoung = false;
    private void OnDestroy()
    {
        if (!playSoung) return;
        GameObject go = new GameObject("cool");
        go.AddComponent<AudioSource>().clip = clip;
        go.AddComponent<SetAudioVolume>();
        go.GetComponent<AudioSource>().Play();
        Destroy(go,1);
    }
}
