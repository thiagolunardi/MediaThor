/*
The MIT License (MIT)

Copyright (c) 2016 Maksim Volkau

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/

/*
========================================================================================================
NOTE: The code below is generated automatically at compile-time and not supposed to be changed by hand.
========================================================================================================
There are 4 generation issues (may be not an error dependent on context):

The issues with run-time registrations may be solved by `container.RegisterPlaceholder<T>()` 
in Registrations.ttinclude. Then you can replace placeholders using `DryIocZero.Container.Register`
at runtime.

--------------------------------------------------------------------------------------------------------
1. MediaThor.Pipeline.IRequestPreProcessor<>
Error: Resolving open-generic service type is not possible for type: MediaThor.Pipeline.IRequestPreProcessor<>.
2. MediaThor.Pipeline.IRequestPostProcessor<,> {ServiceKey=DefaultKey(0)}
Error: Resolving open-generic service type is not possible for type: MediaThor.Pipeline.IRequestPostProcessor<,>.
3. MediaThor.Pipeline.IRequestPostProcessor<,> {ServiceKey=DefaultKey(1)}
Error: Resolving open-generic service type is not possible for type: MediaThor.Pipeline.IRequestPostProcessor<,>.
4. MediaThor.INotificationHandler<MediaThor.Examples.Ponged> {RequiredServiceType=MediaThor.INotificationHandler<>}
Error: Open-generic service does not match with registered open-generic implementation constraints MediaThor.Examples.ConstrainedPingedHandler<> when resolving: MediaThor.Examples.ConstrainedPingedHandler<>: MediaThor.INotificationHandler<MediaThor.Examples.Ponged> {RequiredServiceType=MediaThor.INotificationHandler<>} #42
  from container.
*/

using System;
using System.Linq; // for Enumerable.Cast method required by LazyEnumerable<T>
using System.Collections.Generic;
using System.Threading;
using ImTools;
using static DryIocZero.ResolveManyResult;

namespace DryIocZero
{
    partial class Container
    {
        [ExcludeFromCodeCoverage]
        partial void GetLastGeneratedFactoryID(ref int lastFactoryID)
        {
            lastFactoryID = 60; // generated: equals to last used Factory.FactoryID 
        }

        [ExcludeFromCodeCoverage]
        partial void ResolveGenerated(ref object service, Type serviceType)
        {
            if (serviceType == typeof(MediaThor.INotificationHandler<MediaThor.Examples.Ponged>))
                service = Get10_INotificationHandler(this);

            else
            if (serviceType == typeof(MediaThor.INotificationHandler<MediaThor.INotification>))
                service = Get11_INotificationHandler(this);

            else
            if (serviceType == typeof(MediaThor.IRequestHandler<MediaThor.Examples.Ping, MediaThor.Examples.Pong>))
                service = Get12_IRequestHandler(this);

            else
            if (serviceType == typeof(MediaThor.IRequest<MediaThor.Examples.Pong>))
                service = Get13_IRequest(this);

            else
            if (serviceType == typeof(MediaThor.IRequest))
                service = Get16_IRequest(this);

            else
            if (serviceType == typeof(MediaThor.IRequestHandler<MediaThor.Examples.Jing, MediaThor.Unit>))
                service = Get17_IRequestHandler(this);

            else
            if (serviceType == typeof(MediaThor.IMediator))
                service = Get18_IMediator(this);

            else
            if (serviceType == typeof(MediaThor.IRequest<MediaThor.Unit>))
                service = Get19_IRequest(this);

            else
            if (serviceType == typeof(MediaThor.INotificationHandler<MediaThor.Examples.Pinged>))
                service = Get20_INotificationHandler(this);
        }

