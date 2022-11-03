using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiKaCombat : MonoBehaviour
{

    [SerializeField] Rigidbody objectToInstantiate;
    [SerializeField] GameObject platformPlacer;
    [SerializeField] Transform playerPrediction;
    float h = 5;
    float gravity = -18;

    Rigidbody objectInstantiation;
    [SerializeField] Transform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            ThrowObject();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            PlatformSpawn();
        }
    }
    #region ThrowWeapon
    void ThrowObject()
    {
        objectInstantiation = Instantiate(objectToInstantiate, transform.position, Quaternion.identity) as Rigidbody;
        Physics.gravity = Vector3.up * gravity;
        objectInstantiation.useGravity = true;
        objectInstantiation.velocity = CalculateThrow(player);
        Debug.Log(CalculateThrow(player));
    }
    

    
    public Vector3 CalculateThrow(Transform endPos)
    {
        float displacementY = endPos.position.y - objectInstantiation.transform.position.y;
        Vector3 displacementXZ = new Vector3(endPos.position.x - objectInstantiation.transform.position.x, 0, endPos.position.z - objectInstantiation.transform.position.z);


        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * h);
        Vector3 velocityXZ = displacementXZ / (Mathf.Sqrt(-2 * h / gravity) + Mathf.Sqrt(2 * (displacementY - h) / gravity));

        return velocityXZ + velocityY;
    }
#endregion

    #region PlatformSpawn
    void PlatformSpawn()
    {
        Instantiate(platformPlacer,new Vector3(playerPrediction.position.x,playerPrediction.position.y - 1.3f, playerPrediction.position.z), Quaternion.identity);
    }

    #endregion
}
