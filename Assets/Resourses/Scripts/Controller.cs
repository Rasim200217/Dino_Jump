using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
   [SerializeField] private float _jumpForce;
   [SerializeField] private float _speed;
   private Rigidbody2D _rigidbody2D;

   private void Start()
   {
      _rigidbody2D = GetComponent<Rigidbody2D>();
   }

   private void Update()
   {
      Jump();
      ChechingGround();
      Move();
   }

   private void Move()
   {
      _rigidbody2D.AddForce(new Vector2(_speed, 0));
   }

   private void Jump()
   {
      if (Input.GetKeyDown(KeyCode.Space) && onGround)
      {
         _rigidbody2D.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
      }
   }

   public bool onGround;
   public Transform GroundCheck;
   public float checkRadius = 0.2f;
   public LayerMask Ground;

   void ChechingGround()
   {
      onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
   }
   
}
