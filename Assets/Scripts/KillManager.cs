using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int killcount;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        killcount=GameObject.FindGameObjectsWithTag("AngWraiths").Length;
    }
}
