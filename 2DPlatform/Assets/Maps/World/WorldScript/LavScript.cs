using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavScript : MonoBehaviour
{
    [SerializeField] ParticleSystem DeadParticle;
    private void OnTriggerEnter2D(Collider2D other) {
        StartCoroutine(DeadParticleTimer(other));
        if(other.tag == "Player") {
            other.gameObject.GetComponent<PlayerScript>().GetDamage(200);
            return;
        }
        Destroy(other.gameObject);
    }
    IEnumerator DeadParticleTimer(Collider2D other) {
        DeadParticle.transform.position = other.transform.position;
        DeadParticle.Play();
        yield return new WaitForSeconds(1f);
        DeadParticle.Stop();
    }
}