        [ExcludeFromCodeCoverage]
        partial void ResolveGenerated(ref object service,
            Type serviceType, object serviceKey, Type requiredServiceType, Request preRequestParent, object[] args)
        {
            if (serviceType == typeof(MediaThor.IPipelineBehavior<MediaThor.Examples.Ping, MediaThor.Examples.Pong>)) 
            {
                if (DefaultKey.Of(0).Equals(serviceKey))
                    service = Get0_IPipelineBehavior(this);

                else
                if (DefaultKey.Of(1).Equals(serviceKey))
                    service = Get2_IPipelineBehavior(this);

                else
                if (DefaultKey.Of(2).Equals(serviceKey))
                    service = Get4_IPipelineBehavior(this);
            }

            else
            if (serviceType == typeof(MediaThor.IPipelineBehavior<MediaThor.Examples.Jing, MediaThor.Unit>)) 
            {
                if (DefaultKey.Of(0).Equals(serviceKey))
                    service = Get1_IPipelineBehavior(this);

                else
                if (DefaultKey.Of(1).Equals(serviceKey))
                    service = Get3_IPipelineBehavior(this);

                else
                if (DefaultKey.Of(2).Equals(serviceKey))
                    service = Get5_IPipelineBehavior(this);
            }

            else
            if (serviceType == typeof(MediaThor.INotification)) 
            {
                if (DefaultKey.Of(0).Equals(serviceKey))
                    service = Get6_INotification(this);

                else
                if (DefaultKey.Of(1).Equals(serviceKey))
                    service = Get7_INotification(this);
            }

            else
            if (serviceType == typeof(MediaThor.IBaseRequest)) 
            {
                if (DefaultKey.Of(0).Equals(serviceKey))
                    service = Get8_IBaseRequest(this);

                else
                if (DefaultKey.Of(1).Equals(serviceKey))
                    service = Get9_IBaseRequest(this);
            }

            else
            if (serviceType == typeof(MediaThor.INotificationHandler<MediaThor.Examples.Pinged>)) 
            {
                if (DefaultKey.Of(0).Equals(serviceKey))
                    service = Get14_INotificationHandler(this);

                else
                if (DefaultKey.Of(1).Equals(serviceKey))
                    service = Get15_INotificationHandler(this);
            }
        }

        [ExcludeFromCodeCoverage]
        partial void ResolveManyGenerated(ref IEnumerable<ResolveManyResult> services, Type serviceType) 
        {
            services = ResolveManyGenerated(serviceType);
        }

        [ExcludeFromCodeCoverage]
        private IEnumerable<ResolveManyResult> ResolveManyGenerated(Type serviceType)
        {
            if (serviceType == typeof(MediaThor.IPipelineBehavior<MediaThor.Examples.Ping, MediaThor.Examples.Pong>))
            {
                yield return Of(Get0_IPipelineBehavior, DefaultKey.Of(0), typeof(MediaThor.IPipelineBehavior<,>));
                yield return Of(Get2_IPipelineBehavior, DefaultKey.Of(1), typeof(MediaThor.IPipelineBehavior<,>));
                yield return Of(Get4_IPipelineBehavior, DefaultKey.Of(2), typeof(MediaThor.IPipelineBehavior<,>));
            }

            if (serviceType == typeof(MediaThor.IPipelineBehavior<MediaThor.Examples.Jing, MediaThor.Unit>))
            {
                yield return Of(Get1_IPipelineBehavior, DefaultKey.Of(0), typeof(MediaThor.IPipelineBehavior<,>));
                yield return Of(Get3_IPipelineBehavior, DefaultKey.Of(1), typeof(MediaThor.IPipelineBehavior<,>));
                yield return Of(Get5_IPipelineBehavior, DefaultKey.Of(2), typeof(MediaThor.IPipelineBehavior<,>));
            }

            if (serviceType == typeof(MediaThor.INotification))
            {
                yield return Of(Get6_INotification, DefaultKey.Of(0));
                yield return Of(Get7_INotification, DefaultKey.Of(1));
            }

            if (serviceType == typeof(MediaThor.IBaseRequest))
            {
                yield return Of(Get8_IBaseRequest, DefaultKey.Of(0));
                yield return Of(Get9_IBaseRequest, DefaultKey.Of(1));
            }

            if (serviceType == typeof(MediaThor.INotificationHandler<MediaThor.Examples.Ponged>))
            {
                yield return Of(Get10_INotificationHandler);
                yield return Of(Get11_INotificationHandler); // co-variant
            }

            if (serviceType == typeof(MediaThor.INotificationHandler<MediaThor.INotification>))
            {
                yield return Of(Get11_INotificationHandler);
            }

            if (serviceType == typeof(MediaThor.IRequestHandler<MediaThor.Examples.Ping, MediaThor.Examples.Pong>))
            {
                yield return Of(Get12_IRequestHandler);
            }

            if (serviceType == typeof(MediaThor.IRequest<MediaThor.Examples.Pong>))
            {
                yield return Of(Get13_IRequest);
            }

            if (serviceType == typeof(MediaThor.INotificationHandler<MediaThor.Examples.Pinged>))
            {
                yield return Of(Get14_INotificationHandler, DefaultKey.Of(0));
                yield return Of(Get15_INotificationHandler, DefaultKey.Of(1));
                yield return Of(Get20_INotificationHandler, typeof(MediaThor.INotificationHandler<>));
                yield return Of(Get11_INotificationHandler); // co-variant
            }

            if (serviceType == typeof(MediaThor.IRequest))
            {
                yield return Of(Get16_IRequest);
            }

            if (serviceType == typeof(MediaThor.IRequestHandler<MediaThor.Examples.Jing, MediaThor.Unit>))
            {
                yield return Of(Get17_IRequestHandler);
            }

            if (serviceType == typeof(MediaThor.IMediator))
            {
                yield return Of(Get18_IMediator);
            }

            if (serviceType == typeof(MediaThor.IRequest<MediaThor.Unit>))
            {
                yield return Of(Get19_IRequest);
            }

        }

