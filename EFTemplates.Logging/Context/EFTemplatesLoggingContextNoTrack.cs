
using Microsoft.EntityFrameworkCore;

namespace EFTemplates.Logging.Context
{
    class EFTemplatesLoggingContextNoTrack : EFTemplatesLoggingContext
    {
        public EFTemplatesLoggingContextNoTrack()
        {
            base.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    }
}
