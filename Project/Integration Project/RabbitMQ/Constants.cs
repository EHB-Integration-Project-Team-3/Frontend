using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.RabbitMQ
{
    public class Constants
    {
        public const string Connection = "localhost";

        public const string EventX = "event-exchange";
        public const string UserX = "user-exchange";
        public const string WarningX = "warning-exchange";

        public const string CanvasEventQ = "to-canvas_event-queue";
        public const string CanvasUserQ = "to-canvas_user-queue";

        public const string FrontendEventQ = "to-frontend_event-queue";
        public const string FrontendUserQ = "to-frontend_user-queue";

        public const string MonitoringEventQ = "to-monitoring_event-queue";
        public const string MonitoringUserQ = "to-monitoring_user-queue";

        public const string PlanningEventQ = "to-planning_event-queue";
        public const string PlanningUserQ = "to-planning_user-queue";

        public const string MuuidEventQ = "to-muuid_event-queue";
        public const string MuuidUserQ = "to-muuid_user-queue";

        public const string MonitoringMailQ = "to-monitoring_mail-queue";
        public const string MonitoringWarningQ = "to-monitoring_warning-queue";
        public const string MonitoringHeartbeatQ = "to-monitoring_heartbeat-queue";
    }
}