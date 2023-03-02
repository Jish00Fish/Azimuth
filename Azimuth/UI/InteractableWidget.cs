using Raylib_cs;

using System.Numerics;
using System.Runtime.CompilerServices;

namespace Azimuth.UI
{
	public abstract class InteractableWidget : Widget
	{
		public InteractionState state { get; private set; }

		public bool Interactable { get; set; } = true;

		private ColorBlock colors;

		protected InteractableWidget(Vector2 _position, Vector2 _size, ColorBlock _colors) : base(_position, _size)
		{
			colors = _colors;
			state = InteractionState.Normal;
		}

		public override void Update(Vector2 _mousePos)
		{
			base.Update(_mousePos);

			bool clicked = Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT);

			InteractionState oldState = state;

			if(state == InteractionState.Selected && !clicked)
			{
				state = focused ? InteractionState.Hovered : InteractionState.Normal;
			}
			else if(clicked && focused)
			{
				state = InteractionState.Selected;
			}
			else if(focused)
			{
				state = InteractionState.Hovered;
			}
			else
			{
				state = InteractionState.Normal;
			}

			if(!Interactable)
				state = InteractionState.Disabled;
			if(state != oldState)
				OnStateChange(state, oldState);
		}

		protected abstract void OnStateChange(InteractionState _state, InteractionState _oldState);


		protected Color ColorFromState()
		{
			switch(state)
			{
				case InteractionState.Normal:
					return colors.normal;
				case InteractionState.Hovered:
					return colors.hovered;
				case InteractionState.Selected:
					return colors.selected;
				case InteractionState.Disabled:
					return colors.disabled;
				default:
					return Color.BLANK;
			}
		}
	}
}