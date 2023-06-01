using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]List<GameObject> enemyKillThreshold;

    float b=0f;
    float c=1f;
    public float AppearTime;
    bool x=false;
   
    // Update is called once per frame
    void Update()
    {
        if(enemyKillThreshold.Count==0 && !x){
        StartCoroutine("ExtendPlat");
        x=true;
        }
    }
    IEnumerator Appear()
    {
        while(b!=1){
        yield return new WaitForSeconds(AppearTime);
        b+=0.1f;
        Color color=this.GetComponent<MeshRenderer>().material.color;
        color.a=b;
        this.GetComponent<MeshRenderer>().material.color=color;
        Debug.Log(this.GetComponent<MeshRenderer>().material.color.a);
        
    }
    }
    IEnumerator ExtendPlat()
    {        
        while(c<15){
        c+=1f;
        this.transform.localScale=new Vector3(c,1,1);
        yield return new WaitForSeconds(AppearTime);
    }
}}
