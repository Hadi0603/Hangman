using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;

public class QuizController : MonoBehaviour
{
    [Header("Serialized References")]
    [SerializeField] private Text[] inputTexts;
    [SerializeField] private string answer;
    [SerializeField] private GameObject[] mistakeSprites;
    [SerializeField] Button[] falseButtons;
    [SerializeField] private UIManager uiManager;

    private int currentInputIndex = 0;
    private int mistakeCount = 0;

    void Start()
    {

        foreach (Text t in inputTexts)
        {
            t.text = "";
        }

        foreach (GameObject sptr in mistakeSprites)
        {
            sptr.SetActive(false);
        }
        FalseButtons();
    }

    void FalseButtons()
    {
        foreach (Button btn in falseButtons)
        {
            btn.interactable = false;
            //btn.GetComponent<KeyboardButtonController>().containerFillImage.color = Color.gray;
            //btn.GetComponent<KeyboardButtonController>().containerText.color = Color.white;
            btn.image.color = Color.white;
            /*TextMeshProUGUI tmpText = btn.GetComponentInChildren<TextMeshProUGUI>();
            if (tmpText != null)
            {
                tmpText.color = Color.white;
            }*/
        }
    }

    public void AddLetter(string letter)
    {
        bool foundMatch = false;

        for (int i = 0; i < answer.Length && i < inputTexts.Length; i++)
        {
            if (answer[i].ToString().Equals(letter, System.StringComparison.OrdinalIgnoreCase))
            {
                if (string.IsNullOrEmpty(inputTexts[i].text))
                {
                    inputTexts[i].text = letter;
                    foundMatch = true;
                }
            }
        }

        if (!foundMatch)
        {
            if (mistakeCount < mistakeSprites.Length)
            {
                mistakeSprites[mistakeCount].SetActive(true);
                mistakeCount++;
            }

            if (mistakeCount >= mistakeSprites.Length)
            {
                StartCoroutine(WaitAndGameOver());
            }
        }
        else
        {
            CheckForWin();
        }
    }
    private void CheckForWin()
    {
        for (int i = 0; i < answer.Length && i < inputTexts.Length; i++)
        {
            if (!inputTexts[i].text.Equals(answer[i].ToString(), System.StringComparison.OrdinalIgnoreCase))
            {
                return;
            }
        }

        StartCoroutine(WaitAndGameWon());
    }


    public void DeleteLastLetter()
    {
        if (currentInputIndex > 0)
        {
            currentInputIndex--;
            inputTexts[currentInputIndex].text = "";
        }
    }
    IEnumerator WaitAndGameOver()
    {
        yield return new WaitForSeconds(0.5f);
        uiManager.GameOver();
    }

    IEnumerator WaitAndGameWon()
    {
        yield return new WaitForSeconds(0.5f);
        uiManager.TriggerGameWon();
    }
}
