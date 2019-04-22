using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fear_shooting : MonoBehaviour
{

    public Transform ShootPos;
    private EnemyAI player;
    public GameObject projectile;
    public float shootRate;
    private Animator animator;
    private NavMeshAgent agent;
    [SerializeField]
    float timer;
    bool canShoot;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GetComponent<EnemyAI>();
        animator = GetComponent<Animator>();
        canShoot = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            
           
            
            animator.SetTrigger("Shoot");
            timer = shootRate;
            
        }
    }

    void shoot()
    {

        Instantiate(projectile, ShootPos.position, ShootPos.rotation);
    }

    void turn()
    {
        transform.localRotation = Quaternion.Euler(0, -90, 0);
    }
}
