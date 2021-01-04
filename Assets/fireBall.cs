using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBall : MonoBehaviour
{
    Data data;
    [SerializeField] AudioClip bird;
    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.Find("ChefDeProjet").GetComponent<Data>();
        Destroy(gameObject,5);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector3( 0,0,(data.fireballSpeed + data.camSpeed)));
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player" || collision.collider.tag== "invisibleWall") return;
        data.score += 10;
        collision.collider.GetComponent<Agonie>().playSoung = true;
        GameObject go = Instantiate(transform.Find("explosion").gameObject, transform.position, Quaternion.identity);
        go.SetActive(true);
        Destroy(gameObject);
        Destroy(collision.collider.gameObject);
        Destroy(go, 1);
    }
}
