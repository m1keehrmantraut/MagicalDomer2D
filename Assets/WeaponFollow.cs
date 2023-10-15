using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFollow : MonoBehaviour
{
    [SerializeField] private float offset;

    [SerializeField] private SpriteRenderer _gunSprite;
    private float scale;

    private float gunRotation;

    private CharacterController2D player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<CharacterController2D>();
    }

    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        
        offset = player.offset;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        
        
    }
    
}
