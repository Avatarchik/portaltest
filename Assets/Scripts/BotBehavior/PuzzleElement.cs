using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public abstract class PuzzleElement : NetworkBehaviour{
   public abstract PuzzleElementType GetElementType();
   public abstract GameObject GetRootGameObject();
   public abstract GameObject GetLinkedElement();

}
