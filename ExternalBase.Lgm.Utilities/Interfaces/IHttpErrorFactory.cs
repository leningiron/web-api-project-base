using ExternalBase.Lgm.Utilities.Entities;
using System;

namespace ExternalBase.Lgm.Utilities.Interfaces
{
    public interface IHttpErrorFactory
    {
        HttpError CreateFrom(Exception exception);
    }
}
