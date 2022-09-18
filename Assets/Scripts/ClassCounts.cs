using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ClassCounts : MonoBehaviour
{
    private ChoiceInteraction choices;
    public GameObject player;
    public TextMeshProUGUI classText;

    private void Start()
    {
        choices = player.GetComponent<ChoiceInteraction>();
        classText = gameObject.GetComponent<TextMeshProUGUI>();

    }

    private void Update()
    {
        if (gameObject.CompareTag("Archer"))
        {
            classText.text = choices.countArcher.ToString();
        }

        if (gameObject.CompareTag("Barbarian"))
        {
            classText.text = choices.countBarbarian.ToString();
           
        }
        if (gameObject.CompareTag("Mage"))
        {
            classText.text = choices.countMage.ToString();
            
        }
        if (gameObject.CompareTag("Warrior"))
        {
            classText.text = choices.countWarrior.ToString();
            
        }
    }
}
