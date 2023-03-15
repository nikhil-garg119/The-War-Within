using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Test : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    public GameObject image;
    void Start()
    {
        text.text="";
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButtonDown(0))
       {
        Vector3.MoveTowards(image.transform.position,new Vector3(image.transform.position.x,image.transform.position.y+200f,image.transform.position.z),2f);
        StartCoroutine("DialogueGenerator","Hello");
       }
    }
    IEnumerator DialogueGenerator(string x)
    {
        for(int i=0;i<x.Length;i++)
        {
            text.text+=x[i];
            yield return new WaitForSeconds(1f);
            
        }
        
    }
}
