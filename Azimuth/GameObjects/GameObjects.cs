using System.Numerics;

namespace Azimuth.GameObjects
{
	public class GameObjects
	{
		public Vector2 position;
		
		public virtual void Load() { }

		public virtual void Draw() { }

		public virtual void Update(float _deltaTime) { }

		public virtual void Unload() { }
	}
}