        // typeof(MediaThor.IPipelineBehavior<MediaThor.Examples.Ping, MediaThor.Examples.Pong>)
        internal static object Get0_IPipelineBehavior(IResolverContext r)
        {
            return new MediaThor.Pipeline.RequestPostProcessorBehavior<MediaThor.Examples.Ping, MediaThor.Examples.Pong>(new MediaThor.Pipeline.IRequestPostProcessor<MediaThor.Examples.Ping, MediaThor.Examples.Pong>[] { new MediaThor.Examples.ConstrainedRequestPostProcessor<MediaThor.Examples.Ping, MediaThor.Examples.Pong>((System.IO.TextWriter)r.Resolve(typeof(System.IO.TextWriter), null, IfUnresolved.Throw, default(System.Type), Request.Empty.Push(typeof(MediaThor.IPipelineBehavior<MediaThor.Examples.Ping, MediaThor.Examples.Pong>), typeof(MediaThor.IPipelineBehavior<,>), (object)DefaultKey.Of(0), 48, FactoryType.Service, typeof(MediaThor.Pipeline.RequestPostProcessorBehavior<MediaThor.Examples.Ping, MediaThor.Examples.Pong>), Reuse.Transient, RequestFlags.IsResolutionCall).Push(typeof(System.Collections.Generic.IEnumerable<MediaThor.Pipeline.IRequestPostProcessor<MediaThor.Examples.Ping, MediaThor.Examples.Pong>>), default(System.Type), (object)null, 2, FactoryType.Wrapper, default(System.Type), Reuse.Transient, ((RequestFlags)0)).Push(typeof(MediaThor.Pipeline.IRequestPostProcessor<MediaThor.Examples.Ping, MediaThor.Examples.Pong>), default(System.Type), (object)DefaultKey.Of(0), IfUnresolved.ReturnDefaultIfNotRegistered, 49, FactoryType.Service, typeof(MediaThor.Examples.ConstrainedRequestPostProcessor<MediaThor.Examples.Ping, MediaThor.Examples.Pong>), Reuse.Transient, ((RequestFlags)0), 0), default(object[]))), new MediaThor.Examples.GenericRequestPostProcessor<MediaThor.Examples.Ping, MediaThor.Examples.Pong>((System.IO.TextWriter)r.Resolve(typeof(System.IO.TextWriter), null, IfUnresolved.Throw, default(System.Type), Request.Empty.Push(typeof(MediaThor.IPipelineBehavior<MediaThor.Examples.Ping, MediaThor.Examples.Pong>), typeof(MediaThor.IPipelineBehavior<,>), (object)DefaultKey.Of(0), 48, FactoryType.Service, typeof(MediaThor.Pipeline.RequestPostProcessorBehavior<MediaThor.Examples.Ping, MediaThor.Examples.Pong>), Reuse.Transient, RequestFlags.IsResolutionCall).Push(typeof(System.Collections.Generic.IEnumerable<MediaThor.Pipeline.IRequestPostProcessor<MediaThor.Examples.Ping, MediaThor.Examples.Pong>>), default(System.Type), (object)null, 2, FactoryType.Wrapper, default(System.Type), Reuse.Transient, ((RequestFlags)0)).Push(typeof(MediaThor.Pipeline.IRequestPostProcessor<MediaThor.Examples.Ping, MediaThor.Examples.Pong>), default(System.Type), (object)DefaultKey.Of(1), IfUnresolved.ReturnDefaultIfNotRegistered, 50, FactoryType.Service, typeof(MediaThor.Examples.GenericRequestPostProcessor<MediaThor.Examples.Ping, MediaThor.Examples.Pong>), Reuse.Transient, ((RequestFlags)0), 0), default(object[]))) });
        }

