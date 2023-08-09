using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int killcount;
    int totalOriginalWraiths;
    void Start()
    {
         totalOriginalWraiths=GameObject.FindGameObjectsWithTag("AngWraiths").Length;
    }

    // Update is called once per frame
    void Update()
    {
        killcount=totalOriginalWraiths-GameObject.FindGameObjectsWithTag("AngWraiths").Length;
        if((totalOriginalWraiths-killcount)==0)
        SceneManager.LoadScene(0);
    }
}
