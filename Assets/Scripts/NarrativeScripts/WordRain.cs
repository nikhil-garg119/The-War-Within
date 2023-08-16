using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordRain : MonoBehaviour
{
    // Start is called before the first frame update
    public int noOfWords=0;
    public List<string> words;
    public GameObject textPrefab;
    public Transform canvas;
    
    private List<Text> texts=new List<Text>();

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")){
        StartCoroutine("Words");
        return;}

        //Debug.Log("E");
    }
    
       
        
    
    IEnumerator Words()
    {
        for(int i=0;i<noOfWords;i++)
        {
            
            float x=Random.Range(this.transform.position.x+200,this.transform.position.x-200);
            Text t=Instantiate(textPrefab,new Vector3(x,this.transform.position.y,this.transform.position.z),Quaternion.identity).GetComponent<Text>();
             t.transform.SetParent(canvas,false);
            t.gameObject.AddComponent<Rigidbody>();
            
            texts.Add(t);
            texts[i].text=words[i];
            texts[i].gameObject.GetComponent<Rigidbody>().AddForce(-Vector3.up*25,ForceMode.Impulse);
            //texts[i].color=colors[Random.Range(0,3)];
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(4f);
        StartCoroutine("DeleteWords");
        // for(int i=0;i<noOfWords;i++)
        // {
        //     if(texts[i].GetComponent<RectTransform>().y<=100)
        //     {
        //         texts[i].gameObject.SetActive(false);
        //         texts[i].transform.position=this.transform.position;
        //     }
        // }
    }
    IEnumerator DeleteWords()
    {
        for(int i=0;i<texts.Count;i++)
        {
            Destroy(texts[i].gameObject);
            yield return new WaitForSeconds(0.2f);
        }
       
    }

    // Update is called once per frame
    
}
