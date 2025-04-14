using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DatabaseGetter : MonoBehaviour
{   
    [SerializeField]
    private GameObject scrollViewContent;

    [SerializeField]
    private TextMeshProUGUI messageText;

    [SerializeField]
    private int numberQuestions;

    [SerializeField]
    private GameObject questionsButtonPrefab;

    [SerializeField]
    private ConnectAPI api;    
    
    [SerializeField]
    private PollingSystemHandler pollingSystemHandler;

    private List<QuestionObject> questionObjects;

    private RectTransform questionsButtonPrefabRect;
    private float buttonHeight;
    private float spacing;

    // Start is called before the first frame update
    void Start()
    {
        questionsButtonPrefabRect = questionsButtonPrefab.GetComponent<RectTransform>();
        buttonHeight = questionsButtonPrefabRect.rect.height;
        spacing = scrollViewContent.GetComponent<VerticalLayoutGroup>().spacing;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FetchQuestions() {
        api.GetRequest();
        questionObjects = api.QuestionsList;

        numberQuestions = questionObjects.Count;

        PopulateScrollViewContent(questionObjects);
        ResizeContent(numberQuestions);
    }

    void PopulateScrollViewContent(List<QuestionObject> questionObjects)
    {

        foreach (QuestionObject question in questionObjects)
        {
            GameObject questionGameObject = Instantiate(questionsButtonPrefab, scrollViewContent.transform);

            
            ActiveQuestionUpdater updater = questionGameObject.GetComponent<ActiveQuestionUpdater>();
            updater.MessageText = messageText;
            updater.SetQuestion(question);

            TextSetter textSetter = questionGameObject.GetComponent<TextSetter>();
            textSetter.Set("Questions " + question.Id);
        }


    }

    void ResizeContent(int number)
    {
        RectTransform scrollViewContentTransform = scrollViewContent.GetComponent<RectTransform>();
        scrollViewContentTransform.sizeDelta = new Vector2(scrollViewContentTransform.rect.x, (buttonHeight + spacing) * number);

    }
}