        // typeof(MediaThor.IPipelineBehavior<MediaThor.Examples.Jing, MediaThor.Unit>)
        internal static object Get1_IPipelineBehavior(IResolverContext r)
        {
            return new MediaThor.Pipeline.RequestPostProcessorBehavior<MediaThor.Examples.Jing, MediaThor.Unit>(new MediaThor.Pipeline.IRequestPostProcessor<MediaThor.Examples.Jing, MediaThor.Unit>[] { new MediaThor.Examples.GenericRequestPostProcessor<MediaThor.Examples.Jing, MediaThor.Unit>((System.IO.TextWriter)r.Resolve(typeof(System.IO.TextWriter), null, IfUnresolved.Throw, default(System.Type), Request.Empty.Push(typeof(MediaThor.IPipelineBehavior<MediaThor.Examples.Jing, MediaThor.Unit>), typeof(MediaThor.IPipelineBehavior<,>), (object)DefaultKey.Of(0), 51, FactoryType.Service, typeof(MediaThor.Pipeline.RequestPostProcessorBehavior<MediaThor.Examples.Jing, MediaThor.Unit>), Reuse.Transient, RequestFlags.IsResolutionCall).Push(typeof(System.Collections.Generic.IEnumerable<MediaThor.Pipeline.IRequestPostProcessor<MediaThor.Examples.Jing, MediaThor.Unit>>), default(System.Type), (object)null, 2, FactoryType.Wrapper, default(System.Type), Reuse.Transient, ((RequestFlags)0)).Push(typeof(MediaThor.Pipeline.IRequestPostProcessor<MediaThor.Examples.Jing, MediaThor.Unit>), default(System.Type), (object)DefaultKey.Of(1), IfUnresolved.ReturnDefaultIfNotRegistered, 52, FactoryType.Service, typeof(MediaThor.Examples.GenericRequestPostProcessor<MediaThor.Examples.Jing, MediaThor.Unit>), Reuse.Transient, ((RequestFlags)0), 0), default(object[]))) });
        }

