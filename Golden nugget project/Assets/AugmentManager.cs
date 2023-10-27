using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AugmentManager : MonoBehaviour
{
    public List<Augments> augmentsList = new List<Augments>();

    public List<Button> choices = new List<Button>();

    private void Start()
    {
        
        for (int i = 0; i < choices.Count; i++)
        {
            int choiceIndex = i; 
            choices[i].onClick.AddListener(() => OnChoiceClicked(choiceIndex));
            
        }
        

    }
    public void OnChoiceClicked(int choiceIndex)
    {
        
        Debug.Log("Button " + choiceIndex + " clicked!");
        Button clickedButton = choices[choiceIndex];
        gameObject.SetActive(false);

        
    }
}
