using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackScript : MonoBehaviour
{
    [SerializeField]float Speed;
    private void Start() {
        Invoke("StartMoving",3f);
    }
    public void StartMoving() {
        CanMove = true;
    }
    bool CanMove = false;
    void Update()
    {
        if(CanMove)  {
            transform.position += new Vector3(Speed * Time.deltaTime, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            other.GetComponent<PlayerScript>().GetDamage(101);
        }
    }
}
