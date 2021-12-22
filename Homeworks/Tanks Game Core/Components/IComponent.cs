using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks_Game_Core
{
    public interface IComponent
    {
		public void Start();
		public void Update();
	}
}
