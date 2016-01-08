﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewKillingStory.View
{
    class ParticleSystem
    {
        private Particle[] particles;
        private const int maxParticles = 20;
        Vector2 _systemModelStartPosition;

        public ParticleSystem(Vector2 systemModelStartPosition)
        {
            _systemModelStartPosition = systemModelStartPosition;
            particles = new Particle[maxParticles];
            int i;
            for (i = 0; i < maxParticles; i++)
            {
                particles[i] = new Particle(i, systemModelStartPosition);//visar vart mitten är och skickar med i
            }
        }
        public void Update(float elapsedTime)
        {
            int i;
            for (i = 0; i < maxParticles; i++)
            {
                particles[i].Update(elapsedTime);
            }
        }
        public void Draw(SpriteBatch spritebatch, Camera camera, Texture2D texture)
        {
            int i;
            for (i = 0; i < maxParticles; i++)
            {
                particles[i].Draw(spritebatch, camera, texture);
            }
        }
    }
}