        // typeof(MediaThor.IPipelineBehavior<MediaThor.Examples.Ping, MediaThor.Examples.Pong>)
        internal static object Get2_IPipelineBehavior(IResolverContext r)
        {
            return new MediaThor.Pipeline.RequestPreProcessorBehavior<MediaThor.Examples.Ping, MediaThor.Examples.Pong>(new MediaThor.Pipeline.IRequestPreProcessor<MediaThor.Examples.Ping>[] { new MediaThor.Examples.GenericRequestPreProcessor<MediaThor.Examples.Ping>((System.IO.TextWriter)r.Resolve(typeof(System.IO.TextWriter), null, IfUnresolved.Throw, default(System.Type), Request.Empty.Push(typeof(MediaThor.IPipelineBehavior<MediaThor.Examples.Ping, MediaThor.Examples.Pong>), typeof(MediaThor.IPipelineBehavior<,>), (object)DefaultKey.Of(1), 53, FactoryType.Service, typeof(MediaThor.Pipeline.RequestPreProcessorBehavior<MediaThor.Examples.Ping, MediaThor.Examples.Pong>), Reuse.Transient, RequestFlags.IsResolutionCall).Push(typeof(System.Collections.Generic.IEnumerable<MediaThor.Pipeline.IRequestPreProcessor<MediaThor.Examples.Ping>>), default(System.Type), (object)null, 2, FactoryType.Wrapper, default(System.Type), Reuse.Transient, ((RequestFlags)0)).Push(typeof(MediaThor.Pipeline.IRequestPreProcessor<MediaThor.Examples.Ping>), default(System.Type), (object)DefaultKey.Of(0), IfUnresolved.ReturnDefaultIfNotRegistered, 54, FactoryType.Service, typeof(MediaThor.Examples.GenericRequestPreProcessor<MediaThor.Examples.Ping>), Reuse.Transient, ((RequestFlags)0), 0), default(object[]))) });
        }

        // typeof(MediaThor.IPipelineBehavior<MediaThor.Examples.Jing, MediaThor.Unit>)
        internal static object Get3_IPipelineBehavior(IResolverContext r)
        {
            return new MediaThor.Pipeline.RequestPreProcessorBehavior<MediaThor.Examples.Jing, MediaThor.Unit>(new MediaThor.Pipeline.IRequestPreProcessor<MediaThor.Examples.Jing>[] { new MediaThor.Examples.GenericRequestPreProcessor<MediaThor.Examples.Jing>((System.IO.TextWriter)r.Resolve(typeof(System.IO.TextWriter), null, IfUnresolved.Throw, default(System.Type), Request.Empty.Push(typeof(MediaThor.IPipelineBehavior<MediaThor.Examples.Jing, MediaThor.Unit>), typeof(MediaThor.IPipelineBehavior<,>), (object)DefaultKey.Of(1), 55, FactoryType.Service, typeof(MediaThor.Pipeline.RequestPreProcessorBehavior<MediaThor.Examples.Jing, MediaThor.Unit>), Reuse.Transient, RequestFlags.IsResolutionCall).Push(typeof(System.Collections.Generic.IEnumerable<MediaThor.Pipeline.IRequestPreProcessor<MediaThor.Examples.Jing>>), default(System.Type), (object)null, 2, FactoryType.Wrapper, default(System.Type), Reuse.Transient, ((RequestFlags)0)).Push(typeof(MediaThor.Pipeline.IRequestPreProcessor<MediaThor.Examples.Jing>), default(System.Type), (object)DefaultKey.Of(0), IfUnresolved.ReturnDefaultIfNotRegistered, 56, FactoryType.Service, typeof(MediaThor.Examples.GenericRequestPreProcessor<MediaThor.Examples.Jing>), Reuse.Transient, ((RequestFlags)0), 0), default(object[]))) });
        }

        // typeof(MediaThor.IPipelineBehavior<MediaThor.Examples.Ping, MediaThor.Examples.Pong>)
        internal static object Get4_IPipelineBehavior(IResolverContext r)
        {
            return new MediaThor.Examples.GenericPipelineBehavior<MediaThor.Examples.Ping, MediaThor.Examples.Pong>((System.IO.TextWriter)r.Resolve(typeof(System.IO.TextWriter), null, IfUnresolved.Throw, default(System.Type), Request.Empty.Push(typeof(MediaThor.IPipelineBehavior<MediaThor.Examples.Ping, MediaThor.Examples.Pong>), typeof(MediaThor.IPipelineBehavior<,>), (object)DefaultKey.Of(2), 57, FactoryType.Service, typeof(MediaThor.Examples.GenericPipelineBehavior<MediaThor.Examples.Ping, MediaThor.Examples.Pong>), Reuse.Transient, RequestFlags.IsResolutionCall), default(object[])));
        }

