using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DisableVol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Disabling");
    }
    void Update()
    {
        this.GetComponent<Volume>().weight-=0.01f;
    }
    // Update is called once per frame
   IEnumerator Disabling()
   {
    if(this.GetComponent<Volume>().weight==1){
   this.GetComponent<Volume>().weight=0;
    yield return new WaitForSeconds(1f);
   }}
}
