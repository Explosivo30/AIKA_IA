using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class AiKaMovement : MonoBehaviour
{
    NavMeshAgent aika;
    [SerializeField] Transform player;

    Rigidbody rb;

    private void Awake()
    {
        aika = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }


    void Move(Vector3 pointToMove)
    {
        aika.SetDestination(pointToMove);
    }


    void Talk()
    {

    }

    


}
