using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private int counter;
    [SerializeField] private TMP_Text score;

    void Start()
    {
        counter = 0;
        score.SetText($"Score : {counter}");

    }

    public void IncreaseCounter()
    {
        counter++;
        Debug.Log($"increase counter = {counter}");
        score.SetText($"Chestnuts : {counter}");
    }
}
