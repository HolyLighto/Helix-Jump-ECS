using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class EcsStartup : MonoBehaviour {
        EcsWorld _world;
        EcsSystems _updateSystems;
        EcsSystems _fixedUpdateSystems;
        [SerializeField] private Prefabs _prefabs;
        [SerializeField] private Camera _camera;
        [SerializeField] private SceneObjects _sceneObjects;

        void Awake () {
            // void can be switched to IEnumerator for support coroutines.
            
            _world = new EcsWorld ();
            _updateSystems = new EcsSystems (_world);
            _fixedUpdateSystems = new EcsSystems(_world);

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_updateSystems);
#endif
            _updateSystems
                // register your systems here, for example:
                .Add(new InitGameSystem())
                .Add(new DragTowerSystem())
                .Add(new InputSystem())
                .Add(new CameraFollowSystem())
                .Add(new ScoreTakeSystem())
                .Add(new ScoreUISystem())
                .Add(new ShowMenuSystem())
                .Add(new FloorExposionSystem())
                

                .OneFrame<ShowMenuComponent>()
                .OneFrame<ScoreTakeComponent>()
                .OneFrame<ScoreComboComponent>()
                .OneFrame<FloorExposionComponent>()
                


                // inject service instances here (order doesn't important), for example:
                .Inject(_prefabs)
                .Inject(_camera)
                .Inject(_sceneObjects)
                .Init ();

            _fixedUpdateSystems
                .Add(new BallJumpSystem())
                .Add(new BallGravitySystem())
                .OneFrame<BallCollisionComponent>()
                .Init();
        }



        void Update () {

            _updateSystems?.Run();
        }

        private void FixedUpdate()
        {
            _fixedUpdateSystems?.Run();
        }

        void OnDestroy () {
            if (_updateSystems != null) {
                _updateSystems.Destroy ();
                _updateSystems = null;
                _world.Destroy ();
                _world = null;
            }
        }
    }
}