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
    public List<Color> colors=new List<Color>();
    private List<Text> texts=new List<Text>();

    void Start()
    {
        for(int i=0;i<noOfWords;i++)
        {
            Text t=Instantiate(textPrefab,this.transform.position,Quaternion.identity).GetComponent<Text>();
            t.gameObject.AddComponent<Rigidbody>();
            t.transform.SetParent(canvas);
            texts.Add(t);
            t.gameObject.SetActive(false);

        }
        StartCoroutine("Words");
    }
    IEnumerator Words()
    {
        for(int i=0;i<noOfWords;i++)
        {
            texts[i].text=words[i];
            texts[i].gameObject.SetActive(true);
            texts[i].gameObject.GetComponent<Rigidbody>().AddForce(-Vector3.up*25,ForceMode.Impulse);
            //texts[i].color=colors[Random.Range(0,3)];
            yield return new WaitForSeconds(1f);
        }
        // for(int i=0;i<noOfWords;i++)
        // {
        //     if(texts[i].GetComponent<RectTransform>().y<=100)
        //     {
        //         texts[i].gameObject.SetActive(false);
        //         texts[i].transform.position=this.transform.position;
        //     }
        // }
    }

    // Update is called once per frame
    
}
