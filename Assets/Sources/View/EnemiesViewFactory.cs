using Asteroids.Model;
using UnityEngine;

public class EnemiesViewFactory : TransformableViewFactory<Enemy>
{
    [SerializeField] private TransformableView _asteroid;
    [SerializeField] private TransformableView _partOfAsteroid;
    [SerializeField] private TransformableView _ufo;

    private EnemyVisiter _enemyVisiter;

    private void Awake() => _enemyVisiter = new EnemyVisiter(_asteroid,_partOfAsteroid,_ufo);

    protected override TransformableView GetTemplate(Enemy enemy)
    {
        _enemyVisiter.Visit((dynamic)enemy);
        return _enemyVisiter.Templay;
    }

    private class EnemyVisiter : IEnemyVisitor
    {
        private readonly TransformableView _asteroid;
        private readonly TransformableView _partOfAsteroid;
        private readonly TransformableView _ufo;

        public EnemyVisiter(TransformableView asteroid, TransformableView partOfAsteroid, TransformableView ufo)
        {
            _asteroid = asteroid;
            _partOfAsteroid = partOfAsteroid;
            _ufo = ufo;
        }

        public TransformableView Templay { get; private set; }

        public void Visit(Asteroid enemy) => Templay = _asteroid;

        public void Visit(PartOfAsteroid enemy) => Templay = _partOfAsteroid;

        public void Visit(Ufo enemy) => Templay = _ufo;
    }
}