        // typeof(MediaThor.IPipelineBehavior<MediaThor.Examples.Jing, MediaThor.Unit>)
        internal static object Get5_IPipelineBehavior(IResolverContext r)
        {
            return new MediaThor.Examples.GenericPipelineBehavior<MediaThor.Examples.Jing, MediaThor.Unit>((System.IO.TextWriter)r.Resolve(typeof(System.IO.TextWriter), null, IfUnresolved.Throw, default(System.Type), Request.Empty.Push(typeof(MediaThor.IPipelineBehavior<MediaThor.Examples.Jing, MediaThor.Unit>), typeof(MediaThor.IPipelineBehavior<,>), (object)DefaultKey.Of(2), 58, FactoryType.Service, typeof(MediaThor.Examples.GenericPipelineBehavior<MediaThor.Examples.Jing, MediaThor.Unit>), Reuse.Transient, RequestFlags.IsResolutionCall), default(object[])));
        }

        // typeof(MediaThor.INotification)
        internal static object Get6_INotification(IResolverContext r)
        {
            return new MediaThor.Examples.Pinged();
        }

        // typeof(MediaThor.INotification)
        internal static object Get7_INotification(IResolverContext r)
        {
            return new MediaThor.Examples.Ponged();
        }

        // typeof(MediaThor.IBaseRequest)
        internal static object Get8_IBaseRequest(IResolverContext r)
        {
            return new MediaThor.Examples.Jing();
        }

        // typeof(MediaThor.IBaseRequest)
        internal static object Get9_IBaseRequest(IResolverContext r)
        {
            return new MediaThor.Examples.Ping();
        }

        // typeof(MediaThor.INotificationHandler<MediaThor.Examples.Ponged>)
        internal static object Get10_INotificationHandler(IResolverContext r)
        {
            return new MediaThor.Examples.PongedHandler((System.IO.TextWriter)r.Resolve(typeof(System.IO.TextWriter), null, IfUnresolved.Throw, default(System.Type), Request.Empty.Push(typeof(MediaThor.INotificationHandler<MediaThor.Examples.Ponged>), default(System.Type), (object)null, 41, FactoryType.Service, typeof(MediaThor.Examples.PongedHandler), Reuse.Transient, RequestFlags.IsResolutionCall), default(object[])));
        }

        // typeof(MediaThor.INotificationHandler<MediaThor.INotification>)
        internal static object Get11_INotificationHandler(IResolverContext r)
        {
            return new MediaThor.Examples.GenericHandler((System.IO.TextWriter)r.Resolve(typeof(System.IO.TextWriter), null, IfUnresolved.Throw, default(System.Type), Request.Empty.Push(typeof(MediaThor.INotificationHandler<MediaThor.INotification>), default(System.Type), (object)null, 32, FactoryType.Service, typeof(MediaThor.Examples.GenericHandler), Reuse.Transient, RequestFlags.IsResolutionCall), default(object[])));
        }

        // typeof(MediaThor.IRequestHandler<MediaThor.Examples.Ping, MediaThor.Examples.Pong>)
        internal static object Get12_IRequestHandler(IResolverContext r)
        {
            return new MediaThor.Examples.PingHandler((System.IO.TextWriter)r.Resolve(typeof(System.IO.TextWriter), null, IfUnresolved.Throw, default(System.Type), Request.Empty.Push(typeof(MediaThor.IRequestHandler<MediaThor.Examples.Ping, MediaThor.Examples.Pong>), default(System.Type), (object)null, 44, FactoryType.Service, typeof(MediaThor.Examples.PingHandler), Reuse.Transient, RequestFlags.IsResolutionCall), default(object[])));
        }

