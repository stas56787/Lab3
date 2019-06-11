using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab3.Models;

namespace lab3.Data
{
    public class SchedulesForWeeksContext
    {
        public static List<ScheduleForWeek> GetAll()
        {
            List<ScheduleForWeek> all = new List<ScheduleForWeek>();
            using (Context db = new Context())
            {
                all = db.SchedulesForWeek.ToList();
            }

            return all;
        }

        public static void AddScheduleForWeek(ScheduleForWeek patientToAdd)
        {
            using (Context db = new Context())
            {
                db.SchedulesForWeek.Add(patientToAdd);
                db.SaveChanges();
            }
        }

        public static void UpdataScheduleForWeek(ScheduleForWeek scheduleForWeek)
        {
            using (Context db = new Context())
            {
                if (scheduleForWeek != null)
                {
                    db.SchedulesForWeek.Update(scheduleForWeek);
                    db.SaveChanges();
                }
            }
        }

        public static void DeleteScheduleForWeek(ScheduleForWeek scheduleForWeekToDelete)
        {
            using (Context db = new Context())
            {
                if (scheduleForWeekToDelete != null)
                {
                    db.SchedulesForWeek.Remove(scheduleForWeekToDelete);
                    db.SaveChanges();
                }
            }
        }

        public static List<ScheduleForWeek> FindScheduleForWeek(int? scheduleForWeekID, string startTime,
            string guestsEmployees)
        {
            List<ScheduleForWeek> scheduleForWeek = new List<ScheduleForWeek>();
            using (Context db = new Context())
            {
                if (scheduleForWeekID != null)
                {
                    scheduleForWeek = db.SchedulesForWeek.Where(k => k.ScheduleForWeekID == scheduleForWeekID).ToList();
                }
                if (startTime != null)
                {
                    if (scheduleForWeek.Count != 0)
                    {
                        scheduleForWeek = scheduleForWeek.Where(k => k.StartTime == startTime).ToList();
                    }
                    else
                    {
                        scheduleForWeek = db.SchedulesForWeek.Where(k => k.StartTime == startTime).ToList();
                    }
                }
                if (guestsEmployees != null)
                {
                    if (scheduleForWeek.Count != 0)
                    {
                        scheduleForWeek = scheduleForWeek.Where(k => k.GuestsEmployees == guestsEmployees).ToList();
                    }
                    else
                    {
                        scheduleForWeek = db.SchedulesForWeek.Where(k => k.GuestsEmployees == guestsEmployees).ToList();
                    }
                }
            }
            return scheduleForWeek;
        }

        public static ScheduleForWeek FindScheduleForWeekById(int id)
        {
            ScheduleForWeek scheduleForWeek = null;
            using (Context db = new Context())
            {
                scheduleForWeek = db.SchedulesForWeek.Where(k => k.ScheduleForWeekID == id).ToList().FirstOrDefault();
            }
            return scheduleForWeek;
        }
    }
}
