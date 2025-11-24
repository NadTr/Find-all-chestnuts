using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStart : MonoBehaviour
{
    public void OnPlayButton ()
    {
        SceneManager.LoadScene("FirstLevel");
    }
}