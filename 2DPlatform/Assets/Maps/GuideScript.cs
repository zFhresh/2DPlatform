using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuideScript : MonoBehaviour
{
    [SerializeField] string Guide_text;
    TextMeshProUGUI Text;
    void Start()
    {
        Text = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        Text.text = Guide_text;
        Text.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Text.gameObject.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D other) {
        Text.gameObject.SetActive(false);
    }
}
