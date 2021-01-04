using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Data : MonoBehaviour
{
    public float camSpeed=0.000000000000000000001f, fireballSpeed=2,borneSpawn=1f;
    private float campSpeedUp = 0.015f,borneSpawnDown=0.035f;
    public int score = 0;
    private Text scoreTXT;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(faster());
        scoreTXT = GameObject.Find("scoreTXT").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreTXT.text = score.ToString();
    }
    IEnumerator faster()
    {
        yield return new WaitForSeconds(2f);
        score++;
        if(camSpeed< 0.6f) camSpeed += campSpeedUp;
        if(borneSpawn>0.15f)borneSpawn -= borneSpawnDown;
        StartCoroutine(faster());
    }
    public void reStart()
    {
        camSpeed = 0.1f;
        borneSpawn = 1.2f;
        score = 0;
    }
}
