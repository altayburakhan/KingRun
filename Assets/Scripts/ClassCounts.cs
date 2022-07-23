using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
        if (gameObject.CompareTag("archer"))
        {
            classText.text = choices.countArcher.ToString();
        }

        if (gameObject.CompareTag("barbarian"))
        {
            classText.text = choices.countBarbarian.ToString();
        }
        if (gameObject.CompareTag("mage"))
        {
            classText.text = choices.countMage.ToString();
        }
        if (gameObject.CompareTag("warrior"))
        {
            classText.text = choices.countWarrior.ToString();
        }
    }
}
