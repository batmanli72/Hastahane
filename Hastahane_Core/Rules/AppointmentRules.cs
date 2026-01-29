using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hastahane_Domain.Entities;

namespace Hastahane_Core.Rules
{
    public static class AppointmentRules
    {
        public static bool IsAppointmentAvailable(List<Appointment> existingAppointments, DateTime requestedDate, int doctorId)
        {
            return !existingAppointments.Any(a =>
                a.DoctorId == doctorId &&
                a.AppointmentDate == requestedDate);
        }

        public static bool IsValidAppointmentDate(DateTime appointmentDate)
        {
            return appointmentDate > DateTime.UtcNow;
        }
    }
}
