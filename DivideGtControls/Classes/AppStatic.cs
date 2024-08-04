﻿using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideGT
{
    public static class AppStatic
    {
        public static Logger logger { get; set; }

        public static ITournamentProvider TournamentProvider { get; set; }

        public static TournamentDate TournamentDate { get; set; }
    }
}
