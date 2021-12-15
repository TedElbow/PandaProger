﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValikInstantiate : MonoBehaviour
{
    private ButtonController _buttonController;
    public Sprite DirectionPrefab;
    public Color CurrentColor;

    public string Name;
    void Start()
    {
       
        _buttonController = FindObjectOfType<ButtonController>();//просто нужно для обращения к другому скрипту
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ValikColorInstantiateing()
    {
        _buttonController._imageInsideFunctionButtons[_buttonController.ButtonIndex].SetActive(true); // включаем Image внури Функциональной кнопки,для красоты
        CurrentColor.a = 1;
        _buttonController._imageInsideFunctionButtons[_buttonController.ButtonIndex].GetComponent<Image>().color = CurrentColor;
        _buttonController._imageInsideFunctionButtons[_buttonController.ButtonIndex].GetComponent<Image>().sprite = DirectionPrefab; // присваем картинку окну функции,как на кнопке,которую мы нажали 
        _buttonController.StringForAnimation[_buttonController.ButtonIndex] = Name; // присваем имя кнопки,которую мы только что нажали выбранному окну функции

    }
}
