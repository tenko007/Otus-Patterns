
using System;
using System.Numerics;

namespace Tanks_Game_Core
{
    public class Transform : IMovable, IRotatable, IScalable, IComponent
    {
        private Vector3 position;
        private Vector3 rotation;
        private Vector3 scale;

        public Vector3 Position
        {
            get => position;
            set
            {
                CheckRules(value);
                position = value;
            }
        }
        public Vector3 Rotation
        {
            get => rotation;
            set
            {
                CheckRules(value);
                rotation = value;
            }
        }
        public Vector3 Scale
        {
            get => scale;
            set
            {
                CheckRules(value);
                scale = value;
            }
        }
        
        public void Start()
        {
            throw new System.NotImplementedException();
        }
        public void Update()
        {
            throw new System.NotImplementedException();
        }

        private void CheckRules(Vector3 vector)
        {
            float[] nums = new float[3] { vector.X, vector.Y, vector.Z };
            foreach (float num in nums)
            {
                if (float.IsNaN(num)) throw new ArgumentOutOfRangeException();
                if (float.IsInfinity(num)) throw new ArgumentOutOfRangeException();
            }
        }
    }
}
