using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using lab3.ViewModels;
using lab3.Models;
using lab3.Data;

namespace lab3.Services
{
    public class TakeLast
    {
        public static HomeViewModel GetHomeViewModel()
        {
            HomeViewModel homeViewModel = null;
            Thread.Sleep(2000);
            using (Context _context = new Context())
            {
                List<TVShow> tvShows = _context.TVShows.OrderByDescending(p => p.TVShowID).Take(10).ToList();
                List<Genre> genres = _context.Genres.OrderByDescending(p => p.GenreID).Take(10).ToList();
                List<CitizensAppeal> citizensAppeals = _context.CitizensAppeals.OrderByDescending(p => p.CitizensAppealID).Take(10).ToList();
                List<ScheduleForWeek> schedulesForWeeks = _context.SchedulesForWeek.OrderByDescending(p => p.ScheduleForWeekID).Take(10).ToList();
                homeViewModel = new HomeViewModel {
                    SchedulesForWeek = schedulesForWeeks,
                    TVShows = tvShows,
                    Genres = genres,
                    CitizensAppeals = citizensAppeals
                };
            }

            return homeViewModel;
        }
    }
}
