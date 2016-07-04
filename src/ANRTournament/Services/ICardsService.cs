﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANRTournament.Services
{
    public interface ICardsService
    {
        Task<CardList> GetCardsAsync(bool disableCache);
    }
}
