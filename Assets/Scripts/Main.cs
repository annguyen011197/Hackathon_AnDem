using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    long update;

	// Use this for initialization
	void Start () {

        update = 0;

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
}
