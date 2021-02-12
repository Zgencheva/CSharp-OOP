using System;
using System.Collections.Generic;
using System.Text;

using MilitaryElite2.Enumerations;

namespace MilitaryElite2.Contracts
{
    public interface IMission
    {
        MissionStateEnum missionStateEnum { get; }

        void CompleteMission(string missionName);
    }
}
