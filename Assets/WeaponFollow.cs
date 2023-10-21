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

    public CharacterController2D player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<CharacterController2D>();
    }

    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - _gunSprite.transform.position;
        difference.Normalize();
        
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        Debug.Log(player.m_FacingRight);
        if ((80 < rotZ && rotZ < 180) && player.m_FacingRight)
        {
            player.Flip();
        }
        if ((0 < rotZ && rotZ < 80) && !player.m_FacingRight)
        {
            player.Flip();
        }
        if ((-80 > rotZ && rotZ > -180) && player.m_FacingRight)
        {
            player.Flip();
        }
        if ((0 > rotZ && rotZ > -80) && !player.m_FacingRight)
        {
            player.Flip();
        }

        offset = player.offset;
        _gunSprite.transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
    }
    
}
