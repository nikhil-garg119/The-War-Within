using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashDamage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private GameObject player;
    [SerializeField]private LayerMask whatIsPlayer;
    [SerializeField]private LayerMask whatIsGround;
    [SerializeField]private float DamageRadius;
    [SerializeField]private ParticleSystem explosion;
    [SerializeField]private float damage;
    

    // Update is called once per frame
    void Start()
    {
        player=GameObject.FindWithTag("Player");
    }
    void Update()
    {
        if(Physics.CheckSphere(this.transform.position,DamageRadius,whatIsPlayer)){
        player.GetComponent<Damage>().health-=damage;
        Debug.Log("Yes");
        Destroy(this.gameObject);}
       
        else if(Physics.CheckSphere(this.transform.position,0.25f,whatIsGround)) 
        Destroy(this.gameObject);
    }
    void DestroyMortar()
    {
         Debug.Log("YES");
        

       
    }
}
