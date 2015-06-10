using System;

namespace Entity
{
	public class LinkToEntity
	{
		PoolEntity value;
		public UInt64 Id;

		public PoolEntity GetValue()
		{
			return value;
		}

		public bool Link()
		{
			value = Game.GetInstance().Entites.Actor.Find(o => o.Id == Id);

			return IsValid();
		}

		public bool IsValid()
		{
			return value != null;
		}
	}
}
