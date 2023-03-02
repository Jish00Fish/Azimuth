using System.Security.Cryptography.X509Certificates;

namespace Azimuth.GameStates
{
	public class GameStateManager
	{
		// IGameStates has an s, IGameStates has an s
		private static Dictionary<string, IGameStates> states = new Dictionary<string, IGameStates>();
		private static List<IGameStates> activeStates = new List<IGameStates>();

		private static List<Action> activateActions = new List<Action>();
		private static List<Action> deactivateActions = new List<Action>();

		public static void AddState(IGameStates _state)
		{
			if(!states.ContainsKey(_state.ID))
				states.Add(_state.ID, _state);
		}

		public static void RemoveState(IGameStates _state)
		{
			if(states.ContainsKey(_state.ID))
				states.Remove(_state.ID);
		}

		public static void Update(float _deltaTime)
		{
			foreach(Action action in deactivateActions)
				action?.Invoke();
					
			foreach(Action action in activateActions)
				action?.Invoke();
			
			deactivateActions.Clear();
			activateActions.Clear();

			foreach(IGameStates state in activeStates)
			{
				state.Update(_deltaTime);
			}
		}

		public static void Draw()
		{
			foreach(IGameStates state in activeStates)
			{
				state.Draw();
			}
		}

		public static void ActivateState(string _id)
		{
			if(states.ContainsKey(_id))
			{
				activateActions.Add(() =>
				{
					activeStates.Add(states[_id]);
					states[_id].Load();
				});
			}
		}

		public static void DeactivateState(string _id)
		{
			if(states.ContainsKey(_id) && activeStates.Contains(states[_id]))
			{
				deactivateActions.Add(() =>
				{
					activeStates.Remove(states[_id]);
					states[_id].Unload();
				});
			}
		}
		
	}
}