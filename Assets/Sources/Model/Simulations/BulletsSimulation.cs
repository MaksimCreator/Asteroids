﻿using UnityEngine;

namespace Asteroids.Model
{
    public class BulletsSimulation : Simulation<Bullet>
    {
        private readonly Timers<PlacedEntity> _timers = new Timers<PlacedEntity>();

        public void Simulate(Bullet bullet, Vector2 startPosition, Vector2 direction)
        {
            PlacedEntity placedEntity = null;
            var trajectory = new Trajectory(bullet.Speed, startPosition, direction, (_) => _timers.GetAccumulatedTime(placedEntity));
            placedEntity = new PlacedEntity(bullet, trajectory);

            _timers.Start(placedEntity, bullet.Lifetime, Stop);
            
            Simulate(placedEntity);
        }

        public override void Update(float deltaTime)
        {
            _timers.Tick(deltaTime);
        }

        protected override void OnStoped(PlacedEntity placedEntity)
        {
            _timers.StopAll(placedEntity);
        }
    }
}
