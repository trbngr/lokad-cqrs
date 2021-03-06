﻿using System;

namespace Lokad.Cqrs.Envelope.Events
{
    [Serializable]
    public sealed class EnvelopeQuarantined : ISystemEvent
    {
        public Exception LastException { get; private set; }
        public string Dispatcher { get; private set; }
        public ImmutableEnvelope Envelope { get; private set; }

        public EnvelopeQuarantined(Exception lastException, string dispatcher, ImmutableEnvelope envelope)
        {
            LastException = lastException;
            Dispatcher = dispatcher;
            Envelope = envelope;
        }

        public override string ToString()
        {
            return string.Format("Quarantined '{0}': {1}", Envelope.EnvelopeId, LastException.Message);
        }
    }

    [Serializable]
    public sealed class EnvelopeCleanupFailed : ISystemEvent
    {
        public Exception Exception { get; private set; }
        public string Dispatcher { get; private set; }
        public ImmutableEnvelope Envelope { get; private set; }

        public EnvelopeCleanupFailed(Exception exception, string dispatcher, ImmutableEnvelope envelope)
        {
            Exception = exception;
            Dispatcher = dispatcher;
            Envelope = envelope;
        }
    }



    [Serializable]
    public sealed class EnvelopeDispatched : ISystemEvent
    {
        public ImmutableEnvelope Envelope { get; private set; }
        public string Dispatcher { get; private set; }
        public EnvelopeDispatched(ImmutableEnvelope envelope, string dispatcher)
        {
            Envelope = envelope;
            Dispatcher = dispatcher;
        }
    }
}