namespace Asteroids.Model
{
    public class Score
    {
        public int Value => _enemyVisitor.Score;

        private EnemyVisitor _enemyVisitor = new EnemyVisitor();

        public void OnKill(Enemy enemy) => _enemyVisitor.Visit((dynamic)enemy);

        private class EnemyVisitor : IEnemyVisitor
        {
            public int Score { get; private set; }

            public void Visit(Asteroid enemy)
            {
                Score += 15;
            }

            public void Visit(PartOfAsteroid enemy)
            {
                Score += 8;
            }

            public void Visit(Ufo enemy)
            {
                Score += 25;
            }
        }
    }
}
