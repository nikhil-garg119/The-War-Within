using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SplashDamage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private GameObject player;
    public GameObject vol;
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
        
        Destroy(this.gameObject);
        StartCoroutine("VignetteEffect");}
       
        else if(Physics.CheckSphere(this.transform.position,0.25f,whatIsGround))
        Destroy(this.gameObject);
    }
    IEnumerator VignetteEffect()
    {
        vol.GetComponent<Volume>().weight=1;
        yield return new WaitForSeconds(1f);
        vol.GetComponent<Volume>().weight=0;
    }
    

  
}
