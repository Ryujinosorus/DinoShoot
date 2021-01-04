using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Drake : MonoBehaviour
{
    float lastShootTime = -1000,fireDelay=0.5f;
    [SerializeField] GameObject fireBall;
    ButtonManagement buttonMangement;
    AudioSource aso;
    Animator anim;
    Data data;
    // Start is called before the first frame update
    void Start()
    {
        buttonMangement = GameObject.Find("ChefDeProjet").GetComponent<ButtonManagement>();
        data = GameObject.Find("ChefDeProjet").GetComponent<Data>();
        aso = GetComponent<AudioSource>();    
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position,getPos(Input.GetTouch(0)),data.camSpeed*15);
            if (Input.touchCount > 1)
                shoot();
        }
    }
    Vector3 getPos(Touch myTouch)
    {
        Ray mousePos = Camera.main.ScreenPointToRay(myTouch.position);
        Plane ground = new Plane(Vector3.forward, new Vector3(0, 0, 0));
        float distance;
        ground.Raycast(mousePos, out distance);
        Vector3 t = mousePos.GetPoint(distance);
        if (t.y < -4) t.y=-4;
        return t;
    }
    void shoot()
    {
        if (lastShootTime + fireDelay > Time.time) return;
        lastShootTime = Time.time;
        aso.Play();
        anim.SetTrigger("shoot");
        Vector3 whereToShoot = getPos(Input.GetTouch(1));
        GameObject go = GameObject.Instantiate(fireBall,transform.position,Quaternion.identity);
        go.transform.LookAt(whereToShoot);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag != "Ennemy" || collision.collider.tag=="invisibleWall") return;
        loose();
    }
    public void loose()
    {
        int sc = GameObject.Find("ChefDeProjet").GetComponent<Data>().score;
        if (sc > PlayerPrefs.GetInt("dino_bs")) PlayerPrefs.SetInt("dino_bs", sc);
        if(Advertisement.IsReady() && Random.Range(0,2)==0)
            Advertisement.Show("video");
        buttonMangement.looseGame();
    }
    public void reStart()
    {
        transform.position = Camera.main.transform.Find("spawnPoint").position;
    }
}
