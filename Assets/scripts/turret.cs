using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    GameObject Player;
    Transform barrel;
    public int Speed;
    bool inRange;
    public float Range;
    public float Timer;
    public GameObject MyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Capsule");
        barrel = this.transform.GetChild(0);
        inRange = false;
        Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        var delta = Time.deltaTime;
        Timer += delta;
        if(inRange == false)
        {
            scan(delta);
            detect();
        }
        else
        {
            detect();
            attack(Timer);
        }
    }
    void scan(float d)
    {
        Vector3 rotation = new Vector3(0,Speed * d,0);
        this.transform.Rotate(rotation);
    }
    void detect()
    {
        if(Vector3.Distance(this.transform.position, Player.transform.position) <= Range)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }
    }
    void attack(float t)
    {
        this.transform.LookAt(Player.transform);
        if(t > 4)
        {
            t = 0;
            Instantiate(MyPrefab, barrel.position, this.transform.rotation);
        }
    }
}
