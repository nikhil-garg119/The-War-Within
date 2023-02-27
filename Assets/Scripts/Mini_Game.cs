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
    private bool IsTimerOut=true;
    [SerializeField]private Slider slider;
    void Start()
    {
        keys=new KeyCode[]{First_Key,Second_Key,Third_Key};
        currentKey=keys[0];
        
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream:Assets/Mini_Game.cs
        text.text=currentKey.ToString();
        if(Input.GetKeyDown(currentKey))
        slider.value+=0.1f;
        StartCoroutine(RandomKeyGenerator());
        if(slider.value==1)
        text.text="YAYYYYYYYYYYYYYY";
        

    }
    IEnumerator RandomKeyGenerator()
    {
        currentKey=keys[Random.Range(0,3)];       
        yield return new WaitForSeconds(4000f);
         
=======
        
        if(slider.value!=1){
        text.text=currentKey.ToString();
        if(Input.GetKeyDown(currentKey))
        {
        slider.value+=0.25f;
        currentKey=keys[Random.Range(0,3)];    
        }
        }
        if(slider.value!=0 && slider.value!=1)
        slider.value-=0.0015f;

>>>>>>> Stashed changes:Assets/Scripts/Mini_Game.cs
    }
   
}
