using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AugmentManager : MonoBehaviour
{
    public List<Augments> augmentsList = new List<Augments>();

    public List<Button> choices = new List<Button>();
    private System.Random randomAugments = new System.Random();

    private void Awake()
    {
        for (int i = 0; i < choices.Count; i++)
        {
            int choiceIndex = i;
            choices[i].onClick.AddListener(() => OnChoiceClicked(choiceIndex));
           
            int randombuff = randomAugments.Next(0, augmentsList.Count);
            choices[i].GetComponentInChildren<TMP_Text>().text = augmentsList[randombuff].AugmentName;
        }
    }
    public void OnChoiceClicked(int choiceIndex)
    {
        
        Debug.Log("Button " + choiceIndex + " clicked!");
        Button clickedButton = choices[choiceIndex];
        foreach (Augments augments in augmentsList)
        {
            if (choices[choiceIndex].GetComponentInChildren<TMP_Text>().text == augments.AugmentName)
            {
                augments.Apply(Player.Instance.GetComponent<Entity>());
            }
        }
        gameObject.SetActive(false);

        
    }
}
