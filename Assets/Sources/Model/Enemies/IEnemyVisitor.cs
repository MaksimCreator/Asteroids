namespace Asteroids.Model
{
    public interface IEnemyVisitor
    {
        void Visit(Asteroid enemy);
        void Visit(PartOfAsteroid enemy);
        void Visit(Ufo enemy);
    }
}
