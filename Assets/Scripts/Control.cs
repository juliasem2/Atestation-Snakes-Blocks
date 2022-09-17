using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField] private Transform Snake;
    [SerializeField] private float Speed;
    void Update()
    {
        //задаем движение вперед
        Snake.position += Vector3.forward * Speed * Time.deltaTime;
        
        //прописываем условие для движение налево
        if (Input.GetKey(KeyCode.A))
        {
            Snake.position += Vector3.left * Speed * Time.deltaTime;
        }


        //прописываем условие для движение направо
        if (Input.GetKey(KeyCode.D))
        {
            Snake.position += Vector3.right * Speed * Time.deltaTime;
        }
    }
}
