using UnityEngine;

namespace PlayerSystem
{
    public class PlayerMovement
    {
        private readonly Rigidbody2D _rigidbody;
        private float _speed;
        private float _jumpForce;

        public PlayerMovement(Rigidbody2D rigidbody, float speed, float jumpForce)
        {
            _rigidbody = rigidbody;
            _speed = speed;
            _jumpForce = jumpForce;
        }

        public void HorizontalMove(float x)
        {
            Vector2 force = new Vector2(x, 0);
            _rigidbody.AddForce(force * _speed, ForceMode2D.Force);
            if (Mathf.Abs(_rigidbody.velocity.x) > _speed)
                _rigidbody.velocity = new Vector2(x * _speed, _rigidbody.velocity.y);
        }
        
        public void Jump()
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce,ForceMode2D.Impulse);
            if(_rigidbody.velocity.x > _jumpForce)
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x,_jumpForce);
        }
    }
}
