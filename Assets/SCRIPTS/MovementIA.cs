using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MovementIA : MonoBehaviour
{
    private GameObject target;
    public float speed = 1.1f;

    void Start()
    {
        target = FindObjectOfType<LateralMovements>().gameObject;
    }

    void Update()
    {
        Vector2 newPosition = Vector2.MoveTowards(transform.position,new Vector2(target.transform.position.x, transform.position.y), speed * Time.deltaTime);

        transform.position = newPosition;
    }
}