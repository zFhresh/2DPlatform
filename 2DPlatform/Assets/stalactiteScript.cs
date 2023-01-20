using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stalactiteScript : MonoBehaviour
{
        Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RayCast2D();
    }
    [SerializeField] LayerMask Mask;
    void RayCast2D() {
         Vector2 RayCastPosition = new Vector2(transform.position.x - 6 , transform.position.y );
         RaycastHit2D hit = Physics2D.Raycast(RayCastPosition, -Vector2.up,10f,Mask);
        if (hit.collider != null)
        {
            Debug.Log("HitSomething");
            rb.simulated = true;
        }
       // Debug.DrawLine(transform.position,-Vector2.up * 10,Color.blue);
    
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.tag == "Player") {
            Debug.Log("Oyuncu öldü");
        }
        Destroy(this.gameObject);
    }
}
