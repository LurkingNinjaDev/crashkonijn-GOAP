﻿using System;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Classes.References;
using CrashKonijn.Goap.Core;
using CrashKonijn.Goap.Core.Interfaces;

namespace CrashKonijn.Goap.Sensors
{
    public abstract class LocalWorldSensorBase : ILocalWorldSensor
    {
        public IWorldKey Key => this.Config.Key;

        public IWorldSensorConfig Config { get; private set; }
        public void SetConfig(IWorldSensorConfig config) => this.Config = config;

        public abstract void Created();
        
        public abstract void Update();
        public Type[] GetKeys() => new[] { this.Key.GetType() };

        public void Sense(IWorldData data, IActionReceiver agent, IComponentReference references)
        {
            data.SetState(this.Key, this.Sense(agent, references));
        }
        
        public abstract SenseValue Sense(IActionReceiver agent, IComponentReference references);
    }
}