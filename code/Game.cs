using Sandbox;

namespace OhioRP;

public partial class MyGame : GameManager
{
	public MyGame()
	{
	}

	public override void ClientJoined( IClient client )
	{
		base.ClientJoined( client );
	}
}
