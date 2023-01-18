using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyGroundScript : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] int startPoint;
    [SerializeField] Transform[] points;

    [SerializeField] int i;

    void Start()
    {
        transform.position = points[startPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        Direction();
        

    }
    void Direction() {
        if(Vector2.Distance(transform.position,points[i].position) < 0.02f) {
          i++;
          if (i == points.Length) {
             i =0;
          }
        }

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, Speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D other) {
       other.transform.parent = transform;
    }
    private void OnCollisionExit2D(Collision2D other) {
      other.transform.parent = null;
    }
}
