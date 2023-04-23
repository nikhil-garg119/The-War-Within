using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDisable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     
      
    }
   
    void Update()
    {
        if(GameObject.FindWithTag("Weapon")!=null){
        GameObject go=GameObject.FindWithTag("Weapon");
     go.SetActive(false);
     Destroy(this.gameObject);
       
    }

    // Update is called once per frame
    }
}
