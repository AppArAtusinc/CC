using StudentSimulator.SaveSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SimpleGameTypes
{
    public struct SimpleVector3
    {
        [Save]
        public float x;
        [Save]
        public float y;
        [Save]
        public float z;

        public SimpleVector3(Vector3 vector)
        {
            x = vector.x;
            y = vector.y;
            z = vector.z;
        }

        static public implicit operator Vector3(SimpleVector3 Vector)
        {
            return Vector.ToVector3();
        }

        public Vector3 ToVector3()
        {
            return new Vector3(x, y, z);
        }
        public Quaternion ToQuaternion()
        {
            return Quaternion.Euler(new Vector3(x, y, z));
        }
        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", x, y, z);
        }
    }
    public struct SimpleQuaternion
    {
        [Save]
        public float x;
        [Save]
        public float y;
        [Save]
        public float z;
        [Save]
        public float w;

        public SimpleQuaternion(Quaternion quaternion)
        {
            x = quaternion.x;
            y = quaternion.y;
            z = quaternion.z;
            w = quaternion.w;
        }

        public Quaternion ToQuaterion()
        {
            return new Quaternion(x, y, z, w);
        }

        public override string ToString()
        {
            return string.Format("({0},{1},{2},{3})", x, y, z, w);
        }
    }

    public class SimpleTransform
    {
        Transform data;

        SimpleVector3 position;
        [Save]
        public SimpleVector3 Position
        {
            get
            {
                if (data != null)
                    return new SimpleVector3(data.position);
                return position;
            }
            set
            {
                if (data != null)
                    data.position = value.ToVector3();
                position = value;
            }
        }

        SimpleQuaternion rotation;
        [Save]
        public SimpleQuaternion Rotation
        {
            get
            {
                if (data != null)
                    return new SimpleQuaternion(data.rotation);
                return rotation;
            }
            set
            {
                if (data != null)
                    data.rotation = new Quaternion(value.x, value.y, value.z, value.w);
                rotation = value;
            }
        }

        SimpleVector3 scale;
        [Save]
        public SimpleVector3 Scale
        {
            get
            {
                if (data != null)
                    return new SimpleVector3(data.localScale);
                return scale;
            }
            set
            {
                if (data != null)
                    data.localScale = value.ToVector3();
                scale = value;
            }
        }

        public SimpleTransform(Transform transform)
        {
            data = transform;
        }

        public SimpleTransform()
        {
            position = new SimpleVector3();
            rotation = new SimpleQuaternion();
            scale = new SimpleVector3();
        }
    }
}
