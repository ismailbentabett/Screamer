using Screamer.Application.Common.Interfaces;

namespace Screamer.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
