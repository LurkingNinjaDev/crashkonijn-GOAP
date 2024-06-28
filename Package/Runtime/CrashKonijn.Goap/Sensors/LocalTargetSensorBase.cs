﻿using System;
using CrashKonijn.Goap.Classes.References;
using CrashKonijn.Goap.Core.Interfaces;

namespace CrashKonijn.Goap.Sensors
{
    public abstract class LocalTargetSensorBase : ILocalTargetSensor
    {
        public ITargetKey Key => this.Config.Key;
        public ITargetSensorConfig Config { get; private set; }
        public void SetConfig(ITargetSensorConfig config) => this.Config = config;
        
        public abstract void Created();
        public abstract void Update();
        public Type[] GetKeys() => new[] { this.Key.GetType() };

        public void Sense(IWorldData worldData, IActionReceiver agent, IComponentReference references)
        {
            worldData.SetTarget(this.Key, this.Sense(agent, references));
        }
        
        public abstract ITarget Sense(IActionReceiver agent, IComponentReference references);
    }
}