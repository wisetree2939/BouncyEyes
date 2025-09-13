using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int _playerSpeed;
    [SerializeField] private Rigidbody _rigidbody;
    private float _bounceStreak;

    public TextMeshProUGUI BounceStreakText;

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        
        Vector3 moveDirection = new Vector3(moveHorizontal,0, 0);
        transform.Translate(moveDirection * _playerSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "bouncy")
        {
            _bounceStreak += 1;
            BounceStreakText.text = _bounceStreak.ToString();
        }
        else
        {
            _bounceStreak = 0;
        }
    }
}

