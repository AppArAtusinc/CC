using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SimpleGameTypes
{
	public struct SimpleVector3
	{
		public double x;
		public double y;
		public double z;

		public SimpleVector3(Vector3 vector)
		{
			x = vector.x;
			y = vector.y;
			z = vector.z;
		}
		public Vector3 ToVector3()
		{
			return new Vector3((float)x, (float)y, (float)z);
		}
		public Quaternion ToQuaternion()
		{
			return Quaternion.EulerAngles(new Vector3((float)x, (float)y, (float)z));
		}
	
	}
	public struct SimpleQuaternion
	{
		public double x;
		public double y;
		public double z;
		public double w;
		
		public SimpleQuaternion(Quaternion quaternion)
		{
			x = quaternion.x;
			y = quaternion.y;
			z = quaternion.z;
			w = quaternion.w;
		}

		public Quaternion ToQuaterion()
		{
			return new Quaternion((float)x, (float)y, (float)z, (float)w);
		}
	}

	public class SimpleTransform
	{
		Transform data;

		SimpleVector3 position;
		public SimpleVector3 Position
		{
			get
			{
				if(data != null)
					return new SimpleVector3(data.position);
				return position;
			}
			set
			{
				if (data != null)
					data.position = value.ToVector3();
				else
					position = value;
			}
		}

		SimpleQuaternion rotation;
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
					data.rotation.Set((float)value.x, (float)value.y, (float)value.z, (float)value.w);
				else
					rotation = value;
			}
		}

		SimpleVector3 scale;
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
				else
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
