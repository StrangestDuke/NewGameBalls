using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using System;
public class DialogManager : MonoBehaviour
{
    //Индекс кнопки, который сбривается ниже, в парсе выборов
    public int indexOfStuff = 0;

    [SerializeField] private GameObject SurroundingPanel;
    [SerializeField] private GameObject DialoguePanel;
    [SerializeField] private TextMeshProUGUI SurroundingText;
    [SerializeField] private TextMeshProUGUI DialogueText;
    [SerializeField] private GameObject[] SurroundingChoices;
    [SerializeField] private TextMeshProUGUI DialogueChoices;
    [SerializeField] private List<item> items;
    [SerializeField] private List<furnitureItem> furniture;
    [SerializeField] private ItemPicking[] SurroundingChoicesItemPicking;
    private int numberOfItems = 0;
    public GameObject currentPlacement;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;

    public static DialogManager instance;

    private const string ACTION_TAG = "action";

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one instance of the DialManager");
        }

        instance = this;
    }

    private void Start()
    {
        choicesText = new TextMeshProUGUI[SurroundingChoices.Length];
        int index = 0;
        foreach (GameObject choice in SurroundingChoices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
        index = 0;
        foreach (GameObject choice in SurroundingChoices)
        {
            SurroundingChoicesItemPicking[index] = choice.GetComponent<ItemPicking>();
            index++;
        }

    }


    public static DialogManager GetInstance()
    {
        return instance;
    }


    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);

        if (currentStory.canContinue)
        {
            DialogueText.text = currentStory.Continue();
        }

    }

    public void EnterSurroundingNode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);

        SurroundingText.text = currentStory.ContinueMaximally();

        //SurroundingChoices.text = currentStory.currentChoices;
        DisplayChoices();
    }

    public void ShowFurnitureOnTile(List<furnitureItem> furnitureOnTile)
    {
        SurroundingText.text += "\n";

        foreach (furnitureItem furnitureShit in furnitureOnTile)
        {
            SurroundingText.text += "There is a <color=red>" + furnitureShit.name + "</color> " + furnitureShit.description + ", it is made of " + furnitureShit.material + "\n";
            
        }
        //SurroundingChoices.text = currentStory.currentChoices;

        ContinueSurroundingNode();
    }

    public void ContinueSurroundingNode()
    {

        if (currentStory.canContinue)
        {
            // set text for the current dialogue line
            SurroundingText.text += currentStory.ContinueMaximally();
            // display choices, if any, for this dialogue line
            DisplayChoices();

            HandleTags(currentStory.currentTags);

            //Генерация кнопок предметов.
            DisplayItemsPickups(items);
        }
        else
        {
            //SurroundingChoices.text = currentStory.currentChoices;
            DisplayChoices();

            DisplayItemsPickups(items);
        }

    }

    //Не рабочая хуйня
    private void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(":");
            if (splitTag.Length != 2)
                Debug.LogError("Tag is fucked somewhere " + tag);

            string tagKey = splitTag[0].Trim();
            string tagVal = splitTag[1].Trim();
            /*
            switch (tagKey)
            {
                case ACTION_TAG:
                    switch (tagVal)
                    {
                        case "burnTheTile":
                            currentPlacement;
                            break;
                    }
                    break;

            }
            */
        }
    }


    public void GutSurroundingNode()
    {

        SurroundingText.text = "";

    }

    //Makes game understand, where player doing shit
    public void WriteCurrentObject(GameObject gm)
    {
        currentPlacement = gm;
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;
        int index = 0;
         
        foreach (Choice choice in currentChoices)
        {
            SurroundingChoices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        for (int i = index; i < SurroundingChoices.Length; i++)
        {
            SurroundingChoices[i].gameObject.SetActive(false);
        }
        indexOfStuff = index;
    }

    public void MakeChoice(int choiceIndex)
    {
        if (SurroundingChoicesItemPicking[choiceIndex].item != null)
        {
            bool success = SurroundingChoicesItemPicking[choiceIndex].PickUp(SurroundingChoicesItemPicking[choiceIndex].item, currentPlacement);
            if (success) {
                SurroundingText.text += "Вы взяли " + SurroundingChoicesItemPicking[choiceIndex].item.name + "\n";
                ContinueSurroundingNode();
            }
            else
            {
                SurroundingText.text += "Неудалось взять " + SurroundingChoicesItemPicking[choiceIndex].item.name + " из-за недостатка места в рюкзаке \n";
                ContinueSurroundingNode();
            }
        }
        else
            currentStory.ChooseChoiceIndex(choiceIndex);
            // NOTE: The below two lines were added to fix a bug after the Youtube video was made
            ContinueSurroundingNode();
    }

    public void DisplayItemsPickups(List<item> itemsInTile)
    {
        items = itemsInTile;
        ShowItemsInChoices(items);
    }

    public void ShowItemsInChoices(List<item> itemsInTile)
    {
        int indexOfItem = 0;
        foreach (item itemInTile in itemsInTile)
        {
            SurroundingChoices[indexOfStuff].gameObject.SetActive(true);
            choicesText[indexOfStuff].text = "Взять " + itemInTile.name;
            SurroundingChoicesItemPicking[indexOfStuff].item = itemInTile;
            indexOfStuff++;
            indexOfItem++;
        }
        for (int i = indexOfStuff; i < SurroundingChoices.Length; i++)
        {
            SurroundingChoices[i].gameObject.SetActive(false);
        }
        numberOfItems = indexOfItem;
    }

    
}
