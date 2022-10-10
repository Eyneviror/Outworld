
namespace Outworld.Utils.StateMashine
{
    public interface IState
    {
        public void Enter(SimpleStateMashine simpleStateMashine);
        public void LateUpdate(SimpleStateMashine simpleStateMashine);
        public void Update(SimpleStateMashine simpleStateMashine);
        public void Exit(SimpleStateMashine simpleStateMashine);
    }
}