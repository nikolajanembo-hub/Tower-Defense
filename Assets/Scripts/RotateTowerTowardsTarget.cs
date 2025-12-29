using System;
using UnityEngine;

public class RotateTowerTowardsTarget : MonoBehaviour
{
    [SerializeField] private Tower tower;
    [SerializeField] private Transform pivot;
    [SerializeField] private float rotateSpeed;

    private Quaternion defaultRotation;

    private void Start()
    {
        defaultRotation = transform.rotation;
    }

    private void Update()
    {
        if (tower.Enemy != null)
        {
            Vector3 direction = (tower.Enemy.transform.position - pivot.position).normalized;
            direction.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotateSpeed * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, defaultRotation, rotateSpeed * Time.deltaTime);
        }
    }
}
