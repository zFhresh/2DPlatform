using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class EnterTheAreaScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]Light2D AreaLight;
    [SerializeField]float LerpTime;
    float DefaultLight_Indensity;
    [SerializeField]float TargetLight_Indensity;
    float Target;
    private void Start() {
        DefaultLight_Indensity = AreaLight.intensity;
        Target = DefaultLight_Indensity;
    }
    void Update()
    {
        AreaLight.intensity = Mathf.Lerp(AreaLight.intensity,Target,LerpTime);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            Target = TargetLight_Indensity;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player") {
            Target = DefaultLight_Indensity;
        }
    }
}
