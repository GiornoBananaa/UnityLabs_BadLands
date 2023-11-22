namespace PlayerSystem
{
    public class PlayerModel
    {
        private float _speed;
        private float _jumpForce;
    
        public float Speed => _speed;
        public float JumpForce => _jumpForce;

        public PlayerModel(float speed, float jumpForce)
        {
            _speed = speed;
            _jumpForce = jumpForce;
        }
    }
}
