namespace Asteroids.Model
{
    public interface ILaserGun
    {
        public int Bullets { get; }
        public int MaxBullets { get; }

        void TryAddShot();
    }
}
