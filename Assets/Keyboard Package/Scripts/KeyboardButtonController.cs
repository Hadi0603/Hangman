using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyboardButtonController : MonoBehaviour
{
    [SerializeField] Image containerBorderImage;
    [SerializeField] public Image containerFillImage;
    [SerializeField] Image containerIcon;
    [SerializeField] public TextMeshProUGUI containerText;
    [SerializeField] TextMeshProUGUI containerActionText;

    [SerializeField] private QuizController quizController;
    private void Start()
    {
        SetContainerBorderColor(ColorDataStore.GetKeyboardBorderColor());
        SetContainerFillColor(ColorDataStore.GetKeyboardFillColor());
        SetContainerTextColor(ColorDataStore.GetKeyboardTextColor());
        SetContainerActionTextColor(ColorDataStore.GetKeyboardActionTextColor());
    }

    public void SetContainerBorderColor(Color color) => containerBorderImage.color = color;
    public void SetContainerFillColor(Color color) => containerFillImage.color = color;
    public void SetContainerTextColor(Color color) => containerText.color = color;
    public void SetContainerActionTextColor(Color color)
    {
        containerActionText.color = color;
        containerIcon.color = color;
    }

    public void AddLetter()
    {
        quizController.AddLetter(containerText.text);
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.interactable = false;
        }
        containerFillImage.color = Color.gray;
        containerText.color = Color.white; 
    }

    public void DeleteLetter()
    {
        quizController.DeleteLastLetter();
    }
}