        // typeof(MediaThor.IRequest<MediaThor.Examples.Pong>)
        internal static object Get13_IRequest(IResolverContext r)
        {
            return new MediaThor.Examples.Ping();
        }

        // typeof(MediaThor.INotificationHandler<MediaThor.Examples.Pinged>)
        internal static object Get14_INotificationHandler(IResolverContext r)
        {
            return new MediaThor.Examples.PingedHandler((System.IO.TextWriter)r.Resolve(typeof(System.IO.TextWriter), null, IfUnresolved.Throw, default(System.Type), Request.Empty.Push(typeof(MediaThor.INotificationHandler<MediaThor.Examples.Pinged>), default(System.Type), (object)DefaultKey.Of(0), 40, FactoryType.Service, typeof(MediaThor.Examples.PingedHandler), Reuse.Transient, RequestFlags.IsResolutionCall), default(object[])));
        }

        // typeof(MediaThor.INotificationHandler<MediaThor.Examples.Pinged>)
        internal static object Get15_INotificationHandler(IResolverContext r)
        {
            return new MediaThor.Examples.PingedAlsoHandler((System.IO.TextWriter)r.Resolve(typeof(System.IO.TextWriter), null, IfUnresolved.Throw, default(System.Type), Request.Empty.Push(typeof(MediaThor.INotificationHandler<MediaThor.Examples.Pinged>), default(System.Type), (object)DefaultKey.Of(1), 43, FactoryType.Service, typeof(MediaThor.Examples.PingedAlsoHandler), Reuse.Transient, RequestFlags.IsResolutionCall), default(object[])));
        }

        // typeof(MediaThor.IRequest)
        internal static object Get16_IRequest(IResolverContext r)
        {
            return new MediaThor.Examples.Jing();
        }

        // typeof(MediaThor.IRequestHandler<MediaThor.Examples.Jing, MediaThor.Unit>)
        internal static object Get17_IRequestHandler(IResolverContext r)
        {
            return new MediaThor.Examples.JingHandler((System.IO.TextWriter)r.Resolve(typeof(System.IO.TextWriter), null, IfUnresolved.Throw, default(System.Type), Request.Empty.Push(typeof(MediaThor.IRequestHandler<MediaThor.Examples.Jing, MediaThor.Unit>), default(System.Type), (object)null, 37, FactoryType.Service, typeof(MediaThor.Examples.JingHandler), Reuse.Transient, RequestFlags.IsResolutionCall), default(object[])));
        }

        // typeof(MediaThor.IMediator)
        internal static object Get18_IMediator(IResolverContext r)
        {
            return new MediaThor.Mediator((MediaThor.ServiceFactory)r.Resolve(typeof(MediaThor.ServiceFactory), null, IfUnresolved.Throw, default(System.Type), Request.Empty.Push(typeof(MediaThor.IMediator), default(System.Type), (object)null, 28, FactoryType.Service, typeof(MediaThor.Mediator), Reuse.Transient, RequestFlags.IsResolutionCall), default(object[])));
        }

        // typeof(MediaThor.IRequest<MediaThor.Unit>)
        internal static object Get19_IRequest(IResolverContext r)
        {
            return new MediaThor.Examples.Jing();
        }

        // typeof(MediaThor.INotificationHandler<MediaThor.Examples.Pinged>)
        internal static object Get20_INotificationHandler(IResolverContext r)
        {
            return new MediaThor.Examples.ConstrainedPingedHandler<MediaThor.Examples.Pinged>((System.IO.TextWriter)r.Resolve(typeof(System.IO.TextWriter), null, IfUnresolved.Throw, default(System.Type), Request.Empty.Push(typeof(MediaThor.INotificationHandler<MediaThor.Examples.Pinged>), typeof(MediaThor.INotificationHandler<>), (object)null, 59, FactoryType.Service, typeof(MediaThor.Examples.ConstrainedPingedHandler<MediaThor.Examples.Pinged>), Reuse.Transient, RequestFlags.IsResolutionCall), default(object[])));
        }

    }
}
