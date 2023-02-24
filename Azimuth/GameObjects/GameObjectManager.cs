namespace Azimuth.GameObjects
{
	public static class GameObjectManager  // gameObject and GameObjects swapped
	{
		private static List<GameObjects> gameObject = new List<GameObjects>();

		public static void Spawn(GameObjects _gameObjects)
		{
			if(!gameObject.Contains(_gameObjects))
			{
				gameObject.Add(_gameObjects);
				_gameObjects.Load();
			}
		}

		public static void Destroy(GameObjects _gameObjects)
		{
			if(gameObject.Contains(_gameObjects))
			{
				_gameObjects.Unload();
				gameObject.Remove(_gameObjects);
			}
		}

		public static void Update(float _deltaTime)
		{
			foreach(GameObjects gameObjects in gameObject)
				gameObjects.Update(_deltaTime);
		}

		public static void Draw()
		{
			foreach(GameObjects gameObjects in gameObject)
				gameObjects.Draw();
		}
	}
}