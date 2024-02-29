using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Food : MonoBehaviour
{
    public bool AllowGrow = false;
    public GameObject Player;
    public GameObject Walls;
    void Start()
    { if((SceneManager.GetActiveScene().buildIndex == 1))
        {
            Score.ScoreNum = 0;
        }
        else if((SceneManager.GetActiveScene().buildIndex == 2))
        {
            Score.ScoreNum = 50;
        }
        RandomizePosition();
    }
    void RandomizePosition()
    {
        float PosX =Random.Range(-8, 8);
        float PosZ=Random.Range(-8,8);

        Vector3 Position = new Vector3(Mathf.Round(PosX), 0.58f, Mathf.Round(PosZ));
        this.transform.position = Position;
        Collider[] collider = Physics.OverlapSphere(Position, 0.5f);
        foreach (Collider collider1 in collider)
        {
            if ((Player.GetComponent<Collider>() != collider1) && (Walls.GetComponentInChildren<Collider>() != collider1))
            {
                this.transform.position = Position;
            }
            else
            {
                RandomizePosition();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AllowGrow = true;
            Score.ScoreNum += 10;
            FindObjectOfType<SnakeMovement>().Speed += 0.2f;
            RandomizePosition();

        }
    }
}
