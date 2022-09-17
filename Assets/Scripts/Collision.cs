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

    private void OnCollisionEnter(UnityEngine.Collision collision) //������������ �� ������
    {
        Debug.Log("������������");
        int _s = this.GetComponent<ChangeText>()._numberLife; //������� ���������� � ���������� � ��� "�������" ����� �� ������ �� �������� �����
        List<Transform> _tailList = HeadSnake.GetComponent<Snake>()._tails;// �������� ������ ������ (������)
        int _countTails = _tailList.Count;// ������� ����� ������ ��� ��������� �� � "��������" �����
        Debug.Log("_countTails: " + _countTails + "_s: " + _s);

        if (_countTails == 0)
        {
            _audio.PlayOneShot(Lose);
            //ParticleSystem.Play();
            Destroy(collision.gameObject);
            this.GetComponent<TextMeshPro>().text = (_s - 1).ToString();//����� �� ����� ����� �����
            Debug.Log("GAME OVER!!!"); //���� ����� ������
        }
        else
        {
            for (int i = 0; i <= _countTails + 2; i++) //������� ���� ��� ��������� "�������" ����� � ���������� ������  
            {
                Debug.Log("����� ������: " + _countTails + "; i=" + i);
                if (_s == 0 && _countTails >= 0) //���� "�������" ����� = 0, � ����� ��� ��������, ��:
                {
                    Debug.Log("#1");
                    Destroy(this.gameObject);
                    Destroy(Block.gameObject);
                    break; //������� �� �����

                }
                else if (_s > 0 && _countTails == 0) // ���� "�������" �����  ������ 0, � ������ �� ��������, ��:
                {
                    Debug.Log("#2");
                    _audio.PlayOneShot(Lose);
                    //ParticleSystem.Play();
                    Destroy(collision.gameObject);
                    this.GetComponent<TextMeshPro>().text = (_s - 1).ToString();//����� �� ����� ����� �����
                    Debug.Log("GAME OVER!!!"); //���� ����� ������

                    GamePanel.SetActive(false);
                    LosePanel.SetActive(true);
                    HeadSnake.GetComponent<Control>().enabled = false;
                    //ReloadLevel();
                    break;

                }
                else // � ���� �������:
                {
                    Debug.Log("#3");
                    _s -= 1; // �������� 1 �� ������� �����
                    this.GetComponent<TextMeshPro>().text = _s.ToString();//����� �� ����� ����� �����
                    _countTails -= 1; //�������� 1 �� ���������� ������
                    Destroy(_tailList[_tailList.Count - 1].gameObject); // ���������� ��������� ������� ������
                    _tailList.Remove(_tailList[_tailList.Count - 1]); // ������� ��������� ������� �� ������ ��������� ������

                }

            }
        }
        //for (int i = 0; i <= _countTails+2; i++) //������� ���� ��� ��������� "�������" ����� � ���������� ������  
        //{
        //    Debug.Log("����� ������: " + _countTails+"; i="+i);
        //    if (_s == 0 && _countTails >= 0) //���� "�������" ����� = 0, � ����� ��� ��������, ��:
        //    {
        //        Debug.Log("#1");
        //        Destroy(this.gameObject);
        //        Destroy(Block.gameObject);
        //        break; //������� �� �����
                
        //    }
        //    else if (_s > 0 && _countTails == 0) // ���� "�������" �����  ������ 0, � ������ �� ��������, ��:
        //    {
        //        Debug.Log("#2");
        //        _audio.PlayOneShot(Lose);
        //        //ParticleSystem.Play();
        //        Destroy(collision.gameObject);
        //        this.GetComponent<TextMeshPro>().text = (_s-1).ToString();//����� �� ����� ����� �����
        //        Debug.Log("GAME OVER!!!"); //���� ����� ������
                
        //        GamePanel.SetActive(false);
        //        LosePanel.SetActive(true);
        //        HeadSnake.GetComponent<Control>().enabled = false;
        //        //ReloadLevel();
        //        break;

        //    }
        //    else // � ���� �������:
        //    {
        //        Debug.Log("#3");
        //        _s -=1; // �������� 1 �� ������� �����
        //        this.GetComponent<TextMeshPro>().text = _s.ToString();//����� �� ����� ����� �����
        //        _countTails -= 1; //�������� 1 �� ���������� ������
        //        Destroy(_tailList[_tailList.Count-1].gameObject); // ���������� ��������� ������� ������
        //        _tailList.Remove(_tailList[_tailList.Count -1]); // ������� ��������� ������� �� ������ ��������� ������

        //    }

        //}

    }
    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
