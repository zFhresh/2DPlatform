using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    [SerializeField]Slider HealSlider;
    [SerializeField] PlayerScript PlayerSc;
    float TargetHeal;
    private void Start() {
        TargetHeal = PlayerSc.GetHeal();
    }
    public void UpdateHeal(int targetHeal) {
        TargetHeal = targetHeal;
    }
    void Update()
    {
        HealSlider.value = Mathf.Lerp(HealSlider.value,TargetHeal,0.01f);
    }
}
