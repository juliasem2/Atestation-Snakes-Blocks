using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    //public TextMeshProUGUI PriceEnter;
    public Transform HeadSnake;
    public GameObject Block;
    public GameObject LosePanel;
    public GameObject GamePanel;
    public AudioClip Lose;
    private AudioSource _audio;
    public ParticleSystem ParticleSystem;
    public int _s;

    
    
    
    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        
    }

    private void OnCollisionEnter(UnityEngine.Collision collision) //Столкновение со стеной
    {
        Debug.Log("Столкновение");
        int _s = this.GetComponent<ChangeText>()._numberLife; //создаем переменную и записываем в нее "толщину" стены из текста на элементе стены
        List<Transform> _tailList = HeadSnake.GetComponent<Snake>()._tails;// получаем список хвоста (жизней)
        int _countTails = _tailList.Count;// считаем длину хвоста для сравнения ее с "толщиной" стены
        Debug.Log("_countTails: " + _countTails + "_s: " + _s);

        if (_countTails == 0)
        {
            _audio.PlayOneShot(Lose);
            //ParticleSystem.Play();
            Destroy(collision.gameObject);
            this.GetComponent<TextMeshPro>().text = (_s - 1).ToString();//пишем на блоке новую цифру
            Debug.Log("GAME OVER!!!"); //надо убить голову
        }
        else
        {
            for (int i = 0; i <= _countTails + 2; i++) //создаем цикл для сравнения "толщины" стены и количества жизней  
            {
                Debug.Log("длина списка: " + _countTails + "; i=" + i);
                if (_s == 0 && _countTails >= 0) //если "толщина" стены = 0, а жизни еще остались, то:
                {
                    Debug.Log("#1");
                    Destroy(this.gameObject);
                    Destroy(Block.gameObject);
                    break; //выходим из цикла

                }
                else if (_s > 0 && _countTails == 0) // если "толщина" стены  больше 0, а жизней не осталось, то:
                {
                    Debug.Log("#2");
                    _audio.PlayOneShot(Lose);
                    //ParticleSystem.Play();
                    Destroy(collision.gameObject);
                    this.GetComponent<TextMeshPro>().text = (_s - 1).ToString();//пишем на блоке новую цифру
                    Debug.Log("GAME OVER!!!"); //надо убить голову

                    GamePanel.SetActive(false);
                    LosePanel.SetActive(true);
                    HeadSnake.GetComponent<Control>().enabled = false;
                    //ReloadLevel();
                    break;

                }
                else // в иных случаях:
                {
                    Debug.Log("#3");
                    _s -= 1; // отнимаем 1 от толщины стены
                    this.GetComponent<TextMeshPro>().text = _s.ToString();//пишем на блоке новую цифру
                    _countTails -= 1; //отнимаем 1 от количества жизней
                    Destroy(_tailList[_tailList.Count - 1].gameObject); // уничтожаем последний элемент хвоста
                    _tailList.Remove(_tailList[_tailList.Count - 1]); // удаляем последний элемент из списка элементов хвоста

                }

            }
        }
        //for (int i = 0; i <= _countTails+2; i++) //создаем цикл для сравнения "толщины" стены и количества жизней  
        //{
        //    Debug.Log("длина списка: " + _countTails+"; i="+i);
        //    if (_s == 0 && _countTails >= 0) //если "толщина" стены = 0, а жизни еще остались, то:
        //    {
        //        Debug.Log("#1");
        //        Destroy(this.gameObject);
        //        Destroy(Block.gameObject);
        //        break; //выходим из цикла
                
        //    }
        //    else if (_s > 0 && _countTails == 0) // если "толщина" стены  больше 0, а жизней не осталось, то:
        //    {
        //        Debug.Log("#2");
        //        _audio.PlayOneShot(Lose);
        //        //ParticleSystem.Play();
        //        Destroy(collision.gameObject);
        //        this.GetComponent<TextMeshPro>().text = (_s-1).ToString();//пишем на блоке новую цифру
        //        Debug.Log("GAME OVER!!!"); //надо убить голову
                
        //        GamePanel.SetActive(false);
        //        LosePanel.SetActive(true);
        //        HeadSnake.GetComponent<Control>().enabled = false;
        //        //ReloadLevel();
        //        break;

        //    }
        //    else // в иных случаях:
        //    {
        //        Debug.Log("#3");
        //        _s -=1; // отнимаем 1 от толщины стены
        //        this.GetComponent<TextMeshPro>().text = _s.ToString();//пишем на блоке новую цифру
        //        _countTails -= 1; //отнимаем 1 от количества жизней
        //        Destroy(_tailList[_tailList.Count-1].gameObject); // уничтожаем последний элемент хвоста
        //        _tailList.Remove(_tailList[_tailList.Count -1]); // удаляем последний элемент из списка элементов хвоста

        //    }

        //}

    }
    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
