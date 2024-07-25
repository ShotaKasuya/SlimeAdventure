using InGame.Interface;
using R3;

namespace InGame.Gimmick.Provider
{
    public class EmptyGimmickMessageEventProvider : IMessageEventProvider
    {
        public Observable<MessageEvent> MessageEventObservable => null;
    }
}