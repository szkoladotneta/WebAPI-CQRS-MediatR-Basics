using Webinar202103.Application.Common.Interfaces;
using System;

namespace Webinar202103.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
