using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class EnemySpawner : ScriptableObject {

	[SerializeField] Enemy lichPrefab = default;
	[SerializeField] Enemy golemPrefab = default;
	[SerializeField] Enemy gruntPrefab = default;

	Scene contentScene;

	public Enemy Get (EnemyType type) {
		switch (type) {
			case EnemyType.Lich: return Get(lichPrefab);
			case EnemyType.Golem: return Get(golemPrefab);
			case EnemyType.Grunt: return Get(gruntPrefab);
		}
		Debug.Assert(false, "Unsupported type: " + type);
		return null;
	}

	public void Reclaim (Enemy enemy) {
		Debug.Assert(enemy.OriginSpawner == this, "Wrong factory reclaimed!");
		Destroy(enemy.gameObject);
	}

	Enemy Get (Enemy prefab) {
		Enemy instance = Instantiate(prefab);
		instance.OriginSpawner = this;
		MoveToFactoryScene(instance.gameObject);
		return instance;
	}

	void MoveToFactoryScene (GameObject o) {
		if (!contentScene.isLoaded) {
			if (Application.isEditor) {
				contentScene = SceneManager.GetSceneByName(name);
				if (!contentScene.isLoaded) {
					contentScene = SceneManager.CreateScene(name);
				}
			}
			else {
				contentScene = SceneManager.CreateScene(name);
			}
		}
		SceneManager.MoveGameObjectToScene(o, contentScene);
	}
}