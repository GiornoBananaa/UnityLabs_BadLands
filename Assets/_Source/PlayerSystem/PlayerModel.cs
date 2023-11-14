namespace PlayerSystem
{
    public class PlayerModel
    {
        private float _speed;
    
        public float Speed => _speed;

        public PlayerModel(float speed)
        {
            _speed = speed;
        }
    }
}
