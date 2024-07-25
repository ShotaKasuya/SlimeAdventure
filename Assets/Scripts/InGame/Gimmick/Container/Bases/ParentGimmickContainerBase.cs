using System;
using SceneTransition;
using InGame.Gimmick.Entity;
using InGame.Gimmick.Logic;
using InGame.Gimmick.Mask;
using InGame.Gimmick.Provider;
using InGame.Gimmick.Serializable;
using InGame.Interface;
using R3;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace InGame.Gimmick.Container.Bases
{
    public class ParentGimmickContainerBase : LifetimeScope, IMessageEventProvider, ICameraEventProvider
    {
        [SerializeField] protected EventMaskType eventMaskType;
        [SerializeField] private CameraEventOption cameraEventOption;
        [SerializeField] private MessageEventOption messageEventOption;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(cameraEventOption);
            builder.RegisterInstance(messageEventOption);

            builder.Register<GimmickMessageEventProvider>(Lifetime.Singleton).AsImplementedInterfaces();
            switch (eventMaskType)
            {
                case EventMaskType.AllLightBurning:
                    builder.Register<IEventMaskable, WhenAllLightBurn>(Lifetime.Singleton);
                    break;
                case EventMaskType.SeriesCircuit:
                    builder.Register<IEventMaskable, WhenSeriesCircuit>(Lifetime.Singleton);
                    break;
                case EventMaskType.ParallelCircuit:
                    builder.Register<IEventMaskable, WhenParallelCircuit>(Lifetime.Singleton);
                    break;
                case EventMaskType.OpenKeyUsed:
                    builder.Register<IEventMaskable, WhenUsedKey>(Lifetime.Singleton);
                    break;
                case EventMaskType.SwitchOn:
                    builder.Register<IEventMaskable, WhenSwitchPush>(Lifetime.Singleton);
                    break;
                case EventMaskType.AllSwitchOn:
                    builder.Register<IEventMaskable, WhenAllSwitchOn>(Lifetime.Singleton);
                    break;
                case EventMaskType.BurnedInOrder:
                    builder.Register<IEventMaskable, WhenInOrder>(Lifetime.Singleton);
                    builder.Register<GimmickResetLogic>(Lifetime.Singleton);
                    builder.Register<EventHistoryEntity>(Lifetime.Singleton);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        protected void Start()
        {
            Container.TryResolve(typeof(GimmickResetLogic), out var _);
        }

        public Observable<MessageEvent> MessageEventObservable =>
            Container.Resolve<IMessageEventProvider>().MessageEventObservable;

        public Observable<CameraEvent> CameraEventObservable =>
            Container.Resolve<ICameraEventProvider>().CameraEventObservable;
    }
}