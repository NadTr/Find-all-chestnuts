using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameManager gm;
    private int counter = 0;
    private TMP_Text score;

     public void Initialize(GameManager gm)
    {
        this.gm = gm;
        counter = 0;

        if (this.transform.Find("TMPText").TryGetComponent<TMP_Text>(out TMP_Text TMPText))
        {
            this.score = TMPText; 
        }
        score.SetText($"Chestnuts : {counter}");

    }

    public void IncreaseCounter()
    {
        counter++;
        // Debug.Log($"increase counter = {counter}");
        score.SetText($"Chestnuts : {counter}");
    }
}
