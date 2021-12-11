using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocosAndRepos
{
    public class DevTeam_Repo
    {
        private List<DevTeam> _listOfTeams = new List<DevTeam>();

        public void AddDevTeamToList(DevTeam team)
        {
            _listOfTeams.Add(team);
        }

        public void AddDeveloperToTeam(DevTeam devTeam, Dev addSingleDeveloper)
        {
            devTeam.TeamMembers.Add(addSingleDeveloper);
        }

        public List<DevTeam> GetTeamList()
        {
            return _listOfTeams;
        }
        public bool UpdateExisitingTeamList(int teamId, DevTeam newTeam)
        {
            DevTeam oldTeam = GetTeamById(teamId);

            if (oldTeam != null)
            {
                oldTeam.TeamName = newTeam.TeamName;
                oldTeam.TeamIdNumber = newTeam.TeamIdNumber;

                return true;
            }
            else
            {
                return false;
            }
        }
        public bool AddingEmployeeToList(int addDevToTeamId, Dev addDeveloper)
        {
            DevTeam addTeamMember = GetTeamById(addDevToTeamId);


            if (addTeamMember != null)
            {
                addTeamMember.TeamMembers.Add(addDeveloper);

                return true;
            }
            else
            {
                return false;
            }

        }

        public bool RemoveEmployeeFromList(string teamname)
        {
            DevTeam team = GetTeamByName(teamname);

            if (team == null)
            {
                return false;
            }

            int initalCount = _listOfTeams.Count;
            _listOfTeams.Remove(team);

            if (initalCount > _listOfTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RemoveDeveloperFromTeam(int teamID, Dev removeDeveloper)
        {
            DevTeam DeleteTeamMember = GetTeamById(teamID);

            if (DeleteTeamMember != null)
            {
                DeleteTeamMember.TeamMembers.Remove(removeDeveloper);

                return true;
            }
            else
            {
                return false;
            }
        }

        private DevTeam GetTeamByName(string teamname)
        {
            foreach (DevTeam team in _listOfTeams)
            {
                if (team.TeamName == teamname.ToLower())
                {
                    return team;
                }
            }
            return null;

        }
        public DevTeam GetTeamById(int teamid)
        {
            foreach (DevTeam team in _listOfTeams)
            {
                if (team.TeamIdNumber == teamid)
                {
                    return team;
                }
            }
            return null;
        }
    }
}
