﻿using NNProjekat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NNProjekat.Services
{
    public interface ITipAktivnostiData
    {
        IEnumerable<TipAktivnosti> UcitajSvePoPredmetu(string sifraPredmeta);
        IEnumerable<TipAktivnosti> UcitajSve();
        TipAktivnosti VratiTip(string sifraPredmeta, string sifraTipaAktivnosti);

    }
}
