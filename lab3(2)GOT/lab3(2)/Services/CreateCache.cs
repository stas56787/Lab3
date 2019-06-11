using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab3.Models;
using Microsoft.Extensions.Caching.Memory;
using lab3.Data;
using lab3.ViewModels;

namespace lab3.Services
{
    public class CreateCache
    {
        private IMemoryCache cache;

        public CreateCache(Context context, IMemoryCache memoryCache)
        {
            cache = memoryCache;
        }

        public HomeViewModel GetProduct(string key)
        {
            HomeViewModel homeViewModel = null;

            if (!cache.TryGetValue(key, out homeViewModel))
            {
                homeViewModel = TakeLast.GetHomeViewModel();
                if (homeViewModel != null)
                {
                    cache.Set(key, homeViewModel,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds((2 * 5) + 240)));
                }
            }
            return homeViewModel;
        }
    }
}
