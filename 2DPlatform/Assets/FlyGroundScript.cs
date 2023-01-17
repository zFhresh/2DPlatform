using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyGroundScript : MonoBehaviour
{
    [SerializeField]float Distance,Mspeed;
    [SerializeField] int DirectionXYZ = 1;
    [Tooltip("Başlangıç yönü aşağıyamı yoksa yukarıyamı ? (-1 aşağı  +1 yukarı)")]
    [SerializeField] int DirectionReverse = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Direction();

    }
    void Direction() {
        if(DirectionXYZ == 0) {
            transform.position = new Vector3(
              Mathf.Sin(Time.time * Mspeed) * Distance * DirectionReverse,
              transform.position.y,
              transform.position.z
            );
        }
        if(DirectionXYZ == 1) {
            transform.position = new Vector3(
              transform.position.x,
              Mathf.Sin(Time.time * Mspeed) * Distance * DirectionReverse,
              transform.position.z
            );
        }
        if(DirectionXYZ == 2) {
            transform.position = new Vector3(
              transform.position.x,
              transform.position.y,
              Mathf.Sin(Time.time * Mspeed) * Distance * DirectionReverse
            );
        }
    }
}
