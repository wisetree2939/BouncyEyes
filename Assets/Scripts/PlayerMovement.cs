using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 5f; // movement speed
    [SerializeField] private float _bounceForce = 10f; // how strong the bounce is
    [SerializeField] private Rigidbody _rigidbody;
    

    private int _bounceStreak;
    public TextMeshProUGUI BounceStreakText;

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 moveDirection = new Vector3(moveHorizontal, 0, 0);
        transform.Translate(moveDirection * _playerSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("bouncy"))
        {
            // Reset Y velocity before applying bounce (so bounces are consistent)
            Vector3 velocity = _rigidbody.velocity;
            velocity.y = 0;
            _rigidbody.velocity = velocity;

            // Apply upward bounce force
            _rigidbody.AddForce(Vector3.up * _bounceForce, ForceMode.Impulse);

            // Update streak
            _bounceStreak++;
            if (_bounceForce < 7)
            {
                _bounceForce += 0.05f;
            }
            BounceStreakText.text = _bounceStreak.ToString();
        }
        else
        {
            _bounceStreak = 0;
            BounceStreakText.text = _bounceStreak.ToString();
        }
    }
}

