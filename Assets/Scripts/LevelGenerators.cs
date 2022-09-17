using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerators : MonoBehaviour
{
    public GameObject[] RowsPrefabs;
    //public GameObject Coin;
    public float DistanceBetweenRows;
    public int NumberRows;
    public GameObject HeadSnake;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        for (int i = 0; i < NumberRows; i++)
        {
            int prefabIndex = Random.Range(0, RowsPrefabs.Length);
            Vector3 position = new Vector3(0, -21, -6+DistanceBetweenRows * i);
            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            GameObject body = Instantiate(RowsPrefabs[prefabIndex], position, rotation, transform); // body - это ряд из кубиков

            //var collisionComponent = body.GetComponent<Collision>();
            //collisionComponent.HeadSnake = HeadSnake.transform;

            //body.GetComponent<Collision>().HeadSnake = HeadSnake.transform;
            var arrayCollision = body.GetComponentsInChildren<Collision>(); //берем компоненту Collision у кубиков (т.к. кубик - дочерний объект ряда). Возвращает массив из компонент.

            foreach (Collision collision in arrayCollision) //пробегаемся по каждой компоненте и устанавливаем в поле для HeadSnake объект со сцены
            {
                collision.HeadSnake = HeadSnake.transform;
            }
        }
    }
}
