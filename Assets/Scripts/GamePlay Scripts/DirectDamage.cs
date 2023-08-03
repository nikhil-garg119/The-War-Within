using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DirectDamage: MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private GameObject player;
    [SerializeField]private LayerMask whatIsGround;
    [SerializeField]private float damage;
    

    // Update is called once per frame
    void Start()
    {
        player=GameObject.FindWithTag("Player");
        
    }
 
   
    
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")){
        player.GetComponent<Damage>().health-=damage;
        
        Destroy(this.gameObject);
    }
}}
    


