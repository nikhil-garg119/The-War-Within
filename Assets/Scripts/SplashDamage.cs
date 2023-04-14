using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashDamage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private GameObject player;
    [SerializeField]private GameObject vol;
    [SerializeField]private LayerMask whatIsPlayer;
    [SerializeField]private LayerMask whatIsGround;
    [SerializeField]private float DamageRadius;
    [SerializeField]private ParticleSystem explosion;
    [SerializeField]private float damage;
    

    // Update is called once per frame
    void Start()
    {
        player=GameObject.FindWithTag("Player");
        vol=GameObject.Find("Global Volume");
    }
    void Update()
    {
        if(Physics.CheckSphere(this.transform.position,DamageRadius,whatIsPlayer)){
        player.GetComponent<Damage>().health-=damage;
        vol.SetActive(true);
        Destroy(this.gameObject);}
       
        else if(Physics.CheckSphere(this.transform.position,0.25f,whatIsGround)) {
            vol.SetActive(false);
        Destroy(this.gameObject);
    }
    }

  
}
