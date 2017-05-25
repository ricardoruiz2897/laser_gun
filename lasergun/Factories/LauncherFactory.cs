using System;

namespace lasergun
{
	public class LauncherFactory
	{
		static Lazy<LauncherFactory> self = new Lazy<LauncherFactory>(()=>new LauncherFactory());

		public static LauncherFactory Self {

			get{ 
				return self.Value;
			}

		}

		//create missile
		public event Action<Launcher> LauncherCreated;

		public LauncherFactory ()
		{
		}

		public Launcher CreateNew(){

			Launcher nLauncher = new Launcher();

			if (LauncherCreated != null) {

				LauncherCreated (nLauncher);

			}

			return nLauncher;
		}
	}
}


