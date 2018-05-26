using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    long update;
    GameObject player;
    //GameObject enemy;
    float height;
    float width;
    float spawnDelay = 0;
    float spawnTime = 2f;
    public GameObject enemy;
    float zIndex;

	// Use this for initialization
	void Start () {

        update = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        //enemy = GameObject.FindGameObjectWithTag("Enemy");
        InvokeRepeating("SpawnEnemy", spawnDelay, spawnTime);
        zIndex =-1;
        Camera cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;

    }
	
	// Update is called once per frame
	void Update () {
        //GameObject objectPlayer = GameObject.FindGameObjectWithTag("Player");
        //Player player = objectPlayer.GetComponent<Player>();

        GameObject objectLimit = GameObject.FindGameObjectWithTag("ZoneLimit");
        LimitLine zoneLimit = objectLimit.GetComponent<LimitLine>();

        GameObject objectZone = GameObject.FindGameObjectWithTag("Zone");
        ZoneLine zone = objectZone.GetComponent<ZoneLine>();
        if (zone != null && update >= 400)
        {
            //player.updateRadius(4f);
            zoneLimit.setZone(Config.SIZE_ZONE * 1.4f);
            zone.setZone(Config.SIZE_ZONE * 1f);
        }
           
        if (zone != null && update >= 800)
        {
            //player.updateRadius(2f);
            zoneLimit.setZone(Config.SIZE_ZONE * 1f);
            zone.setZone(Config.SIZE_ZONE * 0.5f);
            update = 0;
        }
        update++;
    }

    void SpawnEnemy()
    {
        //Vector3 position = 
        var options = Random.Range(0, 4);
        float y = height / 2;
        float x = width / 2;
        Vector3 position;
        var playerPosition = player.transform.position;
        //Phan tu 1, spawn phan tu 3
        if (playerPosition.x > 0 && playerPosition.y > 0)
        {
            position = new Vector3(-x - 1, Random.Range(-y, 0), zIndex);
            Instantiate(enemy, position, transform.rotation);
        }

        //Phan tu 2, spawn phan 4
        if (playerPosition.x > 0 && playerPosition.y < 0)
        {
            position = new Vector3(-x - 1, Random.Range(0, y), zIndex);
            Instantiate(enemy, position, transform.rotation);
        }

        //Phan tu 3, spawn phan 1
        if (playerPosition.x < 0 && playerPosition.y < 0)
        {
            position = new Vector3(x + 1, Random.Range(0, y), zIndex);
            Instantiate(enemy, position, transform.rotation);
        }

        //Phan tu 4, spawn phan 2
        if (playerPosition.x < 0 && playerPosition.y > 0)
        {
            position = new Vector3(x + 1, Random.Range(-y, 0), zIndex);
            Instantiate(enemy, position, transform.rotation);
        }
    }
}
