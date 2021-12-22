using System.Collections.Generic;

namespace Tanks_Game_Core
{
    public class GameObject
	{
		public List<IComponent> Components { get; private set; } = new List<IComponent>();
		public void AddComponent(IComponent component)
		{
			if (!Components.Contains(component))
				Components.Add(component);
		}

		public void RemoveComponent(IComponent component)
		{
			if (Components.Contains(component))
				Components.Remove(component);
		}

		public T GetComponent<T>() where T : IComponent
		{
			foreach (IComponent component in Components)
				if (component.GetType() == typeof(T))
					return (T)component;

			return default(T);
		}
	}
}
