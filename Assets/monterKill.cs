using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monterKill : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnDestroy()
    {
        GetComponent<AudioSource>().Play();
    }
}
