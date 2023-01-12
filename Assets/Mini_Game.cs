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
    private KeyCode currentKey;
    [SerializeField]private Slider slider;
    void Start()
    {
        keys=new KeyCode[]{First_Key,Second_Key,Third_Key};
        currentKey=keys[0];
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentKey.ToString());
        StartCoroutine(RandomKeyGenerator());
        FillSlider();

    }
    IEnumerator RandomKeyGenerator()
    {
        currentKey=keys[Random.Range(0,3)];
        yield return new WaitForSeconds(4f);
    }
    void FillSlider()
    {
        slider.gameObject.SetActive(true);
        if(Input.GetKeyDown(currentKey))
        slider.value+=0.1f;
        
    }
}
