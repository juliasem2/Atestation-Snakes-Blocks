using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeText : MonoBehaviour
{    
    public Snake Snake;
    public GameObject gameObgect;
    public int _numberLife;
    //public TextMeshPro textMesh;
    private void Start()
    {


        if (int.TryParse(gameObgect.GetComponent<TextMeshPro>().text, out int _memory))
        {
            _numberLife = _memory;
            //Debug.Log(_numberLife);
        }

    }


    //public int _numberLife;
    //private void OnCollisionEnter(UnityEngine.Collision collision)
    //{
    //    if (!collision.collider.TryGetComponent(out Snake snake)) return;

    //    //string _textCoin = this.GetComponent<TextMeshPro>().text;
    //    //_numberLife = int.Parse("12");
    //    //Debug.Log("_numberLife" + _numberLife);
    //   //if (int.TryParse(_textCoin, out _numberLife));

    //    //_numberLife = _textCoin.

    //    if (int.TryParse(this.GetComponent<TextMeshPro>().text, out int _memory))
    //    {
    //        _numberLife = _memory;
    //        Debug.Log(" оличество жизней после столкновени€"+_numberLife);
    //    }


    //    //textMesh.text = "!!!";
    //}
}
