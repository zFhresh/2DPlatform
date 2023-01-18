using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeaderTextAnimScript : MonoBehaviour
{
   TextMeshProUGUI HeaderText;
   [SerializeField] float Delay;
    void Start()
    {
        HeaderText = GetComponent<TextMeshProUGUI>();
        StartCoroutine(TextAnim());
        
    }
    IEnumerator TextAnim() {
        string text =  HeaderText.text;
        while ( true)  {
            while (HeaderText.text.Length > 0) {
                yield return new WaitForSeconds(Delay);
                HeaderText.text = HeaderText.text.Remove(HeaderText.text.Length - 1);
            }
            while (HeaderText.text.Length <  text.Length) {
                yield return new WaitForSeconds(Delay);
                int index = HeaderText.text.Length;
                HeaderText.text = HeaderText.text.Insert(index,text[index].ToString());
            }
        }
    }
}
