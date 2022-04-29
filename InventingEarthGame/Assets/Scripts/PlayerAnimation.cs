using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    public string[] staticDirections = {"Static N", "Static W", "Static S", "Static E"};
    public string[] runDirections = {"Run N", "Run W", "Run S", "Run E" };

    int lastDirection;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void SetDirections(Vector2 _direction)
    {
        string[] directionArray = null;

        if(_direction.magnitude < 0.01)
        {
            directionArray = staticDirections;
        } else
        {
            directionArray = runDirections;
            lastDirection = DirectionToIndex(_direction);
        }

        anim.Play(directionArray[lastDirection]);
    }

    //Converts Vector 2 direction to an Index to a slice around a cirlce
    private int DirectionToIndex(Vector2 _direction)
    {
        Vector2 norDir = _direction.normalized;
        float step = 360 / 4;
        float offset = step / 2;
       
        float angle = Vector2.SignedAngle(Vector2.up, norDir);
        angle += offset;
        if(angle < 0)
        {
            angle += 360;
        }

        float stepCount = angle / step;

        return Mathf.FloorToInt(stepCount);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
