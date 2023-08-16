using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class DialogueSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [TextArea(3,10)]
    public string[] dialogues;
    public GameObject narrationWindow;
    public TMP_Text text;
    private int i=0;
    void Awake()
    {
        GameObject.Find("Player").GetComponent<PlayerMovementScript>().enabled=false;
        GameObject.Find("Player").GetComponent<MouseLookScript>().enabled=false;
        GameObject.Find("Player").GetComponent<Damage>().enabled=false;
        
        
    }
    void Start()
    {
       
            StartCoroutine("DialogueSpawn");
        
        
    }
    void Update()
    {
        if(i==dialogues.Length || Input.GetKeyDown(KeyCode.E))
        {
        GameObject.Find("Player").GetComponent<PlayerMovementScript>().enabled=true;
        GameObject.Find("Player").GetComponent<MouseLookScript>().enabled=true;
        GameObject.Find("Player").GetComponent<Damage>().enabled=true;
        narrationWindow.SetActive(false);
        return;
        }
    }
    IEnumerator DialogueSpawn()
    {
       for(;i<dialogues.Length;i++)
       {
        text.text="";
        foreach(char ch in dialogues[i])
        {
            text.text+=ch;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1f);
       }
        
    }

    // Update is called once per frame
   
}
