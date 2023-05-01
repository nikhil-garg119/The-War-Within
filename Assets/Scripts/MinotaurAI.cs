
using UnityEngine;
using UnityEngine.AI;

public class MinotaurAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;

    //Patroling
    public Vector3 walkPoint;
    
    bool walkPointSet;
    public float walkPointRange;
    private Animator animator;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    bool alreadyCharged;
    public GameObject projectile;

    //States
    public float sightRange, attackRange,chargeRange;
    public bool playerInSightRange, playerInAttackRange, playerInChargeRange;

    private void Awake()
    {
        //player = GameObject.Find("PlayerObj").transform;
        agent = GetComponent<NavMeshAgent>();
        animator=GetComponentInChildren<Animator>();
    // 
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        playerInChargeRange = Physics.CheckSphere(transform.position, chargeRange , whatIsPlayer);
        //animator.SetBool("IsMoving",true);
        

        if (!playerInSightRange && !playerInChargeRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInChargeRange && !playerInAttackRange) ChasePlayer();
        if (playerInChargeRange && playerInAttackRange && playerInSightRange) 
            
            ChargePlayer();
        if(!playerInChargeRange && playerInAttackRange && playerInSightRange)
        AttackPlayer();

    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);
        
        
        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        animator.ResetTrigger("walk");
        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x+randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        animator.ResetTrigger("walk");
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);
        animator.SetTrigger("walk");
        
        if (!alreadyAttacked)
        {
            ///Attack code here
            float f=Vector3.Distance(this.transform.position,player.transform.position);
            GameObject go=Instantiate(projectile,this.transform.position,Quaternion.identity);
            Rigidbody rb=go.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up*15f,ForceMode.Impulse);
            rb.AddForce(transform.forward*f/3,ForceMode.Impulse);
            
            
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }
    private void ChargePlayer()
    {
       

        transform.LookAt(player);
        animator.SetTrigger("walk");
        
        if (!alreadyCharged)
        {
             agent.SetDestination(player.transform.position);
            agent.speed*=3f;
            if(Vector3.Distance(player.transform.position,transform.position)<=1f){
            player.GetComponent<Damage>().health-=20f;
            alreadyCharged = true;

            Invoke(nameof(ResetCharge), timeBetweenAttacks);}
        }
    }
    
    private void ResetCharge(){
        alreadyCharged = false;
        alreadyAttacked=true;
        agent.speed/=3f;
    }
    private void ResetAttack()
    {
        alreadyAttacked=false;
        alreadyCharged=true;
    }

    // public void TakeDamage(int damage)
    // {
    //     health -= damage;

    //     if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    // }
    // private void DestroyEnemy()
    // {
    //     Destroy(gameObject);
    // }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, chargeRange);
    }
}
