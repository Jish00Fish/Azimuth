using Azimuth;
using Azimuth.UI;

using Raylib_cs;

using System.Numerics;

namespace Azimuth_Test
{
	public class AzimuthTestGame : Game
	{
		private ImageWidget image;
		private Button button;


		private void OnClickButton()
		{
			Console.WriteLine("Hello world!");
		}
		
		public override void Load()
		{
			image = new ImageWidget(Vector2.Zero, new Vector2(800, 700), "shacoPoroAngry");
			button = new Button(Vector2.Zero, new Vector2(150, 75), Button.RenderSettings.normal);
			button.SetDrawLayer(100);
			button.AddListener(OnClickButton);
			
			button.AddListener(() =>
			{
				UIManager.Add(image);
				
			});
			
			UIManager.Add(button);
			
			
		}

		

		public override void Unload()
		{
			
		}
	}
}