namespace BundledAsyncSite.Host.Bus
{
    using System;
    using System.Collections.Generic;
    using BundledAsyncSite.Host.Bus.EventHandlers;
    using BundledAsyncSite.Host.Events;

    /// <summary>
    /// Maintains event to event handlers mappings.
    /// </summary>
    /// <remarks>
    /// This class is not thread-safe. 
    /// </remarks>
    public class EventHandlerResolver
    {
        private static EventHandlerResolver instance = new EventHandlerResolver();
        private IDictionary<Type, IList<EventHandlerBaseUntyped>> handlers
            = new Dictionary<Type, IList<EventHandlerBaseUntyped>>();

        private EventHandlerResolver()
        {
        }

        public static EventHandlerResolver Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Registers handler for a given type.
        /// </summary>
        /// <remarks>
        /// You can register more than one handler for the same event. 
        /// Handler instance is created during registration. Same instance will be resolved every time.
        /// </remarks>
        /// <typeparam name="TEvent">Event type. </typeparam>
        /// <typeparam name="THandler">Event handler type. </typeparam>
        public void Register<TEvent, THandler>()
            where TEvent : EventBase
            where THandler : EventHandlerBaseUntyped, new()
        {
            if (!this.handlers.ContainsKey(typeof(TEvent)))
            {
                this.handlers[typeof(TEvent)] = new List<EventHandlerBaseUntyped>();
            }

            this.handlers[typeof(TEvent)].Add(new THandler());
        }

        /// <summary>
        /// Resolves all handlers registered for provided event. 
        /// </summary>
        /// <remarks>
        /// Never fails. If request for unregistered even type is provided
        /// empty list is returned.
        /// </remarks>
        /// <typeparam name="TEvent">Event type to resolve handlers for. </typeparam>
        /// <returns>List of handlers registered for type.</returns>
        public IList<EventHandlerBaseUntyped> Resolve<TEvent>() where TEvent : EventBase
        {
            return this.Resolve(typeof(TEvent));
        }

        /// <summary>
        /// Resolves all handlers registered for provided event. 
        /// </summary>
        /// <remarks>
        /// Untyped version. 
        /// Never fails. If request for unregistered even type is provided
        /// empty list is returned.
        /// </remarks>
        /// <param name="eventType">Event type. </param>
        /// <returns>List of handlers registered for type.</returns>
        public IList<EventHandlerBaseUntyped> Resolve(Type eventType)
        {
            if (this.handlers.ContainsKey(eventType))
            {
                return this.handlers[eventType];
            }

            return new List<EventHandlerBaseUntyped>();
        }
    }
}