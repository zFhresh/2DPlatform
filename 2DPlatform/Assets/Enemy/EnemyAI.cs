using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Animator anim;
    // İleride Editor tarafında  editlenebilir olacak
    float Heal = 100;
    void Start()
    {
        anim = GetComponent<Animator>();
        InvokeRepeating("Attack",1,3);
    }
    public void Attack() {
        anim.SetTrigger("Attack");
        StartCoroutine(IEAttack());
    }
    public void GetDamage() {
        anim.SetTrigger("Hit");
        Heal -= 50;
        if(Heal <= 0) {
            // Duruma göre ölüm animasyonu eklenebilir
            this.gameObject.SetActive(false);
        }
    }
    IEnumerator IEAttack() {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position,2);
        foreach (Collider2D hit in hits) {
            if(hit.tag == "Player") {
                hit.GetComponent<PlayerScript>().GetDamage(10);
            }
        }
        yield return new WaitForSeconds(3f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
