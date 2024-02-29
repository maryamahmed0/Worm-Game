using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeMovement : MonoBehaviour
{
    public float Speed=2;
    public float rotationSpeed=180;

    public List<Transform> Body = new List<Transform>();
    public GameObject BodyPreFab;

    public float minDistance=0.25f;
    float Distance;
    Transform CurBodyPart;
    Transform PrevBodyPart;

    public int initalSize;
    GameManager manager;

    void Start()
    {
      for (int i = 0; i < initalSize; i++)
        {
            Grow();
        }
    }

    void Update()
    {
        Move();
        Growth();
        if(Score.ScoreNum == 50 && (SceneManager.GetActiveScene().buildIndex == 1))
        {
            SceneManager.LoadScene(3);
        }
        else if (Score.ScoreNum == 100)
        {
            SceneManager.LoadScene(4);
        }
    }

    public void Move()
    {
       
        Body[0].Translate(Body[0].forward * Speed * Time.smoothDeltaTime,Space.World);

        if (Input.GetAxis("Horizontal") != 0)
        {
            float Rotation = Input.GetAxis("Horizontal");
            Body[0].Rotate(Vector3.up * Rotation * rotationSpeed * Time.deltaTime);
        }
        for (int i = 1; i < Body.Count; i++)
        {
            CurBodyPart = Body[i];
            PrevBodyPart = Body[i-1];
            Distance=Vector3.Distance(CurBodyPart.position, PrevBodyPart.position);
            Vector3 newpos = PrevBodyPart.position;
            newpos.y = Body[0].position.y;
            float interplationTime = Distance * Time.deltaTime / minDistance * Speed;
            if(interplationTime>0.5)
            {
                interplationTime = 0.5f;
            }
            CurBodyPart.position = Vector3.Slerp(CurBodyPart.position, PrevBodyPart.position, interplationTime);
            CurBodyPart.rotation=Quaternion.Slerp(CurBodyPart.rotation,PrevBodyPart.rotation, interplationTime);
                
        }

    }
    public void Grow()
    {
        Transform bodyPart =(Instantiate(BodyPreFab, Body[Body.Count - 1].position, Body[Body.Count-1].rotation) as GameObject).transform;
        bodyPart.SetParent(transform);
        Body.Add(bodyPart);
        FindObjectOfType<Food>().AllowGrow = false;
    }
    private void Growth()
    {
        if(FindObjectOfType<Food>().AllowGrow)
        {
            Grow();
        }
    }

}
