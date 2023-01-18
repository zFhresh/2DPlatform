using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBlockSc : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable() {
        Invoke("HideCanva",4);
    }
    private void HideCanva() {
        this.gameObject.SetActive(false);
    }
}
