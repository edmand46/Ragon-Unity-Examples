using Ragon.Client;
using Ragon.Common;
using UnityEngine;

namespace Ragon.Examples.Tanks
{
  public class TankPayload: IRagonPayload
  {
    public Vector3 Position;
    
    public void Serialize(RagonSerializer serializer)
    {
      serializer.WriteFloat(Position.x);
      serializer.WriteFloat(Position.y);
      serializer.WriteFloat(Position.z);
    }

    public void Deserialize(RagonSerializer serializer)
    {
      Position.x = serializer.ReadFloat();
      Position.y = serializer.ReadFloat();
      Position.z = serializer.ReadFloat();
    }
  }
}