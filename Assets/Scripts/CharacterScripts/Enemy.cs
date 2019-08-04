using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType {
	Lich, Golem, Grunt
}

public class Enemy : MonoBehaviour {
  [SerializeField] EnemyType type = default;
  EnemySpawner originSpawner;
  
  public EnemyType Type => type;

  public  EnemySpawner OriginSpawner {
    get => originSpawner;
    set {
      Debug.Assert(originSpawner == null, "Redifined origin spawner!");
      originSpawner = value;
    }
  }

  public void Recycle() {originSpawner.Reclaim(this);}
}
