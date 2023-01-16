using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mini_Game : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private KeyCode First_Key;
    [SerializeField]private KeyCode Second_Key;
    [SerializeField]private KeyCode Third_Key;
    
    
    private KeyCode[] keys;
    [SerializeField]private Text text;
    private KeyCode currentKey;
    [SerializeField]private Slider slider;
    void Start()
    {
        keys=new KeyCode[]{First_Key,Second_Key,Third_Key};
        currentKey=keys[0];
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        StartCoroutine(RandomKeyGenerator());
        if(slider.value==1)
        StopCoroutine(RandomKeyGenerator());
        

    }
    IEnumerator RandomKeyGenerator()
    {
           
        yield return new WaitForSeconds(1f);
        text.text=currentKey.ToString();
        if(Input.GetKeyDown(currentKey))
        slider.value+=0.1f;
        currentKey=keys[Random.Range(0,3)];    
         
    }
   
}
