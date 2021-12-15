using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PandaMove : MonoBehaviour
{
    private ButtonController _buttonController;
   public int i;
    public GameObject YouAreLostPanel;
    public bool Endf0;
    public GameObject[] Purple;
    public GameObject[] Pink;
    public GameObject[] Yellow;



    // Start is called before the first frame update
    void Start()
    {
        
        
        i = 0; // для обращения в первый раз к 0-му элементу
        _buttonController = FindObjectOfType<ButtonController>(); // просто нужно для обращения к другому скрипту
        YouAreLostPanel.SetActive(false); // на всякий случай выключаем панель пройгрыша
    }

    // Update is called once per frame
    void Update()
    {
     
        if (Endf0 == true && i >= _buttonController.StringForAnimation.Length) // кольцуем анимации для вечного повторения заданного нами алгоритма если поставили "f0
        {
            i = 0;
        }
    }
    public void OnAnimationEnded() //закончилась прошлая анимация 
    {
        
        if (i < _buttonController.StringForAnimation.Length)
        {
            
                for (int e = i; e < _buttonController._colorsInsideFunctionButtons.Length; e++)
                {
                    
                    if (_buttonController._colorsInsideFunctionButtons[e].activeInHierarchy == false)
                    {
                        i = e;
                          if(_buttonController.StringForAnimation[i] == "PurpleValik" || _buttonController.StringForAnimation[i] == "PinkValik" || _buttonController.StringForAnimation[i] == "YeloowValik")
                          {
                              Valik();
                              i++;
                              break;
                          }
                          else
                          {
                              this.GetComponent<Animator>().SetTrigger(_buttonController.StringForAnimation[i]);
                              i++;
                              break;
                          }
                       
                    }
                    else if (e == _buttonController._colorsInsideFunctionButtons.Length - 1)
                    {
                    i = 0;
                    for (int f = i; f < _buttonController._colorsInsideFunctionButtons.Length; f++)
                    {
                        if (_buttonController._colorsInsideFunctionButtons[f].activeInHierarchy == false)
                        {
                            i = f;
                            if (_buttonController.StringForAnimation[i] == "PurpleValik" || _buttonController.StringForAnimation[i] == "PinkValik" || _buttonController.StringForAnimation[i] == "YeloowValik")
                            {
                                Valik();
                                i++;
                                break;
                            }
                            else
                            {
                                this.GetComponent<Animator>().SetTrigger(_buttonController.StringForAnimation[i]);
                                i++;
                                break;
                            }
                        }
                    }
                    }

                }

            
            
            
        }
        else if(Endf0 == false) // кольцуем анимации для вечного повторения заданного нами алгоритма
        {
            YouAreLostPanel.SetActive(true);// включаем панлель пройгрыша
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wrong"))
        {
            YouAreLostPanel.SetActive(true);// включаем панлель пройгрыша
        }
        if (other.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
       

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PurpleCube"))
        {
            for (int e = 0; e < Purple.Length; e++)
            {
                Purple[e].SetActive(true);
            }

        }
        if (other.CompareTag("PinkCube"))
        {
            for (int e = 0; e < Pink.Length; e++)
            {
                Pink[e].SetActive(true);
            }

        }
    }

    private void OnTriggerStay(Collider other)
    {
         if (other.CompareTag("PurpleCube"))
        {
            for(int e= 0; e < Purple.Length; e++)
            {
                Purple[e].SetActive(false);
            }
        }
        if (other.CompareTag("PinkCube"))
        {
            for (int e = 0; e < Pink.Length; e++)
            {
                Pink[e].SetActive(false);
            }
        }

    }
        public void OkButton()
    {
        Purple = GameObject.FindGameObjectsWithTag("Purple");
        Pink = GameObject.FindGameObjectsWithTag("Pink");
        Yellow = GameObject.FindGameObjectsWithTag("Yellow");
        OnAnimationEnded();
    }

    void Valik()
    {
        Debug.Log("krasim");
    }
}
