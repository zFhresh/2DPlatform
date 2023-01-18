using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] GameObject SettingsCanve,ErrorCanva;
    public void StartGame(int index) {
        SceneManager.LoadScene(index);
    }
    public void ShowSettings() {
        SettingsCanve.SetActive(true);
    }
    public void QuitGame() {
        Application.Quit();
    }
    public void ShowError() {
        ErrorCanva.SetActive(true);
    }
}
