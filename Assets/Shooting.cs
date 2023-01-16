using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private GameObject bullet;
    [SerializeField]private GameObject muzzle;
    [SerializeField]private float bulletVelocity;
    [SerializeField]private int noOfBullets;
    [SerializeField]private int ReloadTime;
    private int count=1;
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        StartCoroutine(Shoot());
    }
    IEnumerator Shoot()
    {
       
        
         if(count==noOfBullets)
        {
        count=1;
        yield return new WaitForSeconds(ReloadTime);
        Debug.Log("Done");
        }
        GameObject go=Instantiate(bullet, muzzle.transform.position, muzzle.transform.rotation);
        go.GetComponent<Rigidbody>().AddForce(muzzle.transform.forward*bulletVelocity,ForceMode.Impulse);
        count++;
        yield return null;
    }
}
