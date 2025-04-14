using System;
using TMPro;
using UnityEngine;

public class ActiveQuestionUpdater : MonoBehaviour
{
    [SerializeField]
    private int id;

    [SerializeField]
    private DateTime date;

    [SerializeField]
    private string question;

    [SerializeField]
    private string[] choices;

    [SerializeField]
    private int solution;

    private QuestionObject questionObject;

    private PollingSystemHandler pollingSystemHandler;

    private TextMeshProUGUI messageText;

    public TextMeshProUGUI MessageText { get => messageText; set => messageText = value; }
    public PollingSystemHandler PollingSystemHandler { get => pollingSystemHandler; set => pollingSystemHandler = value; }

    public void ShowDetailsOnClick()
    {
        messageText.text = "Selected: Question "+ id + "\n"+ "["+ date + "]"+ question + "\n" +messageText.text;

    }

    public void ActivateQuestionOnClick()
    {
        pollingSystemHandler.ActiveQuestion = questionObject;
    }

    public void SetQuestion(QuestionObject questionObject)
    {
        this.questionObject = questionObject;
        SetDetails(questionObject);
    }    
    
    private void SetDetails(QuestionObject questionObject)
    {
        id = questionObject.Id;
        date = questionObject.Date;
        question = questionObject.Question;
        choices = questionObject.Choices;
        solution = questionObject.Solution;
    }
}
