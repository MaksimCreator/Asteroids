﻿using System;

namespace Asteroids.Model
{
    public class LaserGun : DefaultGun,ILaserGun
    {
        private int _bulletsPerShot;

        public int Bullets { get; private set; }
        public int MaxBullets { get; private set; }

        public event Action ShotAdd;

        public LaserGun(int bullets, int bulletsPerShot = 1)
        {
            if (bulletsPerShot < 0)
                throw new ArgumentOutOfRangeException(nameof(bulletsPerShot));

            if (bullets <= 0)
                throw new ArgumentOutOfRangeException(nameof(bullets));

            Bullets = bullets;
            MaxBullets = bullets;
            _bulletsPerShot = bulletsPerShot;
        }

        public override bool CanShoot() => Bullets >= _bulletsPerShot;

        public void TryAddShot()
        {
            if (Bullets + _bulletsPerShot > MaxBullets)
                return;

            Bullets += _bulletsPerShot;
            ShotAdd?.Invoke();
        }

        protected override Bullet GetBullet()
        {
            Bullets -= _bulletsPerShot;
            return new LaserGunBullet();
        }
    }
}
