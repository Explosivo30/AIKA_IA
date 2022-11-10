using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiKaSensor : MonoBehaviour
{
    [Header("Vision")]
    [SerializeField] float detectionRadious = 10f;
    [SerializeField] float detectionAngle = 90f;
    

    public bool enemyInside;
    public bool enemySeen;
    public bool playerTooFar = false;

    [Header("Detector")]
    //[SerializeField] float chaseRadious = 20f;
    [SerializeField]LayerMask layerMask;
    [SerializeField] SphereCollider rangeDetector;

    [Header("Enemy List")]
    List<Transform> enemies = new List<Transform>();

    public static List<Transform> wonderPoints = new List<Transform>();


    private void FixedUpdate()
    {

        Debug.Log(enemyInside);
        foreach (Transform enemy in enemies)
        {
            Vector3 aiKaPos = transform.position;
            Vector3 toAiKa = enemy.transform.position - aiKaPos;
            toAiKa.y = 0;

            if (toAiKa.magnitude <= detectionRadious)
            {
                //Debug.Log("Player is Nearby");
                //Lo siguiente significa"Esta dentro del triangulo de vision"
                if (Vector3.Dot(toAiKa.normalized, transform.forward) >
                  Mathf.Cos(detectionAngle * 0.5f * Mathf.Deg2Rad))
                {
                    
                    enemySeen = true;
                }
                else
                {
                    enemySeen = false;
                    Debug.Log("El enemigo esta fuera de rango");
                }
            }
            else
            {
                //ia.MoveToPoints();
                Debug.Log("Ya no lo veo al enemigo");
            }

        }
        /*
        
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemies.Add(other.transform);
            enemyInside = true;
            Debug.Log("He añadido uno");
        }

        if (other.tag == "WonderPoints")
        {
            wonderPoints.Add(other.transform);

        }

        if(other.tag == "Player")
        {
            playerTooFar = false;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemies.Remove(other.transform);
            Debug.Log("He quitado uno");
        }

        if (other.tag == "WonderPoints")
        {
            wonderPoints.Remove(other.transform);
        }

        if(other.tag == "Player")
        {
            playerTooFar = true;
        }

        if (enemies.Count == 0)
        {
            enemyInside = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Color c = new Color(0.2f, 0.9f, 0.9f, 0.4f);
        UnityEditor.Handles.color = c;

        Vector3 rotatedFordward = Quaternion.Euler(0, -detectionAngle * 0.5f, 0) * transform.forward;

        UnityEditor.Handles.DrawSolidArc(transform.position, Vector3.up, rotatedFordward, detectionAngle, detectionRadious);
        
        
        Color b = new Color(0.9f, 0.7f, 1f, 0.3f);
        UnityEditor.Handles.color = b;
        UnityEditor.Handles.DrawSolidArc(transform.position, Vector3.up, rotatedFordward, 360f, rangeDetector.radius);
    }
}
