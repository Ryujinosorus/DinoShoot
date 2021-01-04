using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField]GameObject[] monster;
    Vector2 borneY = new Vector2(-6.5f,8);
    private Data data;
    GameObject player;
    Transform garbage;
    // Start is called before the first frame update

    IEnumerator spawn()
    {
        float y = Random.Range(borneY.x, borneY.y);
        GameObject go = Instantiate(monster[ int.Parse(Random.Range(0, monster.Length).ToString())], new Vector3(player.transform.position.x + 50, y, 0), Quaternion.identity);
        go.transform.rotation = Quaternion.Euler(0,-90,0);
        go.transform.parent = garbage;
        yield return new WaitForSeconds(data.borneSpawn);
        StartCoroutine(spawn());
    }
    public void stop()
    {
        StopAllCoroutines();
    }
    public void reStart()
    {
        player = GameObject.Find("xSpawn").gameObject;
        garbage = GameObject.Find("garbage").transform;
        data = GameObject.Find("ChefDeProjet").GetComponent<Data>();
        StartCoroutine(spawn());
    }

}
