using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed;
    public float Timer;
    // Start is called before the first frame update
    void Start()
    {
        Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        this.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        if(Timer >= 30)
        {
            Destroy(this.gameObject);
        }
    }
}
