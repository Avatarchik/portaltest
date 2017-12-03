using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPuzzleElement{
    PuzzleElementType GetElementType();
    GameObject GetRootGameObject();
    GameObject GetLinkedElement();

}
